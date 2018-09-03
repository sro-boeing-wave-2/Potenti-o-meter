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

        public async Task<Quiz> AddQuiz(Quiz quiz)
        {
            await _context.Quiz.InsertOneAsync(quiz);

            //Perform calculating tasks on the UserResults Collection
            int userId = quiz.UserId;
            UpdateUserResults(quiz);
            return quiz;
        }


        public async Task<UserResult> GetUserResults(int userId, string domainName)
        {
            return await _context.userResult.Find(entry => entry.UserId == userId && entry.DomainName==domainName).FirstOrDefaultAsync();
        }
        
        

        public async void UpdateUserResults(Quiz quiz)
        {
<<<<<<< Updated upstream
            return await _context.UserResults.Find(entry => entry.UserId == userId).FirstOrDefaultAsync();
=======
            int userId = quiz.UserId;
            double newScore = quiz.Score;
            string domainName = quiz.DomainName;
           
            var userResultsEntry = await _context.userResult.Find(entryy => entryy.UserId.Equals(userId) && entryy.DomainName.Equals(domainName)).FirstOrDefaultAsync();

            if (userResultsEntry == null)
            {
                List<double> scores = new List<double>();
                scores.Add(newScore);
                UserResult userResults = new UserResult()
                {
                    UserId = userId,
                    DomainName = quiz.DomainName,
                    AverageScore = quiz.Score,
                    Scores = scores,
                    
                };
                await _context.userResult.InsertOneAsync(userResults);
            }
            else
            {
                double averageScore = userResultsEntry.AverageScore;
                
                List<double> scores = userResultsEntry.Scores;
                

                int numOfEntry = scores.Count;
                double totalScore = numOfEntry * averageScore;
                double updatedScore = totalScore + newScore;
                updatedScore = updatedScore / (numOfEntry+1);
                scores.Add(newScore);
                var filter = Builders<UserResult>.Filter.Eq(x => x.UserId, userId);
                filter = filter & (Builders<UserResult>.Filter.Eq(x => x.DomainName, domainName));
                var update = Builders<UserResult>.Update.Set(x => x.AverageScore, updatedScore).Set(x => x.Scores, scores);
                var result = await _context.userResult.UpdateOneAsync(filter, update);
            }
>>>>>>> Stashed changes
        }



        
    }
}
