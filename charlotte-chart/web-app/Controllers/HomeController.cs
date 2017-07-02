using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web_app.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var connectionString = ConfigurationManager.AppSettings.Get("SQLSERVER_CONNECTION_STRING");

            SqlConnection myConnection = new SqlConnection(connectionString);

            List<ExpensesEntity> expensesEntities = new List<ExpensesEntity>();
            IDictionary<string,decimal> expenses = new ConcurrentDictionary<string, decimal>();
            int month = DateTime.Today.Month;
            int year = DateTime.Today.Year;

            string startDate = new DateTime(year, month, 1).ToShortDateString();
            string endDate = new DateTime(year, month, 31).ToShortDateString();
            myConnection.Open();

            string query = "SELECT Amount,Type FROM [dbo].[Expenses] where [Date] >=@startDate and [Date]< @endDate";

            SqlCommand command = new SqlCommand(query, myConnection);
            command.Parameters.Add("@startDate", startDate);
            command.Parameters.Add("@endDate", @endDate);

            DataTable dataTable = new DataTable();
             SqlDataAdapter da = new SqlDataAdapter(command);

            da.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                expensesEntities.Add(new ExpensesEntity {Amount = int.Parse(row[0].ToString()),Type = row[1].ToString() });
            }
            da.Dispose();
          

            




            //       myinfo.Text = "connection to db is made";
            myConnection.Close();
            ViewBag.Total = expensesEntities.Sum(x=>x.Amount);
            ViewBag.Personal = expensesEntities.Where(keys => keys.Type == "Personal").Sum(x => x.Amount);
            ViewBag.Utilities = expensesEntities.Where(keys => keys.Type == "Utility").Sum(x => x.Amount);
            ViewBag.Miscellenous = expensesEntities.Where(keys => keys.Type == "Miscellenous").Sum(x => x.Amount);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class ExpensesEntity
    {
        public decimal Amount { get; set; }
        public string Type { get; set; }
    }
}