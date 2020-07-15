using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using System.ServiceModel.Syndication;
using Helloworld;
namespace GrpcRssReader.Library
{
    class RssItem
    {
        string url;
        string subject;
        string summary;
        string topic;
        string site;
        DateTime date;
        string id;
        public RssItem(SyndicationItem item) {
            url = item.BaseUri.ToString();
            summary = item.Summary.Text;
            subject = item.Title.Text;
            date = item.PublishDate.DateTime;
            id = item.Id;
            site = GetSiteName(item.BaseUri.ToString());
        }
        public RssItem(NewsReply newsReply)
        {
            url = newsReply.Url;
            summary = newsReply.Summary;
            subject = newsReply.Subject;
            date = DateTime.Parse(newsReply.Date);
            id = newsReply.Id;
            site = GetSiteName(newsReply.Site);
        }
        public string GetSiteName(string uri)
        {
            //извлекаем название с сайта из uri
            return uri;
        }
        public SyndicationItem ToSyndicationItem()
        {
            return new SyndicationItem(subject, summary, new Uri(url), id, date);
        }
        public static SyndicationItem FromGrpcNewsItem(NewsReply newsReply)
        {
            return new SyndicationItem(newsReply.Subject, newsReply.Summary, new Uri(newsReply.Url), newsReply.Id, DateTime.Parse(newsReply.Date));
        }
    }
}
