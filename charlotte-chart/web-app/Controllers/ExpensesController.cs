using System.Web.Mvc;
using web_app.Helpers;
using web_app.Models;

namespace web_app.Controllers
{
    public class ExpensesController : Controller
    {
        // GET: Expenses
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(ExpensesViewModel model)
        {
            if (!StringHelper.IsDecimal(model.Amount))
            {
                ViewBag.Errors = "Entered Amount is either 0 or not a integer";
            }
            return View(model);
        }
    }
}