using Blog.Data.FileManager;
using Blog.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class GSController: Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public GSController ( IRepository repo , IFileManager fileManager )
        {
            _repo = repo;
            _fileManager = fileManager;
        }
        public IActionResult Index ()
        {
            var post = _repo.GetAllGS();
            return View(post);
        }

        public IActionResult Post( int id )
        {
            var post = _repo.GetPost(id);
            return View(post);
        }

        [HttpGet("/ImageGS/{image}")]
        public IActionResult ImageGS(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);

            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }




    }
}
