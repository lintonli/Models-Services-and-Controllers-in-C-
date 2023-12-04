using Assessment3.Models;
using Assessment3.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3.Controllers
{
    public  class ServiceController
    {
       
        Userservices userservices= new Userservices();
        Postsservices postservices= new Postsservices();
        Commentsservices commentservices= new Commentsservices();
 

        public async Task Initalize()
        {

            while (true)
            {


                Console.WriteLine("1. Display all Users");
                Console.WriteLine("2.  Select user and display User's Posts");
                Console.WriteLine("3. Select post and display comments");
                Console.WriteLine("4. Exit");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            await DisplayAllUsers();
                            break;
                        case 2:
                            await SelectUserandDisplayPosts();
                            break;
                        case 3:
                            await SelectPostandDisplayComments();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("invalid choice");
                            break;

                    }
                }
                else { Console.WriteLine("invalid option try again"); }
            }
        }
        public async Task DisplayAllUsers()
        {
            var users= await userservices.GetUsersasync();
            Console.WriteLine("Users:");
            foreach (var user in users)
            {
                Console.WriteLine($"user id: {user.Id} name:{user.name} username:{user.username}");
            }
        }
        public async Task SelectUserandDisplayPosts()
        {
            Console.WriteLine("Enter user ID");
            if (int.TryParse(Console.ReadLine(),out int userId))
            {
                var posts = await postservices.GetPostsbyuserid(userId);
                Console.WriteLine($"Posts for user ID{userId}:");
                foreach (var post in posts)
                {
                    Console.WriteLine($"POST ID:{post.id}, TITLE:{post.title}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        private async Task SelectPostandDisplayComments()
        {
            Console.WriteLine("Enter post ID:");
            if (int.TryParse(Console.ReadLine(), out int postId))
            {
                var comments = await commentservices.GetCommentsbyId(postId);
                Console.WriteLine($"Comments for Post ID {postId}:");
                foreach (var comment in comments)
                {
                    Console.WriteLine($"Comment ID: {comment.id}, Name: {comment.name}, Email: {comment.email}, Body: {comment.body}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }


    }
}
