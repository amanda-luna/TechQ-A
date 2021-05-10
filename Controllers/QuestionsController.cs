using System;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using StackOverFlowProject.Models;

namespace StackOverFlowProject.Controllers
{
    public class QuestionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }
        
        [Authorize]
        public ActionResult Create()
        {
            Question question = new Question();
            ICollection<Tag> tag = new List<Tag>();
            var tags = db.Tag;

            foreach(Tag t in tags)
            {
                tag.Add(t);
            }

            question.Tags = tag;

            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description")] Question question)
        {
            if (ModelState.IsValid)
            {
                question.UserId = User.Identity.GetUserId();
                question.DateCreated = DateTime.Now;
                question.UpVote = 0;
                question.DownVote = 0;

                db.Questions.Add(question);
                db.SaveChanges();
                
                return RedirectToAction("Index", "Home");
            }
            

            return View(question);
        }
        public ActionResult UpVote(int questionId)
        {
            var question = db.Questions.Find(questionId);
            string userId = User.Identity.GetUserId();

            if (userId != question.User.Id)
            {
                question.UpVote += 1;
                question.User.ReputationLevel += 5;

                db.SaveChanges();
            }
            return RedirectToAction("Details", "Questions", new { id = questionId });
        }
        public ActionResult DownVote(int questionId)
        {
            var question = db.Questions.Find(questionId);
            string userId = User.Identity.GetUserId();

            if (userId != question.User.Id)
            {
                question.DownVote += 1;
                question.User.ReputationLevel -= 5;
                db.SaveChanges();
            }
               
            return RedirectToAction("Details", "Questions", new { id = questionId });
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
