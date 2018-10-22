using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreSsrs.Models;
using AlanJuden.MvcReportViewer;
using System.Net;
using System.ServiceModel;

namespace CoreSsrs.Controllers
{
    public class HomeController : ReportController
    {
        protected override ICredentials NetworkCredentials => new NetworkCredential()
        {
            UserName="otadanai",
            Domain="OS",
            Password="Ondris.0926"
        };

        protected override HttpClientCredentialType ClientCredentialType => HttpClientCredentialType.Ntlm;
        
        protected override string ReportServerUrl => "http://astajer-nb/ReportServer";

        public IActionResult Index()
        {
            var model = GetReportViewerModel(Request);
            model.AjaxLoadInitialReport = true;
            //model.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.Basic;
            //model.Credentials = new ClientCredidential(@"OS\otadanai", "Ondris.0926");
            model.ReportPath = "/WakeUpReport";

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
