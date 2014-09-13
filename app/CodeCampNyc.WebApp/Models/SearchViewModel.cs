using CodeCampNyc.Common;
using CodeCampNyc.Common.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCampNyc.WebApp.Models
{
	public class SearchViewModel
	{
		public SearchViewModel()
		{
			this.Sessions = new List<IHit<Session>>();
		}

		public string Text { get; set; }
		public List<IHit<Session>> Sessions { get; set; }
		public long TotalHits { get; set; }
	}
}