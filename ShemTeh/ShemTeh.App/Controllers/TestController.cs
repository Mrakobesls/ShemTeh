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

        public TestController(ITestService testService,
            IQuestionService questionService,
            IQuestionAnswerService questionAnswerService,
            ITestAssigneeService testAssigneeService,
            IOptions<PagerOptions> options)
        {
            _testService = testService;
            _questionService = questionService;
            _questionAnswerService = questionAnswerService;
            _testAssigneeService = testAssigneeService;
            _pagerOptions = options.Value;
        }

        [HttpGet]
        public IActionResult PageTests(int page = 1)
        {
            var companiesCount = _testService.TestsCount();
            var pager = new Pager(companiesCount, page, _pagerOptions.PageSize);
            var source = _testService.GetAllTestsPage(_pagerOptions.PageSize, page)
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
        public IActionResult CreateTest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTest(CreateTestRequest model)
        {
            if (ModelState.IsValid)
            {
                if (_testService.ReadByName(model.Name) is null)
                {
                    int testId = _testService.Add(new TestDto()
                    {
                        Name = model.Name
                    });

                    return RedirectToAction("EditTest", "Test", new { testId = testId });
                }
                ModelState.AddModelError("", "Тест с таким названием уже существует");
            }

            return View(model);
        }

        [HttpGet]
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
        public IActionResult EditTest(EditTestRequest model)
        {
            if (ModelState.IsValid)
            {
                var companyByName = _testService.ReadByName(model.Test.Name);

                if (companyByName is null || companyByName.Id == model.Test.Id)
                {
                    _testService.Update(model.Test);

                    return EditTest(model.Test.Id);
                }
                ModelState.AddModelError("", "Тест с таким названием уже существует");
            }

            return EditTest(model.Test.Id);
        }

        [HttpGet]
        public IActionResult CreateQuestion()
        {
            return View();
        }

        [HttpPost]
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
                            _questionAnswerService.Add(answer);
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
        public IActionResult TestAssignees(int testid)
        {
            var model = _testService.GetTestAssignees(testid);

            return View(model);
        }

        [HttpPost]
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
        public IActionResult TestResults(int testid)
        {
            var model = _testService.GetTestResults(testid);

            return View(model);
        }
        #endregion

        #region Student

        [HttpGet]
        public IActionResult StudentPageTests(int page = 1)
        {
            var companiesCount = _testService.TestsCount();
            var pager = new Pager(companiesCount, page, _pagerOptions.PageSize);
            var source = _testService.GetAllTestsPage(_pagerOptions.PageSize, page)
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

        [HttpGet]
        public IActionResult MyTests(int studentId)
        {
            //TODO get questions
            //new method for get user tests 
            var tests = _testService.StudentTests(studentId);

            return View();
        }

        [HttpGet]
        public IActionResult PassTest(int testId)
        {
            var getTest = _testService.GetTestToPass(testId);

            return View(getTest);
        }

        [HttpPost]
        public IActionResult PassTest(TestToPass testToPass)
        {
            double finalScore = 0;
            foreach (var question in testToPass.Questions)
            {
                int questionScore = 0;
                foreach (var answer in question.QuestionAnswers)
                {
                    bool expectedValue = _questionAnswerService.Read(answer.QuestionAnswerId).IsCorrect;
                    if (expectedValue)
                    {
                        if (answer.IsCorrect)
                            questionScore++;
                        else
                            questionScore--;
                    }
                    else
                    {
                        if (answer.IsCorrect)
                            questionScore--;
                    }
                }
                if (questionScore <= 0)
                {
                    questionScore = 0;
                }
                int correctAnswerCount = _questionService.GetCorrectAnswersCount(question.QuestionId);
                if (correctAnswerCount > 0)
                    finalScore += (double)questionScore / correctAnswerCount;
            }



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
