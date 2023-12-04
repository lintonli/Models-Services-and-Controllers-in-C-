using Assessment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3.services.IService
{
    public interface Iposts
    {
        Task<List<Posts>>GetallPostsAsync();
        Task<List<Posts>> GetPostsbyuserid(int userId );
    }
}
