using Viziofilm.Core;
using Viziofilm.Core.Entities;
using Viziofilm.Core.Interfaces;
using Viziofilm.Core.Services;
using Viziofilm.Core.Specifications;
using Viziofilm.Infrastructure;
using Viziofilm.Infrastructure.Repositories;
using Viziofilm.SharedKernel.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Viziofilm.ConsoleTestApp
{

	public class Program
	{
		static async Task Main(string[] args)
		{
			//a lier en many to many //
			//AjouterCote(); session film
			//AjouterCreditFilm(); personne film



			//Fait//
			AjouterFilm();
			AjouterLanguePiste();
			AjouterMembre();
			AjouterCategorie();
			AjouterAbonnement();
			AjouterAdministrateur();
			AjouterPersonne();
		}

		static void AjouterPersonne()
		{
			var context = new ViziofilmContext();

			Personne[] personnes = new Personne[]
			{
				// Le Voyage de Chihiro (F001)
				new Personne("P001", "Hayao Miyazaki", "Japon", TypePersonne.Physique),
				new Personne("P002", "Rumi Hiiragi", "Japon", TypePersonne.Physique),
				new Personne("P003", "Studio Ghibli", "Japon", TypePersonne.Morale),

				// Inception (F002)
				new Personne("P004", "Christopher Nolan", "Royaume-Uni", TypePersonne.Physique),
				new Personne("P005", "Leonardo DiCaprio", "États-Unis", TypePersonne.Physique),
				new Personne("P006", "Warner Bros.", "États-Unis", TypePersonne.Morale),

				// Parasite (F003)
				new Personne("P007", "Bong Joon-ho", "Corée du Sud", TypePersonne.Physique),
				new Personne("P008", "Song Kang-ho", "Corée du Sud", TypePersonne.Physique),
				new Personne("P009", "CJ Entertainment", "Corée du Sud", TypePersonne.Morale),

				// The Dark Knight (F004)
				new Personne("P010", "Christopher Nolan", "Royaume-Uni", TypePersonne.Physique),
				new Personne("P011", "Heath Ledger", "Australie", TypePersonne.Physique),
				new Personne("P012", "DC Comics", "États-Unis", TypePersonne.Morale),

				// La La Land (F005)
				new Personne("P013", "Damien Chazelle", "États-Unis", TypePersonne.Physique),
				new Personne("P014", "Emma Stone", "États-Unis", TypePersonne.Physique),
				new Personne("P015", "Summit Entertainment", "États-Unis", TypePersonne.Morale),

				// Interstellar (F006)
				new Personne("P016", "Christopher Nolan", "Royaume-Uni", TypePersonne.Physique),
				new Personne("P017", "Matthew McConaughey", "États-Unis", TypePersonne.Physique),
				new Personne("P018", "Paramount Pictures", "États-Unis", TypePersonne.Morale),

				// Pulp Fiction (F007)
				new Personne("P019", "Quentin Tarantino", "États-Unis", TypePersonne.Physique),
				new Personne("P020", "Samuel L. Jackson", "États-Unis", TypePersonne.Physique),
				new Personne("P021", "Miramax Films", "États-Unis", TypePersonne.Morale),

				// The Shawshank Redemption (F008)
				new Personne("P022", "Frank Darabont", "États-Unis", TypePersonne.Physique),
				new Personne("P023", "Morgan Freeman", "États-Unis", TypePersonne.Physique),
				new Personne("P024", "Columbia Pictures", "États-Unis", TypePersonne.Morale),

				// Get Out (F009)
				new Personne("P025", "Jordan Peele", "États-Unis", TypePersonne.Physique),
				new Personne("P026", "Daniel Kaluuya", "Royaume-Uni", TypePersonne.Physique),
				new Personne("P027", "Universal Pictures", "États-Unis", TypePersonne.Morale),

				// The Grand Budapest Hotel (F010)
				new Personne("P028", "Wes Anderson", "États-Unis", TypePersonne.Physique),
				new Personne("P029", "Ralph Fiennes", "Royaume-Uni", TypePersonne.Physique),
				new Personne("P030", "Fox Searchlight Pictures", "États-Unis", TypePersonne.Morale),

				// Mad Max: Fury Road (F011)
				new Personne("P031", "George Miller", "Australie", TypePersonne.Physique),
				new Personne("P032", "Charlize Theron", "Afrique du Sud", TypePersonne.Physique),
				new Personne("P033", "Village Roadshow Pictures", "Australie", TypePersonne.Morale),

				// Whiplash (F012)
				new Personne("P034", "Damien Chazelle", "États-Unis", TypePersonne.Physique),
				new Personne("P035", "J.K. Simmons", "États-Unis", TypePersonne.Physique),
				new Personne("P036", "Sony Pictures Classics", "États-Unis", TypePersonne.Morale)
			};


			foreach (Personne personne in personnes)
			{
				context.Add(personne);
			}

			context.SaveChanges();
		}

		static void AjouterLanguePiste()
		{
			var context = new ViziofilmContext();
			//string code, TypePiste type
			LanguePiste FrA = new LanguePiste("fr", TypePiste.Audio);
			LanguePiste FrS = new LanguePiste("fr", TypePiste.SousTitre);

			LanguePiste EnA = new LanguePiste("En", TypePiste.Audio);
			LanguePiste EnS = new LanguePiste("En", TypePiste.SousTitre);


			LanguePiste EsA = new LanguePiste("Es", TypePiste.Audio);
			LanguePiste EsS = new LanguePiste("Es", TypePiste.SousTitre);


			context.Add(FrA);
			context.Add(EnA);
			context.Add(EsA);
			context.Add(FrS);
			context.Add(EnS);
			context.Add(EsS);

			context.SaveChanges();
		}

		static void AjouterFilm()
		{
			var context = new ViziofilmContext();

			Film[] films = new Film[] 
			{
				new Film(
					"Le Voyage de Chihiro",
					2001,
					125,
					12.99m,
					"Une jeune fille, Chihiro, se retrouve piégée dans un monde spirituel mystérieux et doit travailler dans un étrange bain public pour sauver ses parents transformés en cochons.",
					StatutDisponible.Disponible,
					"animation, aventure, fantastique, Japon, studio Ghibli"
				),
				new Film(
					"Inception",
					2010,
					148,
					14.99m,
					"Un voleur d'idées, Dom Cobb, utilise la technologie pour infiltrer les rêves des gens et voler leurs secrets. Il est chargé d'implanter une idée dans l'esprit d'un héritier d'un empire.",
					StatutDisponible.Disponible,
					"science-fiction, thriller, rêves, Leonardo DiCaprio, Christopher Nolan"
				),
				new Film(
					"Parasite",
					2019,
					132,
					11.99m,
					"Une famille pauvre s'infiltre dans la vie d'une famille riche, déclenchant une série d'événements imprévisibles et sombres.",
					StatutDisponible.Retiré,
					"thriller, drame, Corée du Sud, Oscar, Bong Joon-ho"
				),
				new Film(
					"The Dark Knight",
					2008,
					152,
					13.99m,
					"Batman affronte le Joker, un criminel chaotique qui plonge Gotham dans le désordre et met à l'épreuve les limites morales du justicier.",
					StatutDisponible.Disponible,
					"super-héros, action, thriller, Joker, Christian Bale"
				),
				new Film(
					"La La Land",
					2016,
					128,
					10.99m,
					"Une actrice en devenir et un musicien de jazz tombent amoureux à Los Angeles, tout en poursuivant leurs rêves respectifs.",
					StatutDisponible.Prochainement,
					"comédie musicale, romance, Ryan Gosling, Emma Stone, Oscars"
				),
				new Film(
					"Interstellar",
					2014,
					169,
					14.99m,
					"Une équipe d'explorateurs voyage à travers un trou de ver dans l'espace pour trouver une nouvelle planète habitable pour l'humanité.",
					StatutDisponible.Disponible,
					"science-fiction, aventure, espace, Matthew McConaughey, Christopher Nolan"
				),
				new Film(
					"Pulp Fiction",
					1994,
					154,
					11.99m,
					"Des histoires entrelacées de criminels à Los Angeles, avec des dialogues percutants et des scènes cultes.",
					StatutDisponible.Disponible,
					"crime, thriller, Quentin Tarantino, Samuel L. Jackson, John Travolta"
				),
				new Film(
					"The Shawshank Redemption",
					1994,
					142,
					9.99m,
					"Un banquier condamné à perpétuité pour un crime qu'il n'a pas commis se lie d'amitié avec un autre prisonnier et trouve l'espoir derrière les barreaux.",
					StatutDisponible.Disponible,
					"drame, prison, espoir, Tim Robbins, Morgan Freeman"
				),
				new Film(
					"Get Out",
					2017,
					104,
					10.99m,
					"Un jeune homme afro-américain visite la famille de sa petite amie blanche, mais découvre un secret terrifiant.",
					StatutDisponible.Retiré,
					"horreur, thriller, Jordan Peele, satire sociale, Oscar"
				),
				new Film(
					"The Grand Budapest Hotel",
					2014,
					99,
					11.99m,
					"Les aventures d'un concierge légendaire et de son jeune protégé dans un hôtel mythique d'Europe de l'Est entre les deux guerres mondiales.",
					StatutDisponible.Prochainement,
					"comédie, Wes Anderson, Ralph Fiennes, esthétique visuelle"
				),
				new Film(
					"Mad Max: Fury Road",
					2015,
					120,
					12.99m,
					"Dans un monde post-apocalyptique, Max s'allie à une impératrice rebelle pour fuir un tyran et traverser le désert.",
					StatutDisponible.Disponible,
					"action, post-apocalyptique, Charlize Theron, Tom Hardy, courses-poursuites"
				),
				new Film(
					"Whiplash",
					2014,
					106,
					10.99m,
					"Un jeune batteur de jazz est poussé à ses limites par un professeur de musique tyrannique.",
					StatutDisponible.Disponible,
					"drame, musique, J.K. Simmons, Miles Teller, Oscars"
				)
			};
			foreach (Film film in films)
			{
				context.Add(film);
			}


			context.SaveChanges();
		}

		static void AjouterMembre()
		{
			var context = new ViziofilmContext();

			Membre m1 = new Membre("M127", "EmmaD", "EmmaMdp123!", "Dubois", "Emma", "1234 boulevard Saint-Martin, Laval", "514-555-1234", "emma.dubois@email.com", "G1B2G2", "Canada");
			Membre m2 = new Membre("M128", "ThomasP", "ThomasP@ss99", "Petit", "Thomas", "5678 avenue Papineau, Montréal", "514-777-5678", "thomas.petit@email.com", "A4B7K9", "Canada");
			Membre m3 = new Membre("M129", "SophieL", "Sophie!2025", "Lefèvre", "Sophie", "9101 rue Saint-Jean, Québec", "418-111-9101", "sophie.lefevre@email.com", "H1H2G5", "Canada");
			Membre m4 = new Membre("M130", "LiamR", "LiamPass99!", "Roy", "Liam", "3456 chemin d'Aylmer, Gatineau", "819-222-3456", "liam.roy@email.com", "H0H0H0", "Canada");
			Membre m5 = new Membre("M131", "ChloéB", "ChloéSecur3#", "Bouchard", "Chloé", "7890 rue King Ouest, Sherbrooke", "819-333-7890", "chloe.bouchard@email.com", "L9U6J5", "Canada");
			Membre m6 = new Membre("M132", "NoahG", "Noah2024@Mdp", "Gagnon", "Noah", "2345 boulevard des Forges, Trois-Rivières", "819-444-2345", "noah.gagnon@email.com", "75001", "France");
			Membre m7 = new Membre("M133", "AliceM", "AliceMdp456*", "Morin", "Alice", "6789 rue Begin, Lévis", "418-555-6789", "alice.morin@email.com", "97410", "La Reunion");
			Membre m8 = new Membre("M134", "JacobC", "JacobSafe789!", "Côté", "Jacob", "1011 boulevard Roland-Therrien, Longueuil", "450-666-1011", "jacob.cote@email.com", "02876", "Perou");
			Membre m9 = new Membre("M135", "LéaP", "LéaMdp2025#", "Pelletier", "Léa", "4567 rue Racine, Saguenay", "418-777-4567", "lea.pelletier@email.com", "N4A0A9", "Canada");
			Membre m10 = new Membre("M136", "NathanL", "NathanPass123!", "Lapointe", "Nathan", "8901 avenue de la Cathédrale, Rimouski", "418-888-8901", "nathan.lapointe@email.com", "K5G3D5", "Canada");
			Membre m11 = new Membre("M137", "CamilleB", "Camille!2024*", "Bergeron", "Camille", "3456 rue Hériot, Drummondville", "819-999-3456", "camille.bergeron@email.com", "1234567", "Etats-Unis");
			Membre m12 = new Membre("M138", "EthanD", "EthanSecure99#", "Dufour", "Ethan", "7890 rue Principale, Granby", "450-111-7890", "ethan.dufour@email.com", "3004", "Australie");
			
			context.Add(m1);
			context.Add(m2);
			context.Add(m3);
			context.Add(m4);
			context.Add(m5);
			context.Add(m6);
			context.Add(m7);
			context.Add(m8);
			context.Add(m9);
			context.Add(m10);
			context.Add(m11);
			context.Add(m12);

			context.SaveChanges();
		}

		static void AjouterAbonnement()
		{
			var context = new ViziofilmContext();

			AbonnementPlan Base = new AbonnementPlan("1", "Base", 5.99f, 1);
			AbonnementPlan Premium = new AbonnementPlan("2", "Premium", 11.99f, 2);
			AbonnementPlan Elite = new AbonnementPlan("3", "Elite", 20.99f, 4);

			context.Add(Base);
			context.Add(Premium);
			context.Add(Elite);

			context.SaveChanges();
		}

		static void AjouterCategorie()
		{
			// dirty code
			var context = new ViziofilmContext();

			//ajouter un film
			Categorie Drame = new Categorie("1", "Drame");
			Categorie Policier = new Categorie("2", "Policier");
			Categorie Documentaire = new Categorie("3", "Documentaire");
			Categorie Comedie = new Categorie("4", "Comedie");
			Categorie Action = new Categorie("5", "Action");


			context.Add(Drame);
			context.Add(Policier);
			context.Add(Documentaire);
			context.Add(Comedie);
			context.Add(Action);

			context.SaveChanges();
		}

		static void AjouterAdministrateur()
		{
			// dirty code
			var context = new ViziofilmContext();

			//ajouter un film
			Administrateur Jacques = new Administrateur("A1", "Jacques", "123456789");
			Administrateur Alice = new Administrateur("A2", "Alice", "987654321");

			context.Add(Jacques);
			context.Add(Alice);

			context.SaveChanges();
		}


		//CODE DE TEST DU GUIDE VIDEO DU PROF
		//static async Task Test4()
		//{
		//	using (ViziofilmContext context = new ViziofilmContext())
		//	{
		//		IFilmRepository filmRepository = new FilmRepository(context);
		//		IAsyncRepository<Personne> personneRepository = new EfRepository<Personne>(context);
		//		IViziofilmService viziofilmService = new ViziofilmService(filmRepository, personneRepository);
		//		Film film = new Film("F123", "Seigneur des anneaux", 2002, 240, 3.99M, "Un hobbit veut détruire un anneau", StatutDisponible.Disponible, "Aventure");
		//		await viziofilmService.AddFilm(film);
		//	}

		//}
		//static async Task Test3()
		//{
		//	using (ViziofilmContext context = new ViziofilmContext())
		//	{
		//		//chercher le film par numéro
		//		FilmByNumber spec = new FilmByNumber("1234");
		//		IFilmRepository filmRepository = new FilmRepository(context);

		//		List<Film> films = (List<Film>)await filmRepository.ListAsync(spec);
		//		Film film = films.FirstOrDefault();

		//		if (film != null)
		//			System.Console.WriteLine(film.Titre);
		//		else System.Console.WriteLine("Film introuvable");
		//	}

		//}


		//static async Task Test2()
		//{
		//	using (ViziofilmContext context = new ViziofilmContext())
		//	{
		//		IAsyncRepository<Film> ar = new EfRepository<Film>(context);
		//		Film film = await ar.GetByIdAsync(1);
		//		if (film != null)
		//			System.Console.WriteLine(film.Titre);
		//		else System.Console.WriteLine("Film introuvable");
		//	}
		//}

		//static void Test1()
		//{
		//	// dirty code
		//	var context = new ViziofilmContext();

		//	//ajouter un film
		//	Film film = new Film("1", "Le silence des agneaux", 1992, 120, 4.99M, "Une tueur...", StatutDisponible.Disponible, "Suspense");

		//	Personne personne = new Personne("VB01", "Vincent Boulanger", "Canada", TypePersonne.Physique);
		//	personne.AddFilm(film);
		//	film.AddPersonne(personne);
		//	context.Add(film);
		//	context.Add(personne);

		//	context.SaveChanges();
		//}

	}
}