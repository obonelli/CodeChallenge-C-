using EntityFrameworkCodeFirst1.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCodeFirst1
{
    class Program
    {
        static ITvShowService tvShowService ;

        static async Task Main(string[] args)
        {
            //tvShowService = new TvShowService();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var service = serviceProvider.GetRequiredService<ITvShowService>();
            tvShowService = service;

            InitializeAutomapper();

            //loads the list
            await LoadList();

            GetFirstList();          

       
        }

        static async Task LoadList()
        {
            var elements = tvShowService.GetAllElements();

            if (elements.Count() == 0 )
            {
                 await AddTvShows();
            }

        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ITvShowService, TvShowService>();            
        }
            static void InitializeAutomapper()
        {
            AutoMapper.Mapper.CreateMap<TvShows, TvShowView>();            
        }


        //Execution order

        //Execute 1 time for Add the list of TvShows.
        static async Task AddTvShows()
        {
            await tvShowService.AddShow("Under the Dome");
            await tvShowService.AddShow("Under the Dome");
            await tvShowService.AddShow("Under the Dome");
            await tvShowService.AddShow("Under the Dome");
            await tvShowService.AddShow("Under the Dome");
            await tvShowService.AddShow("Under the Dome");
            await tvShowService.AddShow("Under the Dome");
            await tvShowService.AddShow("Under the Dome");
            await tvShowService.AddShow("Under the Dome");
            await tvShowService.AddShow("Under the Dome");


            //using (var addList = new TvShowsContext())
            //{
            //    try
            //    {

            //        List<TvShows> a = new List<TvShows>();

            //        a.Add(new TvShows { Tittle = "Under the Dome", favorites = false });
            //        a.Add(new TvShows { Tittle = "Person of Interest", favorites = false });
            //        a.Add(new TvShows { Tittle = "Bitten", favorites = false });
            //        a.Add(new TvShows { Tittle = "Arrow", favorites = false });
            //        a.Add(new TvShows { Tittle = "True Detective", favorites = false });
            //        a.Add(new TvShows { Tittle = "The 100", favorites = false });
            //        a.Add(new TvShows { Tittle = "Homeland", favorites = false });
            //        a.Add(new TvShows { Tittle = "Glee", favorites = false });
            //        a.Add(new TvShows { Tittle = "Revenge", favorites = false });
            //        a.Add(new TvShows { Tittle = "Grimm", favorites = false });
            //        a.Add(new TvShows { Tittle = "Gotham", favorites = false });
            //        a.Add(new TvShows { Tittle = "Lost Girl", favorites = false });
            //        a.Add(new TvShows { Tittle = "The Flash", favorites = false });
            //        a.Add(new TvShows { Tittle = "Continuum", favorites = false });
            //        a.Add(new TvShows { Tittle = "Constantine", favorites = false });


            //        //Newlist.Shows.Add(b);

            //        addList.Shows.AddRange(a);


            //        addList.SaveChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        throw;
            //    }


            //}


        }

        //This will Show the first TvShows list while start the program.
        static void GetFirstList()
        {
            //using (var firstList = new TvShowsContext())
            //{


                try
                {
                    



                    var tvshows = tvShowService.GetAllElements();

                    //Console.WriteLine("TvShow LIST BEFORE SORTING \n");

                   
                    Console.WriteLine(" \n");
                    Console.WriteLine("TvShow LIST ALPHABETIC SORTING \n");
                    var result = tvshows.OrderBy(e => e.Tittle);

                    foreach (var emp in result)
                    {

                        if (emp.favorites == true)
                        {
                            Console.WriteLine($"Id: {emp.Id} \t TvShow: {emp.Tittle} *");
                        }
                        else
                        {
                            Console.WriteLine($"Id: {emp.Id} \t TvShow: {emp.Tittle}");

                        }
                    }
                  
                     getCommands();

                }
                catch (Exception ex)
                {
                    throw;
                }


            //}
         

        }

        static async Task updateFavorites(int aValue)
        {


            //await Task.Run(() =>
            //{

            //using (var updateFavoriteList = new TvShowsContext())
            //{            
                
                try
                {

                        //var result = updateFavoriteList.Shows.SingleOrDefault(b => b.Id == aValue);
                var result = tvShowService.GetShowById(aValue);

                if (result != null)
                {   
                    if(result.favorites == true)
                    {
                        result.favorites = false;
                            Console.Write("\n");
                            Console.WriteLine($"The TvShow with the Id: ({result.Id}) and Tittle: ({result.Tittle}) has been Remove from your favorite list.");

                    }
                    else
                    {
                        result.favorites = true;
                            Console.Write("\n");
                            Console.WriteLine($"The Show with the Id: ({result.Id}) and TvShow: ({result.Tittle}) has been Add to your favorite list.");
                    }


                        await tvShowService.UpdateShowAsync(result);
                        

                }
                    else
                    {
                        Console.Write("\n");
                        Console.WriteLine($"We could not find this TvShow ({aValue}) please try again with another.");

                    }

                await getCommands();

            }
                catch (Exception ex)
                {
                        throw;
                }


           

            //}

            //return  await getCommands();
            //});

        }

        static async Task sentChanneler(string storage)
        {

            switch (storage)
            {
                case "favorites":
                    await GetFavorites(storage);
                    break;
                case "list":
                    await GetTvShowsList();
                    break;
                default:
                    await getCommands();
                    break;
            }
        }

    


        static async Task GetTvShowsList()
        {
            
                try
                {
                   var tvshows = tvShowService.GetAllElements();




                Console.WriteLine(" \n");
                Console.WriteLine("TvShow LIST ALPHABETIC SORTING \n");
                var result = tvshows.OrderBy(e => e.Tittle);
                
                foreach (var emp in result)
                {
                   
                    if (emp.favorites == true) 
                    { 
                    Console.WriteLine($"Id: {emp.Id} \t TvShow: {emp.Tittle} *");
                    }
                    else
                    {
                     Console.WriteLine($"Id: {emp.Id} \t TvShow: {emp.Tittle}");

                    }
                }
                    await getCommands();

                }
                catch (Exception ex)
                {
                    //Log, handle or absorbe I don't care ^_^
                }


            


        }

        

        static async Task GetFavorites(string aValue)
        {
            

                try
                {
                    var TvShowList = tvShowService.GetFavorites();

                    //Console.WriteLine("TvShow LIST BEFORE SORTING \n");


                    Console.WriteLine(" \n");
                    Console.WriteLine("TvShow FAVORITE LIST ALPHABETIC SORTING \n");


                    foreach (var emp in TvShowList)
                    {
                        Console.WriteLine($"Id: {emp.Id} \t TvShow: {emp.Tittle} *");

                    }
                }
                catch (Exception ex)
                {
                    //Log, handle or absorbe I don't care ^_^
                }

                await getCommands();

            


        }

        static async Task getCommands()
        {
           

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
                await updateFavorites(parsed);

            }
            else
            {
                await sentChanneler(value);

            }


        }


        static void removeTvShow()
        {
            using (var RemoveShow = new TvShowsContext())
            {
                TvShows c = new TvShows() { Id = 1 };

                RemoveShow.Shows.Remove(c);

                RemoveShow.SaveChanges();


            }


        }


    }

}

