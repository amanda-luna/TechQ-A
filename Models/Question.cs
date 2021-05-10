using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StackOverFlowProject.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int? UpVote { get; set; }
        public int? DownVote { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}