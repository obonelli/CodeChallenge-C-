using EntityFrameworkCodeFirst1.Models;
using System;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using System.Collections.Generic;

namespace EntityFrameworkCodeFirst1
{
    class Program
    {
        static void Main(string[] args)
        {

            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<Source, Dest>();
            //});

            //IMapper mapper = config.CreateMapper();
            //var source = new Source();
            //var dest = mapper.Map<Source, Dest>(source);

            //addBlog();
            //UpdateBlog();
            getFirstList();
            //getRemove();
            
            //Console.WriteLine("Listo " + value);
            Console.ReadKey();

       
        }

 

        static void addBlog()
        {



            using (var blog=new BlogContext())
            {
                try
                {

                    List<Blog> b = new List<Blog>();

                    b.Add(new Blog { URL = "Under the Dome", favoritos = false });
                    b.Add(new Blog { URL = "Person of Interest", favoritos = false });
                    b.Add(new Blog { URL = "Bitten", favoritos = false });
                    b.Add(new Blog { URL = "Arrow", favoritos = false });
                    b.Add(new Blog { URL = "True Detective", favoritos = false });
                    b.Add(new Blog { URL = "The 100", favoritos = false });
                    b.Add(new Blog { URL = "Homeland", favoritos = false });
                    b.Add(new Blog { URL = "Glee", favoritos = false });
                    b.Add(new Blog { URL = "Revenge", favoritos = false });
                    b.Add(new Blog { URL = "Grimm", favoritos = false });
                    b.Add(new Blog { URL = "Gotham", favoritos = false });
                    b.Add(new Blog { URL = "Lost Girl", favoritos = false });
                    b.Add(new Blog { URL = "The Flash", favoritos = false });
                    b.Add(new Blog { URL = "Continuum", favoritos = false });
                    b.Add(new Blog { URL = "Constantine", favoritos = false });

                    //{
                    //    URL = "Under the Dome",
                    //    favoritos = false
                    //};

                    //blog.Blogs.Add(b);

                    blog.Blogs.AddRange(b);


                    blog.SaveChanges();
                }
                catch (Exception ex)
                {
                    //Log, handle or absorbe I don't care ^_^
                }

     

            }


        }
        static void UpdateBlog(int aValue)
        {
            using (var blog = new BlogContext())
            {
                try
                {
                  var result = blog.Blogs.SingleOrDefault(b => b.Id == aValue);
                if (result != null)
                {   
                    if(result.favoritos == true)
                    {
                        result.favoritos = false;
                            Console.Write("\n");
                            Console.WriteLine($"The TvShow with the Id: ({result.Id}) and Tittle: ({result.URL}) has been Remove from your favorite list.");

                    }
                    else
                    {
                        result.favoritos = true;
                            Console.Write("\n");
                            Console.WriteLine($"The Show with the Id: ({result.Id}) and TvShow: ({result.URL}) has been Add to your favorite list.");
                        }

                   blog.SaveChanges();

                    }
                    else
                    {
                        Console.Write("\n");
                        Console.WriteLine($"We could not find this TvShow ({aValue}) please try again with another.");

                    }

                    //Blog b = new Blog() { Id=1,URL = "New Test URL" };

                    //blog.Blogs.Update(b);

                    //blog.SaveChanges();
                }
                catch (Exception ex)
                {

                }
                Console.Write("----------------------------------------");
                Console.Write("\n available commands: \n");
                Console.Write("list => This will show all TvShows \n");
                Console.Write("favorites => This will show all Favorites \n");
                Console.Write("Number Id example: (5) => This will Update a TvShow from unfavorite to favorite and vice versa \n");
                Console.Write("\n");
                string value = Console.ReadLine();
                Console.Clear();
                int parsed;
                if (int.TryParse(value, out parsed))
                {
                    UpdateBlog(parsed);
                }
                else
                {
                    sentChanneler(value);

                }
            }

        }

        static void getBlog()
        {
            using (var blog = new BlogContext())
            {


                try
                {
                    IEnumerable<Blog> employeeList = blog.Blogs.ToList();

                //Console.WriteLine("TvShow LIST BEFORE SORTING \n");

                foreach (Blog emp in employeeList)
                {
                    //Console.WriteLine(emp.Id + "\t" + emp.URL);

                }

                Console.WriteLine(" \n");
                Console.WriteLine("TvShow LIST ALPHABETIC SORTING \n");
                var result = employeeList.OrderBy(e => e.URL);
                
                foreach (var emp in result)
                {
                   
                    if (emp.favoritos == true) 
                    { 
                    Console.WriteLine($"Id: {emp.Id} \t TvShow: {emp.URL} *");
                    }
                    else
                    {
                     Console.WriteLine($"Id: {emp.Id} \t TvShow: {emp.URL}");

                    }
                }
                    Console.Write("----------------------------------------");
                    Console.Write("\n available commands: \n");
                    Console.Write("list => This will show all TvShows \n");
                    Console.Write("favorites => This will show all Favorites \n");
                    Console.Write("Number Id example: (5) => This will Update a TvShow from unfavorite to favorite and vice versa \n");
                    Console.Write("\n");
                    string value = Console.ReadLine();
                    Console.Clear();
                    int parsed;
                    if (int.TryParse(value, out parsed))
                    {
                        UpdateBlog(parsed);
                    }
                    else
                    {
                        sentChanneler(value);

                    }

                }
                catch (Exception ex)
                {
                    //Log, handle or absorbe I don't care ^_^
                }


            }


        }

