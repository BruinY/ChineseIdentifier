using ChineseIdentifier.TestHarness.Models;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace ChineseIdentifier.TestHarness.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index(string cc)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(cc);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(cc);

            var viewModel = new TestViewModel
            {
                Title = Resources.Global.Title,
                Content = Resources.Global.Content
            };

            return View(viewModel);
        }
    }
}