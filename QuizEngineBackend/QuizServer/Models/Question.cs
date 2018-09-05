using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizServer.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public string QuestionType { get; set; }
        //public string[] ConceptTags { get; set; }
        public string response { get; set; }
    }

    
}
