using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminAlert.AppLogic
{
    public class MailgunClient
    {
        public string MailgunDomain { get; set; }
        public string MailgunApiKey { get; set; }

        public RestResponse SendMessage(string sendTo, string customer, string details, string contents)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator = new HttpBasicAuthenticator("api", MailgunApiKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", MailgunDomain, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", String.Format("Admin Alert <postmaster@{0}>", MailgunDomain));
            request.AddParameter("to", String.Format("<{0}>", sendTo));
            request.AddParameter("subject", String.Format("{0} - {1}", customer, details));
            request.AddParameter("text", contents);
            request.Method = Method.POST;
            return (RestResponse)client.Execute(request);
        }
    }
}
