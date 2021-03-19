using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Newsapi.Models
{
    public class NewsJSON
    {
        public async static Task<Root> GetNews(string url)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(Root));
            var dataStream = new MemoryStream(Encoding.UTF8.GetBytes(result));

            var value = serializer.ReadObject(dataStream) as Root;

            return value;
        }

    }

    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarPath { get; set; }

    }
    public class Source
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Article
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarPath { get; set; }
        public Source source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public string publishedAt { get; set; }
        public string content { get; set; }
    }

    public class Root
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles { get; set; }
    }

    
}
