using Viziofilm.Core;
using Viziofilm.Core.Entities;
using Viziofilm.Core.Interfaces;
using Viziofilm.Core.Services;
using Viziofilm.Core.Specifications;
using Viziofilm.Infrastructure;
using Viziofilm.Infrastructure.Repositories;
using Viziofilm.SharedKernel.Interfaces;

namespace Viziofilm.ConsoleTestApp
{

	public class Program
	{
		static async Task Main(string[] args)
		{
			//Test1();
			//await Test2();
			//await Test3();
			await Test4();
		}
		static async Task Test4()
		{
			using (ViziofilmContext context = new ViziofilmContext())
			{
				IFilmRepository filmRepository = new FilmRepository(context);
				IAsyncRepository<Personne> personneRepository = new EfRepository<Personne>(context);
				IViziofilmService viziofilmService = new ViziofilmService(filmRepository, personneRepository);
				Film film = new Film("F123", "Seigneur des anneaux", 2002, 240, 3.99M, "Un hobbit veut détruire un anneau", StatutDisponible.Disponible, "Aventure");
				await viziofilmService.AddFilm(film);
			}

		}
		static async Task Test3()
		{
			using (ViziofilmContext context = new ViziofilmContext())
			{
				//chercher le film par numéro
				FilmByNumber spec = new FilmByNumber("1234");
				IFilmRepository filmRepository = new FilmRepository(context);

				List<Film> films = (List<Film>)await filmRepository.ListAsync(spec);
				Film film = films.FirstOrDefault();

				if (film != null)
					System.Console.WriteLine(film.Titre);
				else System.Console.WriteLine("Film introuvable");
			}

		}


		static async Task Test2()
		{
			using (ViziofilmContext context = new ViziofilmContext())
			{
				IAsyncRepository<Film> ar = new EfRepository<Film>(context);
				Film film = await ar.GetByIdAsync(1);
				if (film != null)
					System.Console.WriteLine(film.Titre);
				else System.Console.WriteLine("Film introuvable");
			}
		}

		static void Test1()
		{
			// dirty code
			var context = new ViziofilmContext();

			//ajouter un film
			Film film = new Film("1", "Le silence des agneaux", 1992, 120, 4.99M, "Une tueur...", StatutDisponible.Disponible, "Suspense");

			Personne personne = new Personne("VB01", "Vincent Boulanger", "Canada", TypePersonne.Physique);
			personne.AddFilm(film);
			film.AddPersonne(personne);
			context.Add(film);
			context.Add(personne);

			context.SaveChanges();
		}

	}
}