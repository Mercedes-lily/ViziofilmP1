using Microsoft.EntityFrameworkCore;
using Viziofilm.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Viziofilm.Infrastructure
{
	public class ViziofilmContext : DbContext
	{
		public DbSet<Film> Films { get; set; }
		public DbSet<Personne> Personnes { get; set; }

		public ViziofilmContext(DbContextOptions options) : base(options)
		{ }

		public ViziofilmContext() : base(new DbContextOptionsBuilder<ViziofilmContext>()
			.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database= ViziofilmDB;Trusted_Connection=True;").Options)
		{ }
	}

}
