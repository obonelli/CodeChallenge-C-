using TvShowApp.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;

namespace TvShowApp
{
    class Program
    {
        static ITvShowService tvShowService;

        static ILogger logger;

        static async Task Main(string[] args)
        {
            //loger
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = loggerFactory.CreateLogger<Program>();

                        
            //dependency injection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var service = serviceProvider.GetRequiredService<ITvShowService>();
            tvShowService = service;

            //automapper
            InitializeAutomapper();

            //loads the list
            await LoadList();

            await GetFirstList();

        }
            //Execution order
        static async Task LoadList()
        {
            var elements = tvShowService.GetAllElements();

            if (elements.Count() == 0)
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

       

        //Execute 1 time for Add the list of TvShows.
        static async Task AddTvShows()
        {
            await tvShowService.AddShowAsync("Under the Dome");
            await tvShowService.AddShowAsync("Person of Interest");
            await tvShowService.AddShowAsync("Bitten");
            await tvShowService.AddShowAsync("Arrow");
            await tvShowService.AddShowAsync("The 100");
            await tvShowService.AddShowAsync("Homeland");
            await tvShowService.AddShowAsync("Glee");
            await tvShowService.AddShowAsync("Revenge");
            await tvShowService.AddShowAsync("Grimm");
            await tvShowService.AddShowAsync("Gotham");
            await tvShowService.AddShowAsync("Lost Girl");
            await tvShowService.AddShowAsync("The Flash");
            await tvShowService.AddShowAsync("Continuum");
            await tvShowService.AddShowAsync("Constantine");

        }

        //This will Show the first TvShows list while start the program.
        static async Task GetFirstList()
        {

            try
            {

                var tvshows = tvShowService.GetAllElements();


                Console.WriteLine(" \n");
                Console.WriteLine("TvShow LIST ALPHABETIC SORTING \n");
                var result = tvshows.OrderBy(e => e.Tittle);

                Console.WriteLine($"Id:  \t TvShow: ");

                foreach (var emp in result)
                {

                    if (emp.favorites == true)
                    {
                        Console.WriteLine($"{emp.Id} \t {emp.Tittle} *");
                    }
                    else
                    {
                        Console.WriteLine($"{emp.Id} \t {emp.Tittle}");

                    }
                }

                await GetCommands();

            }
            catch (Exception ex)
            {
                logger.LogError("error {0}", ex.Message);
                throw;
            }

        }

        //This will Update the current Show to favorite/unfavorite.
        static async Task UpdateFavorites(int aValue)
        {

            try
            {
                var result = tvShowService.GetShowById(aValue);

                if (result != null)
                {
                    if (result.favorites == true)
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

                await GetCommands();

            }
            catch (Exception ex)
            {
                logger.LogError("failed in the execution  {0}", ex.Message);
                throw;
            }

        }

        //This will Check the selected command.
        static async Task SentChanneler(string storage)
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
                    await GetCommands();
                    break;
            }
        }

        //This will the current list.
        static async Task GetTvShowsList()
        {

            try
            {
                var tvshows = tvShowService.GetAllElements();

                Console.WriteLine(" \n");
                Console.WriteLine("TvShow LIST ALPHABETIC SORTING \n");
                var result = tvshows.OrderBy(e => e.Tittle);

                Console.WriteLine($"Id:  \t TvShow: ");

                foreach (var emp in result)
                {

                    if (emp.favorites == true)
                    {
                        Console.WriteLine($" {emp.Id} \t  {emp.Tittle} *");
                    }
                    else
                    {
                        Console.WriteLine($" {emp.Id} \t  {emp.Tittle}");

                    }
                }
                await GetCommands();

            }
            catch (Exception ex)
            {
                logger.LogError("error {0}", ex.Message);
              
            }

        }

        //This will the favorites list.
        static async Task GetFavorites(string aValue)
        {

            try
            {
                var TvShowList = tvShowService.GetFavorites();

                Console.WriteLine(" \n");
                Console.WriteLine("TvShow FAVORITE LIST ALPHABETIC SORTING \n");

                foreach (var emp in TvShowList)
                {
                    Console.WriteLine($"Id: {emp.Id} \t TvShow: {emp.Tittle} *");

                }
            }
            catch (Exception ex)
            {
                logger.LogError("failed in the execution  {0}", ex.Message);
            }

            await GetCommands();

        }

        //This will send the avaliables commands.
        static async Task GetCommands()
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
                await UpdateFavorites(parsed);

            }
            else
            {
                await SentChanneler(value);

            }

        }

    }

}