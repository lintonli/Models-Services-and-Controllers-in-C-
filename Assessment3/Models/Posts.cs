using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3.Models
{
   /* "userId": 1,
    "id": 1,
    "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
    "body":*/
    public class Posts
    {
        public int userId { get; set; }
        public int id {  get; set; }
        public string title { get; set; } = string.Empty;
        public string body { get; set; } = string.Empty;
    }
}
