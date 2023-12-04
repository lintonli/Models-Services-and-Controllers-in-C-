using Assessment3.Models;
using Assessment3.services.IService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Assessment3.services
{
    public class Postsservices:Iposts
    {
        private readonly HttpClient _httpClient;
        private readonly string _URL = "https://jsonplaceholder.typicode.com/posts";
        public Postsservices()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Posts>> GetallPostsAsync()
        {
            var response= await _httpClient.GetAsync(_URL);
            var content=  await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<List<Posts>>(content);
            if (response.IsSuccessStatusCode)
            {
                return posts;
            }
            else
            {
                return new List<Posts>();
            }
        }

        public async Task<List<Posts>> GetPostsbyuserid(int userId)
        {
            var response = await _httpClient.GetAsync($"{_URL}/?userId={userId}");
            var content= await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<List<Posts>>(content) ;
            if (response.IsSuccessStatusCode)
            {
                return posts;
            }
            else
            {
                return new List<Posts>();
            }

        }
    }
    
}
