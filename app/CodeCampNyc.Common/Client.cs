using CodeCampNyc.Common.Models;
using Elasticsearch.Net.ConnectionPool;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampNyc.Common
{
	public static class Client
	{
		public static IElasticClient CreateInstance()
		{
			var nodes = new Uri []
			{
				new Uri("http://localhost:9200"),
				new Uri("http://localhost:9201"),
				new Uri("http://localhost:9202")
			};

			var connectionPool = new SniffingConnectionPool(nodes);

			var settings = new ConnectionSettings(connectionPool)
				.MapDefaultTypeNames(m => m.Add(typeof(Session), "session"))
				.MapDefaultTypeIndices(m => m.Add(typeof(Session), "codecampnyc"));

			return new ElasticClient(settings);
		}
	}
}
