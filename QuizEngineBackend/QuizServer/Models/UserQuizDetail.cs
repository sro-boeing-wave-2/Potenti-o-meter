using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizServer.Models
{
    public class UserQuizDetail
    {
        public int userId { get; set; }
        public string domain { get; set; }
        public List<QuestionAttempted> questionsAttempted { get; set; }
    }

    
}
