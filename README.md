# video-skill
## Sample for processing videos in the Azure Cognitive Search skillset. 

This sample creates the skills needed to submit a video for processing and save the results from the video indexer in a different container. A second indexer can now process the video results

### To Deploy:
1. Clone the repo
2. Update the environment variables
3. Deploy
4. Create a skillset add the submitVideo skill as a custom skill
5. Create a second skillset to process the JSON file in the transcribed-videos container
