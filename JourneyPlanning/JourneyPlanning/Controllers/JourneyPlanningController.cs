using System.Text;
using System.Web.Mvc;
using Ttl.Web.JourneyPlanning.Models;
using System.Linq;

namespace Ttl.Web.JourneyPlanning.Controllers
{
    public class JourneyPlanningController : Controller
    {
        //
        // GET: /JourneyPlanning/
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

        [HttpGet]
        [OutputCache(VaryByParam = "keywordStartsWith", Duration = 120, VaryByHeader = "", VaryByCustom = "")]
        public ActionResult PredictiveSearch(string keywordStartsWith)
        {
            var data = new []{"London", "Manchester", "Manchester Airport", "London Kings Cross", "London Euston"};
            var results = data.Where(s => s.StartsWith(keywordStartsWith)).ToArray();
            return new JsonResult {ContentEncoding = Encoding.UTF8, Data = results, ContentType = "application/json", JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
    }
}
