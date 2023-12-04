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
    public class Userservices : IUsers
       
    {
        private readonly HttpClient httpClient;
        private readonly String _URL = "https://jsonplaceholder.typicode.com/users ";
         public Userservices()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Users>> GetUsersasync()
        {
            var response =await httpClient.GetAsync(_URL);
            var content = await response.Content.ReadAsStringAsync();
            var users=JsonConvert.DeserializeObject<List<Users>>(content);
            if (response.IsSuccessStatusCode && users != null)
            {
                return users;
            }
            else
            {
                return new List<Users>();
            }
        }

        public async Task<Users> GetUsersbyId(int id)
        {
           var response = await httpClient.GetAsync($"_URL id{id}");
            var content=await response.Content.ReadAsStringAsync();
            var users= JsonConvert.DeserializeObject<Users>(content);
            if (response.IsSuccessStatusCode)
            {
                return users;

            }
            else
            {
                return new Users ();
            }


        }
    }
   
}
