using AutoMapper;
using TvShowApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvShowApp
{
    public interface ITvShowService
    {
        List<TvShowView> GetAllElements();

        TvShows GetShowById(int id);

        Task UpdateShowAsync(TvShows show);

        List<TvShowView> GetFavorites();

        Task AddShowAsync(string name);
    }

    public class TvShowService: ITvShowService
    {
        TvShowsContext Context;

        public TvShowService()
        {
            Context = new TvShowsContext();
        }
        public List<TvShowView> GetAllElements()
        {
            var shows = this.Context.Shows.ToList();

            var showViews = shows.Select(m => Mapper.Map<TvShows, TvShowView>(m)).ToList();

            return showViews;
        }
        public TvShows GetShowById(int id)
        {
            var show = this.Context.Shows.FirstOrDefault(m => m.Id == id);

            return show;
        }
        public async Task UpdateShowAsync(TvShows show)
        {            
            this.Context.SaveChanges();
        }
        public List<TvShowView> GetFavorites()
        {
            var shows = this.Context.Shows.Where(m=>m.favorites==true).OrderBy(e => e.Tittle).Select(m => Mapper.Map<TvShows, TvShowView>(m)).ToList();

            return shows;
        }

        public async Task AddShowAsync(string name)
        {
            try 
            { 

                var tvshow = new TvShows()
                {
                    Tittle=name
                };

               await Context.AddAsync(tvshow);

               await Context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw;

            }
        }
    }



}
