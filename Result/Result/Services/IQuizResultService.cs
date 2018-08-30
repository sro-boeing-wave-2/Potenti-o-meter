using Result.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Result.Services
{
    public interface IQuizResultService
    {
        Task<Quizes> AddQuiz(Quizes quiz);
        Task<Quizes> GetQuiz(int id);
    }
}
