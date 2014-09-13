using CodeCampNyc.Common;
using CodeCampNyc.Common.Models;
using CodeCampNyc.WebApp.Models;
using Elasticsearch.Net.ConnectionPool;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeCampNyc.WebApp.Controllers
{
	public class HomeController : Controller
	{
		IElasticClient _client;

		public HomeController()
		{
			_client = Client.CreateInstance();
		}

		public ActionResult Index()
		{
			var response = _client.Search<Session>(s => s
				.From(0)
				.Size(50)
				.MatchAll()
			);
	
			var model = new SearchViewModel
			{
				Sessions = response.Hits.ToList(),
				TotalHits = response.Total
			};

			return View(model);
		}

		public ActionResult Search(string text)
		{
			var response = _client.Search<Session>(s => s
				.From(0)
				.Size(50)
				.Query(q => q
					.MultiMatch(m => m
						.OnFields(o => o.Abstract, o => o.Title)
						.Query(text)
					)
				)
			);

			var model = new SearchViewModel
			{
				Sessions = response.Hits.ToList(),
				Text = text,
				TotalHits = response.Total
			};

			return PartialView("SessionList", model);
		}
	}
}