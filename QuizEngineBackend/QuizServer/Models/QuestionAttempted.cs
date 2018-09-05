using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizServer.Models
{
    public class QuestionAttempted
    {
        
            public int QuestionId { get; set; }
            public string QuestionText { get; set; }
            public int difficultyLevel { get; set; }
            public string response { get; set; }
            public string userResponse { get; set; }
            public bool isCorrect { get; set; }
            public string[] conceptTags { get; set; }
        
    }
}
