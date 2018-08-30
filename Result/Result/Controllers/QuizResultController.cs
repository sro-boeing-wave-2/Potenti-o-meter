using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Result.Models;
using Result.Services;

namespace Result.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizResultController : Controller
    {
        private readonly IQuizResultService _quizResultService;

        public QuizResultController(IQuizResultService quizResultService)
        {
            _quizResultService = quizResultService;
        }


        [HttpPost]
        public async Task<IActionResult> PostQuiz([FromBody] Quizes quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _quizResultService.AddQuiz(quiz);


            return Ok();
        }
        
    }
}