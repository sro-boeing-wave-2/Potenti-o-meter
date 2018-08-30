using Result.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Result.Services
{
    interface IQuizResultService
    {
        Task<Quizes> AddQuiz(Quizes quiz);
        
    }
}
