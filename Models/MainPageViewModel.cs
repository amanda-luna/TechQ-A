using System;

namespace StackOverFlowProject.Models
{
    public class MainPageViewModel
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public int? UpVote { get; set; }
        public int? DownVote { get; set; }
        public int? AmountAnswers { get; set; }
        public int QuestionPerPage { get; set; }
        public int CurrentPage { get; set; }

    }
}