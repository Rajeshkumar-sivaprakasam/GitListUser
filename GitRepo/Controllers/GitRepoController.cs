using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using GitRepo.Models;
namespace GitRepo.Controllers
{
    public class GitRepoController : Controller
    {
        // GET: GitRepo
        public ActionResult GitRepo()
    {
            //var uri = new Uri("https://api.github.com/users");
            //var request = (HttpWebRequest)WebRequest.Create(uri);

            ////Credential added 
            //request.Credentials = CredentialCache.DefaultCredentials;

            //request.KeepAlive = false;
            //request.ProtocolVersion = HttpVersion.Version10;
            //request.Timeout = System.Threading.Timeout.Infinite;
            //request.Method = @"POST";
            //request.ContentType = @"application/x-www-form-urlencoded";
            //request.UserAgent = @"Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.1.4322)";
            //request.Accept = "*/*";

            ////setup the stream variables and do the send/retrieve of data
            //Stream writeStream = request.GetRequestStream();
            //var bytes = System.Text.Encoding.ASCII.GetBytes(postData);
            //writeStream.Write(bytes, 0, bytes.Length);
            //writeStream.Close();

            //var response = (HttpWebResponse)(request.GetResponse());
            //var responseStream = response.GetResponseStream();
            //var readStream = new StreamReader(responseStream, Encoding.UTF8);
            //pageResponse = readStream.ReadToEnd();
            //return View();

            //var url = "https://api.github.com/users";
            //var request = (HttpWebRequest)WebRequest.Create(url);

            //////Credential added 
            //request.Credentials = CredentialCache.DefaultCredentials;

            //using (var webClient = new WebClient())
            //{
            //    string rawJSON = webClient.DownloadString(url);
            //    //Git rep = JsonConvert.DeserializeObject<Git>(rawJSON);

            //    //return View(rep);
            //}

            //Navigate to front page to Set cookies
            //var uri = new Uri("https://api.github.com/users");
            //var request = (HttpWebRequest)WebRequest.Create(uri);

            //Dictionary<string,string> OLinks = new Dictionary<string, List<string>>();

            string Url = "https://api.github.com/users";
            //string Url = "https://api.github.com/users/{myuser}/repos";
            CookieContainer cookieJar = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.CookieContainer = cookieJar;
            request.UseDefaultCredentials = true;
            request.UserAgent = "Foo";
            request.Accept = "application/json";
            request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            String htmlString;
            IList<GitRepoClass> rep = null;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                htmlString = reader.ReadToEnd();
                rep = JsonConvert.DeserializeObject<List<GitRepoClass>>(htmlString);
            }

            return View(rep);

        }
    }
}