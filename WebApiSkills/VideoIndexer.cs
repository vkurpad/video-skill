﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VideoIndexerSkill.WebApiSkills
{
    

    public class VideoIndex
    {
        public string partition { get; set; }
        public string description { get; set; }
        public string privacyMode { get; set; }
        public string state { get; set; }
        public string accountId { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string userName { get; set; }
        public DateTime created { get; set; }
        public bool isOwned { get; set; }
        public bool isEditable { get; set; }
        public bool isBase { get; set; }
        public int durationInSeconds { get; set; }
        public Summarizedinsights summarizedInsights { get; set; }
        public Video[] videos { get; set; }
        public Videosrange[] videosRanges { get; set; }
    }

    public class Summarizedinsights
    {
        public string name { get; set; }
        public string id { get; set; }
        public string privacyMode { get; set; }
        public Duration duration { get; set; }
        public string thumbnailVideoId { get; set; }
        public string thumbnailId { get; set; }
        public Face[] faces { get; set; }
        public Keyword[] keywords { get; set; }
        public Sentiment[] sentiments { get; set; }
        public object[] emotions { get; set; }
        public Audioeffect[] audioEffects { get; set; }
        public Label[] labels { get; set; }
        public object[] framePatterns { get; set; }
        public Brand[] brands { get; set; }
        public object[] namedLocations { get; set; }
        public object[] namedPeople { get; set; }
        public object statistics { get; set; }
        public Topic[] topics { get; set; }
    }

    public class Duration
    {
        public string time { get; set; }
        public float seconds { get; set; }
    }

    
    public class Face
    {
        public string videoId { get; set; }
        public int confidence { get; set; }
        public object description { get; set; }
        public object title { get; set; }
        public string thumbnailId { get; set; }
        public float seenDuration { get; set; }
        public float seenDurationRatio { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public Appearance[] appearances { get; set; }
    }

    public class Appearance
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public float startSeconds { get; set; }
        public float endSeconds { get; set; }
    }

    public class Keyword
    {
        public bool isTranscript { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public Appearance1[] appearances { get; set; }
    }

    public class Appearance1
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int startSeconds { get; set; }
        public float endSeconds { get; set; }
    }

    public class Sentiment
    {
        public string sentimentKey { get; set; }
        public float seenDurationRatio { get; set; }
        public Appearance2[] appearances { get; set; }
    }

    public class Appearance2
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public float startSeconds { get; set; }
        public float endSeconds { get; set; }
    }

    public class Audioeffect
    {
        public string audioEffectKey { get; set; }
        public float seenDurationRatio { get; set; }
        public float seenDuration { get; set; }
        public Appearance3[] appearances { get; set; }
    }

    public class Appearance3
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int startSeconds { get; set; }
        public float endSeconds { get; set; }
    }

    public class Label
    {
        public int id { get; set; }
        public string name { get; set; }
        public Appearance4[] appearances { get; set; }
    }

    public class Appearance4
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public float startSeconds { get; set; }
        public float endSeconds { get; set; }
    }

    public class Brand
    {
        public string referenceId { get; set; }
        public string referenceUrl { get; set; }
        public int confidence { get; set; }
        public string description { get; set; }
        public float seenDuration { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public Appearance5[] appearances { get; set; }
    }

    public class Appearance5
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int startSeconds { get; set; }
        public float endSeconds { get; set; }
    }

    public class Topic
    {
        public object referenceUrl { get; set; }
        public object iptcName { get; set; }
        public object iabName { get; set; }
        public float confidence { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public Appearance6[] appearances { get; set; }
    }

    public class Appearance6
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int startSeconds { get; set; }
        public float endSeconds { get; set; }
    }

    public class Video
    {
        public string accountId { get; set; }
        public string id { get; set; }
        public string state { get; set; }
        public string moderationState { get; set; }
        public string reviewState { get; set; }
        public string privacyMode { get; set; }
        public string processingProgress { get; set; }
        public string failureCode { get; set; }
        public string failureMessage { get; set; }
        public object externalId { get; set; }
        public object externalUrl { get; set; }
        public object metadata { get; set; }
        public Insights insights { get; set; }
        public string thumbnailId { get; set; }
        public bool detectSourceLanguage { get; set; }
        public string languageAutoDetectMode { get; set; }
        public string sourceLanguage { get; set; }
        public string[] sourceLanguages { get; set; }
        public string language { get; set; }
        public string[] languages { get; set; }
        public string indexingPreset { get; set; }
        public string linguisticModelId { get; set; }
        public string personModelId { get; set; }
        public bool isAdult { get; set; }
        public string publishedUrl { get; set; }
        public object publishedProxyUrl { get; set; }
        public string viewToken { get; set; }
    }

    public class Insights
    {
        public string version { get; set; }
        public string duration { get; set; }
        public string sourceLanguage { get; set; }
        public string[] sourceLanguages { get; set; }
        public string language { get; set; }
        public string[] languages { get; set; }
        public Transcript[] transcript { get; set; }
        public Ocr[] ocr { get; set; }
        public Keyword1[] keywords { get; set; }
        public Topic1[] topics { get; set; }
        public Face1[] faces { get; set; }
        public Label1[] labels { get; set; }
        public Scene[] scenes { get; set; }
        public Shot[] shots { get; set; }
        public Brand1[] brands { get; set; }
        public Audioeffect1[] audioEffects { get; set; }
        public Sentiment1[] sentiments { get; set; }
        public Block[] blocks { get; set; }
        public Speaker[] speakers { get; set; }
        public Textualcontentmoderation textualContentModeration { get; set; }
        public Statistics1 statistics { get; set; }
    }

    public class Textualcontentmoderation
    {
        public int id { get; set; }
        public int bannedWordsCount { get; set; }
        public int bannedWordsRatio { get; set; }
        public object[] instances { get; set; }
    }

    public class Statistics1
    {
        public int correspondenceCount { get; set; }
        public Speakertalktolistenratio1 speakerTalkToListenRatio { get; set; }
        public Speakerlongestmonolog1 speakerLongestMonolog { get; set; }
        public Speakernumberoffragments1 speakerNumberOfFragments { get; set; }
        public Speakerwordcount1 speakerWordCount { get; set; }
    }

    public class Speakertalktolistenratio1
    {
        public float _1 { get; set; }
        public float _2 { get; set; }
        public float _3 { get; set; }
        public float _4 { get; set; }
        public float _5 { get; set; }
    }

    public class Speakerlongestmonolog1
    {
        public int _1 { get; set; }
        public int _2 { get; set; }
        public int _3 { get; set; }
        public int _4 { get; set; }
        public int _5 { get; set; }
    }

    public class Speakernumberoffragments1
    {
        public int _1 { get; set; }
        public int _2 { get; set; }
        public int _3 { get; set; }
        public int _4 { get; set; }
        public int _5 { get; set; }
    }

    public class Speakerwordcount1
    {
        public int _1 { get; set; }
        public int _2 { get; set; }
        public int _3 { get; set; }
        public int _4 { get; set; }
        public int _5 { get; set; }
    }

    public class Transcript
    {
        public int id { get; set; }
        public string text { get; set; }
        public float confidence { get; set; }
        public int speakerId { get; set; }
        public string language { get; set; }
        public Instance[] instances { get; set; }
    }

    public class Instance
    {
        public string adjustedStart { get; set; }
        public string adjustedEnd { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Ocr
    {
        public int id { get; set; }
        public string text { get; set; }
        public float confidence { get; set; }
        public int left { get; set; }
        public int top { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string language { get; set; }
        public Instance1[] instances { get; set; }
    }

    public class Instance1
    {
        public string adjustedStart { get; set; }
        public string adjustedEnd { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Keyword1
    {
        public int id { get; set; }
        public string text { get; set; }
        public float confidence { get; set; }
        public string language { get; set; }
        public Instance2[] instances { get; set; }
    }

    public class Instance2
    {
        public string adjustedStart { get; set; }
        public string adjustedEnd { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Topic1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string referenceId { get; set; }
        public string referenceType { get; set; }
        public float confidence { get; set; }
        public object iabName { get; set; }
        public string language { get; set; }
        public Instance3[] instances { get; set; }
    }

    public class Instance3
    {
        public string adjustedStart { get; set; }
        public string adjustedEnd { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Face1
    {
        public int id { get; set; }
        public string name { get; set; }
        public int confidence { get; set; }
        public object description { get; set; }
        public string thumbnailId { get; set; }
        public object title { get; set; }
        public object imageUrl { get; set; }
        public Thumbnail[] thumbnails { get; set; }
        public Instance5[] instances { get; set; }
    }

    public class Thumbnail
    {
        public string id { get; set; }
        public string fileName { get; set; }
        public Instance4[] instances { get; set; }
    }

    public class Instance4
    {
        public string adjustedStart { get; set; }
        public string adjustedEnd { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Instance5
    {
        public string[] thumbnailsIds { get; set; }
        public string adjustedStart { get; set; }
        public string adjustedEnd { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Label1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string referenceId { get; set; }
        public string language { get; set; }
        public Instance6[] instances { get; set; }
    }

    public class Instance6
    {
        public float confidence { get; set; }
        public string adjustedStart { get; set; }
        public string adjustedEnd { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Scene
    {
        public int id { get; set; }
        public Instance7[] instances { get; set; }
    }

    public class Instance7
    {
        public string adjustedStart { get; set; }
        public string adjustedEnd { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Shot
    {
        public int id { get; set; }
        public Keyframe[] keyFrames { get; set; }
        public Instance9[] instances { get; set; }
        public string[] tags { get; set; }
    }

    public class Keyframe
    {
        public int id { get; set; }
        public Instance8[] instances { get; set; }
    }

    public class Instance8
    {
        public string thumbnailId { get; set; }
        public string adjustedStart { get; set; }
        public string adjustedEnd { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Instance9
    {
        public string adjustedStart { get; set; }
        public string adjustedEnd { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Brand1
    {
        public int id { get; set; }
        public string referenceType { get; set; }
        public string name { get; set; }
        public string referenceId { get; set; }
        public string referenceUrl { get; set; }
        public string description { get; set; }
        public object[] tags { get; set; }
        public int confidence { get; set; }
        public bool isCustom { get; set; }
        public Instance10[] instances { get; set; }
    }

    public class Instance10
    {
        public string brandType { get; set; }
        public string instanceSource { get; set; }
        public string adjustedStart { get; set; }
        public string adjustedEnd { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Audioeffect1
    {
        public int id { get; set; }
        public string type { get; set; }
        public Instance11[] instances { get; set; }
    }

    public class Instance11
    {
        public string adjustedStart { get; set; }
        public string adjustedEnd { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Sentiment1
    {
        public int id { get; set; }
        public float averageScore { get; set; }
        public string sentimentType { get; set; }
        public Instance12[] instances { get; set; }
    }

    public class Instance12
    {
        public string adjustedStart { get; set; }
        public string adjustedEnd { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Block
    {
        public int id { get; set; }
        public Instance13[] instances { get; set; }
    }

    public class Instance13
    {
        public string adjustedStart { get; set; }
        public string adjustedEnd { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Speaker
    {
        public int id { get; set; }
        public string name { get; set; }
        public Instance14[] instances { get; set; }
    }

    public class Instance14
    {
        public string adjustedStart { get; set; }
        public string adjustedEnd { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Videosrange
    {
        public string videoId { get; set; }
        public Range range { get; set; }
    }

    public class Range
    {
        public string start { get; set; }
        public string end { get; set; }
    }

}
