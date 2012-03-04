using System.Web.Mvc;
using Ttl.Web.JourneyPlanning.Models;

namespace Ttl.Web.JourneyPlanning.Controllers
{
    public class AdvancedSearchController : Controller
    {
        //
        // GET: /AdvancedSearch/
        [HttpGet]
        public ActionResult Index()
        {
            return View(new AdvancedSearchModel());
        }

        [HttpPost]
        public ActionResult Search()
        {
            return null;
        }
    }
}
