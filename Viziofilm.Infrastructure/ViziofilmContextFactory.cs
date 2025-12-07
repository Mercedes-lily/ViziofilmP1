using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viziofilm.Infrastructure
{
	public class ViziofilmContextFactory : IDesignTimeDbContextFactory<ViziofilmContext>
	{
		public ViziofilmContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ViziofilmContext>();
			optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ViziofilmDB;Trusted_Connection=True;");
			return new ViziofilmContext(optionsBuilder.Options);
		}
	}

}
