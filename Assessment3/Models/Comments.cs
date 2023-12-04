using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3.Models
{
   /* 
    "postId": 1,
    "id": 1,
    "name*/
    public class Comments
    {
        public int postId {  get; set; }
        public int id { get; set; }
        public string name { get; set; }=string.Empty;
        public string email {  get; set; }=string.Empty;
        public string body {  get; set; }=string.Empty;
    }
}
