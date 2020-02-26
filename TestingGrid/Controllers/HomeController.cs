using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingGrid.Models;



namespace TestingGrid.Controllers
{
    public class HomeController : Controller
    {
       
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public ActionResult Index()
        {
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
        public TransInfo InsertTarget(ICollection<TargetVM> targetVM)
        {
            string mess = "";
            using (var ctx = new TestEntities())
            {
                try
                {
                    DataTable targetDetail = new DataTable();
                    targetDetail.Columns.Add("ID", typeof(int));
                    targetDetail.Columns.Add("SL", typeof(int));
                    targetDetail.Columns.Add("Name", typeof(string));
                    targetDetail.Columns.Add("Roll", typeof(string));
                    targetDetail.Columns.Add("Class", typeof(string));
                    targetDetail.Columns.Add("Address", typeof(string));
                    targetDetail.Columns.Add("Phone", typeof(string));
                    foreach (var item in targetVM)
                    {
                        var row = targetDetail.NewRow();

                        row["ID"] = 0;
                        row["SL"] = item.SL;
                        row["Name"] = item.Name;
                        row["Roll"] = item.Roll;
                        row["Class"] = item.Class;
                        row["Address"] = item.Address;
                        row["Phone"] = item.Phone;
                        targetDetail.Rows.Add(row);
                    }
                    SqlParameter[] parameters =
                    {
                    new SqlParameter
                        {
                            SqlDbType = SqlDbType.Structured,
                            Direction = ParameterDirection.Input,
                            ParameterName = "Target",
                            TypeName = "dbo.TargetType", //Don't forget this one!
                            Value = targetDetail
                        },

                };

                    var response = ctx.Database.SqlQuery<TransInfo>("EXEC spInTarget @Target", parameters).FirstOrDefault();
                    return response;
                }
                catch (Exception ex)
                {
                    mess = ex.Message;
                }
            }
            return new TransInfo { TransID = 0, TransStatus = 0, TransMessage = mess };
        }
    }
}