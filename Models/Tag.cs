using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverFlowProject.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}