using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApiSkills.Common;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Net.Http;
using System.Linq;
using System.Web;
using VideoIndexerSkill.WebApiSkills;
using System.Text;

namespace VideoIndexerSkill
{
    public static class Function1
    {
        [FunctionName("SubmitVideo")]
        public static async Task<IActionResult> RunSubmitVideo(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log, ExecutionContext executionContext)
        {
            log.LogInformation("Submit Video Indexer Skill: C# HTTP trigger function processed a request.");
            //log.LogInformation($"REQUEST: {new StreamReader(req.Body).ReadToEnd()}");
            //req.Body.Position = 0;
            try
            {
                
                string skillName = executionContext.FunctionName;
                IEnumerable<WebApiRequestRecord> requestRecords = WebApiSkillHelpers.GetRequestRecords(req);
                if (requestRecords == null)
                {
                    return new BadRequestObjectResult($"{skillName} - Invalid request record array.");
                }
                string apiKey = Environment.GetEnvironmentVariable("videoIndexerAPIKey");
                var apiUrl = "https://api.videoindexer.ai";
                System.Net.ServicePointManager.SecurityProtocol =
                System.Net.ServicePointManager.SecurityProtocol | System.Net.SecurityProtocolType.Tls12;

                // create the http client
                var handler = new HttpClientHandler();
                handler.AllowAutoRedirect = false;
                var client = new HttpClient(handler);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);

                // obtain account information and access token
                string queryParams = CreateQueryString(
                    new Dictionary<string, string>()
                    {
                        {"generateAccessTokens", "true"},
                        {"allowEdit", "true"},
                    });
                HttpResponseMessage result = await client.GetAsync($"{apiUrl}/auth/trial/Accounts?{queryParams}");
                var json = await result.Content.ReadAsStringAsync();
                var accounts = JsonConvert.DeserializeObject<AccountContractSlim[]>(json);

                // take the relevant account, here we simply take the first, 
                // you can also get the account via accounts.First(account => account.Id == <GUID>);
                var accountInfo = accounts.First();

                // we will use the access token from here on, no need for the apim key
                client.DefaultRequestHeaders.Remove("Ocp-Apim-Subscription-Key");



                WebApiSkillResponse response = await WebApiSkillHelpers.ProcessRequestRecordsAsync(skillName, requestRecords,
                    async (inRecord, outRecord) =>
                    {
                        var videoUrl = inRecord.Data["videoUrl"] as string;
                        string name = videoUrl.Substring(videoUrl.LastIndexOf('/') + 1);
                        var videoSasToken = inRecord.Data["videoSasToken"] as string;
                        videoUrl += videoSasToken;
                        string site = Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME");
                        string code = Environment.GetEnvironmentVariable("code");
                        
                        var callbackUrl = $"https://{site}/api/VideoComplete?code={code}";
                        var content = new MultipartFormDataContent();

                        queryParams = CreateQueryString(
                            new Dictionary<string, string>()
                            {
                                {"accessToken", accountInfo.AccessToken},
                                {"name",  name},
                                {"description", "video_description"},
                                {"privacy", "private"},
                                {"partition", "partition"},
                                {"videoUrl", videoUrl},
                                {"callbackUrl", callbackUrl},
                            });
                        var uploadRequestResult = await client.PostAsync($"{apiUrl}/{accountInfo.Location}/Accounts/{accountInfo.Id}/Videos?{queryParams}", content);
                        var uploadResult = await uploadRequestResult.Content.ReadAsStringAsync();

                        // get the video ID from the upload result
                        string videoId = JsonConvert.DeserializeObject<dynamic>(uploadResult)["id"];


                        outRecord.Data["jobId"] = videoId;
                        return outRecord;
                    });
                log.LogInformation(JsonConvert.SerializeObject(response));
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                log.LogError(ex.StackTrace);

            }
            return null;

        }
        private static string GetContainerSasUri(CloudBlobContainer container)
        {

            string sasContainerToken;
            SharedAccessBlobPolicy adHocPolicy = new SharedAccessBlobPolicy()
            {
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24),
                Permissions = SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.List | SharedAccessBlobPermissions.Create
            };
            sasContainerToken = container.GetSharedAccessSignature(adHocPolicy, null);
            return container.Uri + sasContainerToken;
        }

        [FunctionName("VideoComplete")]
        public static async Task<IActionResult> RunVideoComplete(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string id = req.Query["id"];
            string state = req.Query["state"];
            CloudBlobContainer cloudBlobContainer;
            CloudBlobClient cloudBlobClient;
            if (state == "Processed")
            {
                //Get the inde file and save it to blob...
                string storageConnectionString = Environment.GetEnvironmentVariable("StorageConnection");

                CloudStorageAccount storageAccount;
                if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
                {
                    cloudBlobClient = storageAccount.CreateCloudBlobClient();
                    cloudBlobContainer = cloudBlobClient.GetContainerReference("transcribed-video");
                    await cloudBlobContainer.CreateIfNotExistsAsync();
                    
                }
                else
                {
                    // Otherwise, let the user know that they need to define the environment variable.
                    throw new Exception("Cannot access storage account");
                }
                string apiKey = Environment.GetEnvironmentVariable("videoIndexerAPIKey");
                var apiUrl = "https://api.videoindexer.ai";
                System.Net.ServicePointManager.SecurityProtocol =
                System.Net.ServicePointManager.SecurityProtocol | System.Net.SecurityProtocolType.Tls12;

                // create the http client
                var handler = new HttpClientHandler();
                handler.AllowAutoRedirect = false;
                var client = new HttpClient(handler);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);

                // obtain account information and access token
                string queryParams = CreateQueryString(
                    new Dictionary<string, string>()
                    {
                        {"generateAccessTokens", "true"},
                        {"allowEdit", "true"},
                    });
                HttpResponseMessage result = await client.GetAsync($"{apiUrl}/auth/trial/Accounts?{queryParams}");
                var json = await result.Content.ReadAsStringAsync();
                var accounts = JsonConvert.DeserializeObject<AccountContractSlim[]>(json);

                // take the relevant account, here we simply take the first, 
                // you can also get the account via accounts.First(account => account.Id == <GUID>);
                var accountInfo = accounts.First();

                // we will use the access token from here on, no need for the apim key
                client.DefaultRequestHeaders.Remove("Ocp-Apim-Subscription-Key");
                queryParams = CreateQueryString(
                           new Dictionary<string, string>()
                           {
                                {"accessToken", accountInfo.AccessToken},

                    
                           });
                var uploadRequestResult = await client.GetAsync($"{apiUrl}/{accountInfo.Location}/Accounts/{accountInfo.Id}/Videos/{id}/Index?{queryParams}");
                var uploadResult = await uploadRequestResult.Content.ReadAsStringAsync();
                VideoIndex vi = JsonConvert.DeserializeObject<VideoIndex>(uploadResult);
                string fName = vi.summarizedInsights.name;
                CloudBlockBlob blob = cloudBlobContainer.GetBlockBlobReference(fName);
                blob.Properties.ContentType = "application/json";
                using (Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(uploadResult)))
                {
                    await blob.UploadFromStreamAsync(stream);
                }

            }
            return (ActionResult)new OkObjectResult($"OK");
                
        }
        private static string CreateQueryString(IDictionary<string, string> parameters)
        {
            var queryParameters = HttpUtility.ParseQueryString(string.Empty);
            foreach (var parameter in parameters)
            {
                queryParameters[parameter.Key] = parameter.Value;
            }

            return queryParameters.ToString();
        }
    }
    public class AccountContractSlim
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string AccountType { get; set; }
        public string Url { get; set; }
        public string AccessToken { get; set; }
    }
}
