using Assessment3.Models;
using Assessment3.services.IService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3.services
{
    public class Commentsservices:IComments
    {
        private readonly HttpClient _httpClient;
        private readonly string _URL = "https://jsonplaceholder.typicode.com/comments";

        public Commentsservices()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Comments>> GetCommentsallAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_URL);
                var content = await response.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<List<Comments>>(content);
                if (response.IsSuccessStatusCode)
                {
                    return comments;
                }
                else
                {
                    return new List<Comments>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Comments>();
            }
        }

        public async Task<List<Comments>> GetCommentsbyId(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_URL}/?postId={id}");
                var content = await response.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<List<Comments>>(content);
                if (response.IsSuccessStatusCode)
                {
                    return comments;
                }
                else
                {
                    return new  List<Comments>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Comments>();
            }

        }
    }
}
