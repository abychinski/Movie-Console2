using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;
using System.Xml.Serialization;

namespace MovieLibraryConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var choice = "";
            Console.WriteLine("(1) Search Movie \n(2) Add Movie \n(3) Update Movie \n(4) Delete Movie");
            choice = Console.ReadLine();


            if (choice == "1")
            {
                System.Console.WriteLine("Enter Movie Name: ");
                var mov = Console.ReadLine();

                using (var db = new MovieContext())
                {
                    var movie = db.Movies.FirstOrDefault(x => x.Title == mov);
                    System.Console.WriteLine($"({movie.Id}) {movie.Title}");
                }
            }
            else if (choice == "2")
            {
                System.Console.WriteLine("Enter NEW Movie Name: ");
                var newmov = Console.ReadLine();

                using (var db = new MovieContext())
                {
                    var movie = new Movie()
                    {
                        Title = newmov
                    };
                    db.Movies.Add(movie);
                    db.SaveChanges();

                    var newMovie = db.Movies.FirstOrDefault(x => x.Title == newmov);
                    System.Console.WriteLine($"({movie.Id}) {movie.Title}");
                }
            }
            // Crud - CREATE
            // System.Console.WriteLine("Enter NEW Occupation Name: ");
            // var occ2 = Console.ReadLine();

            // using (var db = new MovieContext())
            // {
            //     var occupation = new Occupation() {
            //         Name = occ2
            //     };
            //     db.Occupations.Add(occupation);
            //     db.SaveChanges();

            //     var newOccupation = db.Occupations.FirstOrDefault(x => x.Name == occ2);
            //     System.Console.WriteLine($"({newOccupation.Id}) {newOccupation.Name}");
            // }
            else if (choice == "3")
            {
                System.Console.WriteLine("Enter Movie Name to Update: ");
                var upmovie = Console.ReadLine();

                System.Console.WriteLine("Enter Updated Movie Name: ");
                var movieUpdate = Console.ReadLine();

                using (var db = new MovieContext())
                {
                    var updateMovie = db.Movies.FirstOrDefault(x => x.Title == upmovie);
                    System.Console.WriteLine($"({updateMovie.Id}) {updateMovie.Title}");

                    updateMovie.Title = movieUpdate;

                    db.Movies.Update(updateMovie);
                    db.SaveChanges();

                }
            }
            // crUd - UPDATE
            // System.Console.WriteLine("Enter Occupation Name to Update: ");
            // var occ3 = Console.ReadLine();

            // System.Console.WriteLine("Enter Updated Occupation Name: ");
            // var occUpdate = Console.ReadLine();

            // using (var db = new MovieContext())
            // {
            //     var updateOccupation = db.Occupations.FirstOrDefault(x => x.Name == occ3);
            //     System.Console.WriteLine($"({updateOccupation.Id}) {updateOccupation.Name}");

            //     updateOccupation.Name = occUpdate;

            //     db.Occupations.Update(updateOccupation);
            //     db.SaveChanges();

            // }
            else if (choice == "4")
            {
                System.Console.WriteLine("Enter Movie Name to Delete: ");
                var moviedel = Console.ReadLine();

                using (var db = new MovieContext())
                {
                    var deleteMovie = db.Movies.FirstOrDefault(x => x.Title == moviedel);
                    System.Console.WriteLine($"({deleteMovie.Id}) {deleteMovie.Title}");

                    // verify exists first
                    db.Movies.Remove(deleteMovie);
                    db.SaveChanges();
                }
                var context = new MovieContext();
                var movies = context.Movies;

                foreach (var movie in movies)
                {
                    Console.WriteLine($"Movie {movie.Title}");
                }

            }
            // cruD - DELETE
            // System.Console.WriteLine("Enter Occupation Name to Delete: ");
            // var occ4 = Console.ReadLine();

            // using (var db = new MovieContext())
            // {
            //     var deleteOccupation = db.Occupations.FirstOrDefault(x => x.Name == occ4);
            //     System.Console.WriteLine($"({deleteOccupation.Id}) {deleteOccupation.Name}");

            //     // verify exists first
            //     db.Occupations.Remove(deleteOccupation);
            //     db.SaveChanges();
            // }
            //var context = new MovieContext();
            //var movies = context.Movies;

            //foreach (var movie in movies)
            //{
            //    Console.WriteLine($"Movie {movie.Title}");
            //}
        }
    }
}