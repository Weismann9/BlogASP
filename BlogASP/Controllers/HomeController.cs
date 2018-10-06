using BlogASP.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BlogASP.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var posts = db.Post.ToList();
            return View(posts);
        }

        // GET: Post/Details/5
        [HttpGet]
        public ActionResult Display(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            ViewBag.Comment = new Comment()
            {
                PostId = post.Id,
                Created_at = DateTime.Now.ToString()
            };

            post.Comments = db.Comment.Where(c => c.PostId == post.Id).ToList();
            return View(post);
        }

        [HttpPost]
        public ActionResult CreateComment(Comment comment)
        {
            db.Comment.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Display", new { id = comment.PostId });
        }

        public ActionResult TagFilter(int tagId)
        {
            Tag tag = db.Tag.Find(tagId);
            ViewBag.Title = "Пости із тегом " + tag.Title;
            return View("Index", tag.Posts.ToList());
        }
    }
}