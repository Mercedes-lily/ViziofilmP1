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
		public DbSet<Administrateur> Administrateur { get; set; }
		public DbSet<AbonnementPlan> Abonnements { get; set; }
		public DbSet<Categorie> Categorie { get; set; }
		public DbSet<Film> Films { get; set; }
		public DbSet<Personne> Personnes { get; set; }
		public DbSet<Cote> Cote { get; set; }
		public DbSet<CreditFilm> CreditFilm { get; set; }
		public DbSet<LanguePiste> LanguePiste { get; set; }
		public DbSet<Membre> Membre { get; set; }
		public DbSet<Session> Session { get; set; }


		public ViziofilmContext(DbContextOptions options) : base(options)
		{ }

		public ViziofilmContext() : base(new DbContextOptionsBuilder<ViziofilmContext>()
			.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database= ViziofilmDB;Trusted_Connection=True;").Options)
		{ }
	}

}
