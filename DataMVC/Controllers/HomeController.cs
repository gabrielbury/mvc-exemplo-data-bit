using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection dados)
        {
            var cultureInfo = new System.Globalization.CultureInfo("pt-Br");
            DateTime data = DateTime.Parse(dados["txtData"], cultureInfo);

            bool feriado = dados.AllKeys.Any(k => k == "chkFeriado");

            using (var ctx = new Models.DataMVCEntities())
            {
                ctx.Data.Add(new Models.Datum
                {
                    Data = data,
                    Feriado = feriado
                });
                ctx.SaveChanges();
            }

            return View();
        }
    }
}