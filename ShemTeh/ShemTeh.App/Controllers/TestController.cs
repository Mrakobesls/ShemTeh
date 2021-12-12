using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ShemTeh.App.Models.Pagination;
using ShemTeh.App.Models.Pagination.Test;
using ShemTeh.App.Models.Test;
using ShemTeh.Business.Servises;

namespace ShemTeh.App.Controllers
{
    public class TestController : Controller
    {
        private readonly PagerOptions _pagerOptions;
        public ITestService _testService { get; set; }

        public TestController(ITestService testService, IOptions<PagerOptions> options)
        {
            _testService = testService;
            _pagerOptions = options.Value;
        }

        [HttpGet]
        public IActionResult PageTests(int page = 1)
        {
            var companiesCount = _testService.TestsCount();
            var pager = new Pager(companiesCount, page, _pagerOptions.PageSize);
            var source = _testService.GetAllTestsPage(_pagerOptions.PageSize, page)
                .Select(x => new TestInfo
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
    }
}
