using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using System.IO;
using CodeCampNyc.Common;
using CodeCampNyc.Common.Models;

namespace CodeCampNyc.Indexer
{
	class Program
	{
		static void Main(string[] args)
		{
			var sessions = File.ReadAllLines(args[0]).Skip(1).Select(l =>
			{
				var columns = l.Split('\t');

				return new Session
				{
					Title = columns[0],
					Level = int.Parse(columns[1]),
					Abstract = columns[2]
				};
			}).ToList();

			var client = Client.CreateInstance();

			client.IndexMany<Session>(sessions);
		}
	}
}
