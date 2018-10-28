using BlogASP.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BlogASP.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Post
        public ActionResult Index()
        {
            return View(db.Post.ToList());
        }

        // GET: Post/Details/5
        public ActionResult Details(int? id)
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
            return View(post);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            //ViewBag.Tags = new MultiSelectList(db.Tag, "Id", "Title");
            var tags = db.Tag.Select(tag => new
            {
                Id = tag.Id,
                Title = tag.Title
            }).ToList();
            string[] statuses = { "Published", "Draft" };
            ViewBag.Tags = new MultiSelectList(tags, "Id", "Title");
            ViewBag.Statuses = new SelectList(statuses);
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Title,Content,Tags,Status,Created_at,Updated_at")] Post post, int[] selectedTags)
        {
            if (ModelState.IsValid)
            {
                post.UserId = User.Identity.GetUserId();
                post.Updated_at = DateTime.Now.ToString();
                post.Created_at = DateTime.Now.ToString();

                if (selectedTags != null)
                {
                    foreach (var tag in db.Tag.Where(t => selectedTags.Contains(t.Id)))
                    {
                        post.Tags.Add(tag);
                    }
                }

                db.Post.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
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
            var tags = db.Tag.Select(tag => new
            {
                Id = tag.Id,
                Title = tag.Title
            }).ToList();
            
            ViewBag.Tags = new MultiSelectList(tags, "Id", "Title");
            string[] statuses = { "Published", "Draft" };
            ViewBag.Statuses = new SelectList(statuses);
            return View(post);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,Tags,Status,Created_at,Updated_at")] Post post, int[] selectedTags)
        {
            if (ModelState.IsValid)
            {

                post.Updated_at = DateTime.Now.ToString();
                post.Tags.Clear();
                if (selectedTags != null)
                {
                    foreach (var tag in db.Tag.Where(t => selectedTags.Contains(t.Id)))
                    {
                        post.Tags.Add(tag);
                    }
                }

                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id)
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
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Post.Find(id);
            db.Post.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
