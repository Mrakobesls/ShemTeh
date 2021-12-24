using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ShemTeh.App.Models.Pagination;
using ShemTeh.App.Models.Pagination.Test;
using ShemTeh.App.Models.Test;
using ShemTeh.Business.Models;
using ShemTeh.Business.Models.Independent;
using ShemTeh.Business.Servises;

namespace ShemTeh.App.Controllers
{
    public class TestController : Controller
    {
        private readonly PagerOptions _pagerOptions;
        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;
        private readonly IQuestionAnswerService _questionAnswerService;
        private readonly ITestAssigneeService _testAssigneeService;
        private readonly ITestResultService _testResultService;

        public TestController(ITestService testService,
            IQuestionService questionService,
            IQuestionAnswerService questionAnswerService,
            ITestAssigneeService testAssigneeService,
            ITestResultService testResultService,
            IOptions<PagerOptions> options)
        {
            _testService = testService;
            _questionService = questionService;
            _questionAnswerService = questionAnswerService;
            _testAssigneeService = testAssigneeService;
            _testResultService = testResultService;
            _pagerOptions = options.Value;
        }

        [HttpGet]
        [Authorize]
        public IActionResult PageTests(int page = 1)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
            var companiesCount = _testService.TestsCount(userId);
            var pager = new Pager(companiesCount, page, _pagerOptions.PageSize);
            var source = _testService.GetAllTestsPage(_pagerOptions.PageSize, page, userId)
                .Select(x => new TestInfoResponse
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            var viewModel = new TestsViewPage
            {
                Pager = pager,
                Tests = source
            };

            return View(viewModel);
        }

