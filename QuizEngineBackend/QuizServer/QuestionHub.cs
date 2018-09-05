using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using QuizServer.Models;
namespace QuizServer
{
    public class QuestionHub : Hub
    {
        private readonly static ConnectionMapping _connections =
            new ConnectionMapping ();


        //public  Dictionary<int, Dictionary<string, List<string>>> dict = new Dictionary<int, Dictionary<string, List<string>>>();
        //Api call
        //get the list of quetions for a particular domain
        public static int count = 0;
        List<Question> Questions = new List<Question>()
        {
            new Question() {
            QuestionId = 1,
            QuestionText = "Who is the CM of WestBengal?",
            Options = new List<string>()
                {
                        "Siddu",

                         "Didi",

                    
                        "Modi",

                         "RaGa"
                }
         },
                
        
        new Question()
        {
            QuestionId = 2,
            QuestionText = "Who is the CM of Karnataka?",
                      Options = new List<string>()
                {
                        "deepu",

                         "shashaidar",

                    
                        "Deepika",

                         "deepthi"
                }
         },
            
           new Question()
        {
            QuestionId = 3,
            QuestionText = "Who is the CM of Kerala?",
            Options = new List<string>()
                {
                        "Siddu",

                         "Didi",

                    
                        "Modi",

                         "RaGa"
                }
         },
        new Question()
        {
            QuestionId = 4,
            QuestionText = "Who is the best ----- developer in stack route?",
            Options = new List<string>()
                {
                        "deepu",

                         "deepu",

                    
                        "deepu",

                         "FE"
                }
        }
         
        };

        // public Task StoreResponse()
        // {

        // }

        // Emit's Next Question from the collection of Questions
        public Task GetNextQuestion()
        {
            if (count < Questions.Count) 
            {
                Question question = Questions[count];
                QuestionAttempted q = new QuestionAttempted();
                //q.difficultyLevel = 
                count++;
                // string q = question.QuestionText;
                return Clients.Caller.SendAsync("NextQuestion", question);
            }
            else
                return Clients.Caller.SendAsync("EndOfQuestions");
        }


        public override Task OnConnectedAsync()
        {

            Console.WriteLine("Client Connected");
            Console.WriteLine("count before is " + count);
            Console.WriteLine("count is " + count);
            //string name = Context.User.Identity.Name;

           // OnConnectionMapping

           // _connections.Add(userId, Context.ConnectionId);

            //return base.OnConnected();

           // _connections.Add(userId, connectionId);
            //return GetNextQuestion(user1);
            return GetNextQuestion();
            
        }
        public Task OnConnectionMapping(int userId)
        {
            _connections.Add(userId, Context.ConnectionId);
            return  base.OnConnectedAsync() ;
        }

        public Task send(string response, string userId)
        {
            Console.WriteLine(response);
            return Clients.Caller.SendAsync("SendResponse", response);

        }

    }
}
