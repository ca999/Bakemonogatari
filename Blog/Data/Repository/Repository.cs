using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Controllers;
namespace Blog.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDBContext _ctx;
        public Repository(AppDBContext ctx)
        {
            _ctx = ctx;
        }

        public void AddPost(Post post)
        {
            _ctx.Posts.Add(post);
           
        }

        public List<Post> GetAllPost()
        {
            return _ctx.Posts.ToList();
        }

        public Post GetPost(int id)
        {
            return _ctx.Posts.FirstOrDefault( p => p.Id == id );
        }

        public void RemovePost(int id)
        {
            _ctx.Posts.Remove(GetPost(id));
        }

        

        public void UpdatePost(Post post)
        {

            _ctx.Posts.Update(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Post> GetAllGS()
        {
            return _ctx.Posts.ToList().FindAll(p => p.Tag == "GS");
        }

        public List<Post> GetAllUE()
        {
            return _ctx.Posts.ToList().FindAll(p => p.Tag == "UE");
        }

        public List<Post> GetAllGM()
        {
            return _ctx.Posts.ToList().FindAll(p => p.Tag == "GM");
        }
    }
}
