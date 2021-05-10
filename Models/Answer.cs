using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace StackOverFlowProject.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public bool IsValid { get; set; }
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public int? UpVote { get; set; }
        public int? DownVote { get; set; }
        public ApplicationUser User { get; set; }

    }
}