        #region Teacher


        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult CreateTest()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult CreateTest(CreateTestRequest model)
        {
            if (ModelState.IsValid)
            {
                if (_testService.ReadByName(model.Name) is null)
                {
                    int userId = Int32.Parse(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
                    int testId = _testService.Add(new TestDto()
                    {
                        Name = model.Name,
                        TestOwnerId= userId
                    });

                    return RedirectToAction("EditTest", "Test", new { testId = testId });
                }
                ModelState.AddModelError("", "Тест с таким названием уже существует");
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult EditTest(int testId)
        {
            var testInfo = _testService.Read(testId);
            var questions = _questionService.ReadAllByTestId(testId);

            var editTestRequest = new EditTestRequest
            {
                Test = testInfo,
                Questions = questions
            };

            return View(editTestRequest);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult EditTest(EditTestRequest model)
        {
            if (ModelState.IsValid)
            {
                var testByName = _testService.ReadByName(model.Test.Name);

                if (testByName is null || testByName.Id == model.Test.Id)
                {
                    _testService.Update(model.Test);

                    return EditTest(model.Test.Id);
                }
                ModelState.AddModelError("", "Тест с таким названием уже существует");
            }

            return EditTest(model.Test.Id);
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult CreateQuestion()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult CreateQuestion(CreateQuestionRequest model, [FromRoute] int id)
        {
            model.TestId = id;
            if (ModelState.IsValid)
            {
                int questionId = _questionService.Add(new QuestionDto()
                {
                    Name = model.Name,
                    TestId = id
                });

                return RedirectToAction("EditQuestion", "Test", new { questionId = questionId });
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult EditQuestion(int questionId, int newRows = 0)
        {
            var questionInfo = _questionService.Read(questionId);
            var answers = _questionAnswerService.ReadAllByQuestionId(questionId);
            while (answers.Count < newRows)
            {
                answers.Add(new QuestionAnswerDto
                {
                    QuestionId = questionId
                });
            }

            var editQuestionRequest = new EditQuestionRequest
            {
                Question = questionInfo,
                Answers = answers
            };

            return View(editQuestionRequest);
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult EditQuestionAfterAdding(EditQuestionRequest model, int newRows = 0)
        {
            while (model.Answers.Count < newRows)
            {
                model.Answers.Add(new QuestionAnswerDto
                {
                    QuestionId = model.Question.Id
                });
            }

            return View("EditQuestion", model);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult EditQuestion(EditQuestionRequest model)
        {
            if (ModelState.IsValid)
            {
                _questionService.Update(model.Question);

                foreach (var answer in model.Answers)
                {
                    if (answer.Name is not null)
                    {
                        if (answer.Id == 0)
                        {
                            answer.Id = _questionAnswerService.Add(answer);
                        }
                        else
                        {
                            _questionAnswerService.Update(answer);
                        }
                    }
                }

                return EditQuestion(model.Question.Id);
            }

            return EditQuestion(model.Question.Id);
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult TestAssignees(int testid)
        {
            var model = _testService.GetTestAssignees(testid);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult TestAssignees(Business.Models.Independent.TestAssignees model)
        {
            if (ModelState.IsValid)
            {
                foreach (var assignee in model.Assignees)
                {
                    if (assignee.IsAssigned)
                    {
                        if (_testAssigneeService.Read(model.TestId, assignee.UserId) is null)
                        {
                            _testAssigneeService.Add(new TestAssigneeDto
                            {
                                TestId = model.TestId,
                                UserId = assignee.UserId,
                                PossibleAttempts = 1,
                                CurrentAttempts = 0
                            });
                        }
                    }
                    else
                    {
                        if (_testAssigneeService.Read(model.TestId, assignee.UserId) is not null)
                        {
                            _testAssigneeService.Delete(model.TestId, assignee.UserId);
                        }
                    }

                }

                return TestAssignees(model.TestId);
            }

            return TestAssignees(model.TestId);
        }



        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult TestResults(int testid)
        {
            var model = _testService.GetTestResults(testid);

            return View(model);
        }
        #endregion

        #region Student

        //not implemented
        [HttpGet]
        [Authorize(Roles = "Student")]
        public IActionResult StudentPageTests(int page = 1)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
            var source = _testService.StudentTests(userId)
                .Select(x => new TestInfoResponse
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            return View(source);
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public IActionResult MyTests()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
            //TODO get questions
            //new method for get user tests 
            var source = new TestsResponse()
            {
                Tests = _testService.StudentTests(userId)
                    .Select(x => new TestInfoResponse
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList()
            };

            return View(source);
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public IActionResult PassTest(int testId)
        {
            var getTest = _testService.GetTestToPass(testId);

            return View(getTest);
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public IActionResult PassTest(TestToPass testToPass)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.First(c => c.Type == "Id").Value);
            double finalScore = 0;
            foreach (var question in testToPass.Questions)
            {
                double questionScore = 0;
                int correctAnswerCount = _questionService.GetCorrectAnswersCount(question.QuestionId);
                int incorrectAnswerCount = _questionService.GetIncorrectAnswersCount(question.QuestionId);
                foreach (var answer in question.QuestionAnswers)
                {
                    bool expectedValue = _questionAnswerService.Read(answer.QuestionAnswerId).IsCorrect;
                    if (expectedValue)
                    {
                        if (answer.IsCorrect)
                            questionScore += 1.0 / correctAnswerCount;
                        //else
                        //    questionScore -= 1.0 / correctAnswerCount;
                    }
                    else
                    {
                        if (answer.IsCorrect)
                            questionScore -= 1.0 / incorrectAnswerCount;
                    }
                }
                if (questionScore <= 0)
                {
                    questionScore = 0;
                }
                finalScore += questionScore;
            }

            finalScore /= testToPass.Questions.Count();

            _testResultService.Add(new TestResultDto
            {
                TestId = testToPass.TestId,
                UserId = userId,
                AttemptNumber = 1,
                CorrectAnswersPercent = finalScore,
                DateTimeUtc = DateTime.UtcNow
            });

            var testAssignee = _testAssigneeService.Read(testToPass.TestId, userId);
            testAssignee.CurrentAttempts += 1;
            _testAssigneeService.Update(testAssignee);

            var model = new TestResultResponse()
            {
                TestName = _testService.Read(testToPass.TestId).Name,
                Percentage = (int)(finalScore * 100)
            };

            return View("TestResult", model);
        }

        #endregion
    }
}
