using ManageMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace ManageMovies.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ApplicationDbContext DbContext
        {
            get
            {
                return _dbContext ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            }
            private set
            {
                _dbContext = value;
            }

        }

        // GET: Movies
        [Authorize]
        public ActionResult Index()
        {

            return View(DbContext.Movies.ToList());
        }
        //Edit Movie
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditMovie(int id)
        {
            Movie objmovie = new Movie();
            try
            {
                objmovie = DbContext.Movies.Where(mv => mv.MovieId == id).FirstOrDefault();
                return View(objmovie);
            }
            catch (Exception ex)
            {

            }
            return View(objmovie);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditMovie(Movie objEditmovie)
        {
            try {
                if (ModelState.IsValid) //checking model is valid or not
                {
                    var objmovie = DbContext.Movies.Where(mv => mv.MovieId == objEditmovie.MovieId).FirstOrDefault();
                    objmovie.Amount = objEditmovie.Amount;
                    objmovie.MovieTitle = objEditmovie.MovieTitle;
                    objmovie.ReleaseYear = objEditmovie.ReleaseYear;
                    objmovie.Genre = objEditmovie.Genre;
                    objmovie.UpdatedDate = DateTime.Now;
                    DbContext.SaveChanges();
                    ViewData["resultUpdate"] = "Success";
                }
                else
                {
                    ModelState.AddModelError("", "Error in saving data");
                    return View(objEditmovie);                    
                }
            }
            catch(Exception ex)
            {
                ViewData["resultUpdate"] =ex.Message.ToString();
            }
            return RedirectToAction("Index", "Movies");
        }

        [HttpPost]
        [Authorize]
        public string DeleteMovie(int id)
        {
            try
            {
                var objmovie = DbContext.Movies.Where(mv => mv.MovieId == id).FirstOrDefault();
                DbContext.Movies.Remove(objmovie);
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            return "success";
        }

        [Authorize]
        public ActionResult CreateMovie()
        {

            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult CreateMovie(Movie objEditmovie)
        {
            try
            {
                if (ModelState.IsValid) //checking model is valid or not
                {
                    Movie objmovie = new Movie();
                  
                    objmovie.Amount = objEditmovie.Amount;
                    objmovie.MovieTitle = objEditmovie.MovieTitle;
                    objmovie.ReleaseYear = objEditmovie.ReleaseYear;
                    objmovie.Genre = objEditmovie.Genre;
                    objmovie.CreatedBy = 1;
                    objmovie.CreatedDate=DateTime.Now;
                    objmovie.UpdatedBy = 1;
                    objmovie.UpdatedDate = DateTime.Now;
                    DbContext.Movies.Add(objmovie);
                    DbContext.SaveChanges();
                    ViewData["resultUpdate"] = "Success";
                    ModelState.Clear();
                }
                else
                {
                    ModelState.AddModelError("", "Error in saving data");
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error in saving data");
            }
            return View();
        }
    }
}