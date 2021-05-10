using StackOverFlowProject.Models;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace StackOverFlowProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
          
        public ActionResult Index(int page = 1, string sortOrder = "date")
        {
            int questionsPerPage = 10;
            var questions_db = db.Questions;
            IQueryable<Question> questions;
                  
            if (sortOrder == "answers")
            {
                questions = questions_db.OrderByDescending(q => q.Answers.Count());
            }
            else
            {
               questions = questions_db.OrderByDescending(q => q.DateCreated);
            }

            return View(questions.ToPagedList(page, questionsPerPage));
        }
        public ActionResult TagsFiltered(string tag, int page = 1, string sortOrder = "date")
        {
            int questionsPerPage = 10;
            var questions_db = db.Questions.Where(q => q.Tags.Any(t => t.Title == tag));
            IQueryable<Question> questions;

            if (sortOrder == "answers")
            {
                questions = questions_db.OrderByDescending(q => q.Answers.Count());
            }
            else
            {
                questions = questions_db.OrderByDescending(q => q.DateCreated);
            }

            return View(questions.ToPagedList(page, questionsPerPage));
        }
    }
}