        static void getFirstList()
        {
            using (var blog = new BlogContext())
            {


                try
                {
                    IEnumerable<Blog> tvshows = blog.Blogs.ToList();

                    //Console.WriteLine("TvShow LIST BEFORE SORTING \n");

                    foreach (Blog emp in tvshows)
                    {
                        //Console.WriteLine(emp.Id + "\t" + emp.URL);

                    }

                    Console.WriteLine(" \n");
                    Console.WriteLine("TvShow LIST ALPHABETIC SORTING \n");
                    var result = tvshows.OrderBy(e => e.URL);

                    foreach (var emp in result)
                    {

                        if (emp.favoritos == true)
                        {
                            Console.WriteLine($"Id: {emp.Id} \t TvShow: {emp.URL} *");
                        }
                        else
                        {
                            Console.WriteLine($"Id: {emp.Id} \t TvShow: {emp.URL}");

                        }
                    }
                    Console.Write("----------------------------------------");
                    Console.Write("\n available commands: \n");
                    Console.Write("list => This will show all TvShows \n");
                    Console.Write("favorites => This will show all Favorites \n");
                    Console.Write("Number Id example: (5) => This will Update a TvShow from unfavorite to favorite and vice versa \n");
                    Console.Write("\n");
                    string value = Console.ReadLine();
                    Console.Clear();
                    int parsed;
                    if (int.TryParse(value, out parsed))
                    {
                        UpdateBlog(parsed);
                    }
                    else
                    {
                        sentChanneler(value);
                      
                    }

                }
                catch (Exception ex)
                {
                    //Log, handle or absorbe I don't care ^_^
                }


            }


        }

        static void getFavorites(string aValue)
        {
            using (var blog = new BlogContext())
            {

                try
                {
                    IEnumerable<Blog> employeeList = blog.Blogs.ToList();

                    //Console.WriteLine("TvShow LIST BEFORE SORTING \n");

                    foreach (Blog emp in employeeList)
                    {
                        //Console.WriteLine(emp.Id + "\t" + emp.URL);

                    }

                    Console.WriteLine(" \n");
                    Console.WriteLine("TvShow FAVORITE LIST ALPHABETIC SORTING \n");

                    var result = employeeList.OrderBy(e => e.URL);

                    foreach (var emp in result)
                    {
                        if (emp.favoritos == true)
                        {
                            Console.WriteLine($"Id: {emp.Id} \t TvShow: {emp.URL} *");

                        }

                    }
                }
                catch (Exception ex)
                {
                    //Log, handle or absorbe I don't care ^_^
                }
                   
                    Console.Write("----------------------------------------");
                    Console.Write("\n available commands: \n");
                    Console.Write("list => This will show all TvShows \n");
                    Console.Write("favorites => This will show all Favorites \n");
                    Console.Write("Number Id example: (5) => This will Update a TvShow from unfavorite to favorite and vice versa \n");
                    Console.Write("\n");
                    string value = Console.ReadLine();
                    Console.Clear();

                int parsed;
                if (int.TryParse(value, out parsed))
                {
                    UpdateBlog(parsed);
                }
                else
                {
                    sentChanneler(value);

                }




            }


        }

        static void getRemove()
        {
            using (var blog = new BlogContext())
            {
                Blog b = new Blog() { Id = 2 };

                blog.Blogs.Remove(b);

                blog.SaveChanges();


            }


        }

        static void sentChanneler(string storage)
        {

            switch (storage)
            {
                case "favorites":
                    getFavorites(storage);
                    break;
                case "list":
                    getBlog();
                    break;
                 default:
                    Console.WriteLine("invalid commands");
                    Console.Write("----------------------------------------");
                    Console.Write("\n available commands: \n");
                    Console.Write("list => This will show all TvShows \n");
                    Console.Write("favorites => This will show all Favorites \n");
                    Console.Write("Number Id example: (5) => This will Update a TvShow from unfavorite to favorite and vice versa \n");
                    Console.Write("\n");
                    string value = Console.ReadLine();
                    Console.Clear();

                    int parsed;
                    if (int.TryParse(value, out parsed))
                    {
                        UpdateBlog(parsed);
                    }
                    else
                    {
                        sentChanneler(value);

                    }
                    break;
            }
        }

    }
}
