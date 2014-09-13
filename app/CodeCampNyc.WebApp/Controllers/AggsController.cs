using CodeCampNyc.Common;
using CodeCampNyc.Common.Models;
using CodeCampNyc.WebApp.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeCampNyc.WebApp.Controllers
{
    public class AggsController : Controller
    {
		IElasticClient _client;

		public AggsController()
		{
			_client = Client.CreateInstance();
		}

        // GET: Aggs
        public ActionResult Index()
        {
			var response = _client.Search<Session>(s => s
				.Size(0)
				.Aggregations(aggs => aggs
					.Terms("top_terms", t => t
						.Field(o => o.Abstract)
					)
				)
			);

			var model = new AggregationsViewModel();

            return View();
        }
    }
}