using BlogASP.Models;
using PagedList;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BlogASP.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        const int pageSize = 5;

        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            return View(db.Post.OrderBy(p => p.Id).ToPagedList(pageNumber, pageSize));
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
            return View("Index", tag.Posts.ToPagedList(1, pageSize));
        }
    }
}