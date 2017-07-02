using System;
using System.Configuration;
using System.Data.SqlClient;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(ExpensesViewModel model)
        {
            if (!StringHelper.IsDecimal(model.Amount))
            {
                ViewBag.Errors = "Entered Amount is either 0 or not a integer.";
            }
            if (string.IsNullOrEmpty(model.Type))
            {
                ViewBag.Errors += " Expense Type is not selected";
            }
            else
            {
                var connectionString = ConfigurationManager.AppSettings.Get("SQLSERVER_CONNECTION_STRING");

                SqlConnection myConnection = new SqlConnection(connectionString);

                myConnection.Open();

             
                DateTime dateTime = DateTime.Today;

                string query = "INSERT INTO dbo.Expenses (Amount,Type,Date)VALUES (@Amount,@Type,@Date)";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.Parameters.Add("@Amount", model.Amount);
                myCommand.Parameters.Add("@Type", model.Type);
                myCommand.Parameters.Add("@Date", dateTime);

                myCommand.ExecuteNonQuery();

                //       myinfo.Text = "connection to db is made";
                myConnection.Close();
            }
            return View(model);
        }
    }
}