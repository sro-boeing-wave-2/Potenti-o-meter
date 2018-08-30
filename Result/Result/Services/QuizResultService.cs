using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Result.Data;
using Result.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Result.Services
{
    public class QuizResultService : IQuizResultService
    {

        private readonly QuizContext _context = null; 
 
        public QuizResultService(IOptions<Settings> settings)
        {
            _context = new QuizContext(settings);
        }

        public async Task<Quizes> AddQuiz(Quizes quiz)
        {
            await _context.Quizes.InsertOneAsync(quiz);

            return quiz;
        }

        public async Task<UserResults> GetUserResults(int userId)
        {
            return await _context.UserResults.Find(entry => entry.UserId == userId).FirstOrDefaultAsync();
        }

        
    }
}
