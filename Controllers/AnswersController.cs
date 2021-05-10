using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using StackOverFlowProject.Models;

namespace StackOverFlowProject.Controllers
{
    public class AnswersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Create(int questionId)
        {
            ViewData["questionId"] = questionId;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,IsValid,UserId,QuestionId")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                answer.UserId = User.Identity.GetUserId();
                answer.UpVote = 0;
                answer.DownVote = 0;
                answer.IsValid = false;

                db.Answers.Add(answer);
                db.SaveChanges();
                
                return RedirectToAction("Details", "Questions", new { id = answer.QuestionId });
            }

            return View(answer);
        }

        public ActionResult UpVote(int answerId, int questionId)
        {
            var answer = db.Answers.Find(answerId);
            string userId = User.Identity.GetUserId();

            if (userId != answer.UserId)
            {
                answer.UpVote += 1;
                var user = db.Users.Find(answer.UserId);
                user.ReputationLevel += 5;

                db.SaveChanges();
            }
            return RedirectToAction("Details", "Questions", new { id = questionId });
        }

        public ActionResult DownVote(int answerId, int questionId)
        {
            var answer = db.Answers.Find(answerId);
            string userId = User.Identity.GetUserId();

            if (userId != answer.UserId)
            {
                answer.DownVote += 1;
                var user = db.Users.Find(answer.UserId);
                user.ReputationLevel -= 5;

                db.SaveChanges();
            }
            return RedirectToAction("Details", "Questions", new { id = questionId });
        }

        public ActionResult AnswerAccepted(int answerId, int questionId)
        {
            var question = db.Questions.Find(questionId);
            string userId = User.Identity.GetUserId();

            if(userId == question.UserId)
            {
                var validAnswers = db.Answers.Where(a => a.IsValid == true && a.QuestionId == questionId);
                foreach (Answer item in validAnswers)
                {
                    item.IsValid = false;
                }
                db.SaveChanges();

                var answer = db.Answers.Find(answerId);
                answer.IsValid = true;
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
