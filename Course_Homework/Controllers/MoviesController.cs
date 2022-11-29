using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Course_Homework.Models;
using PagedList;

namespace Course_Homework.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movies
        public ActionResult Index(int? page, string nameSearch, string writerSearch, string sortOrder)
        {
            var movies = db.Movies.Include(m => m.Genre).Include(m => m.Rating);

            if (!String.IsNullOrEmpty(nameSearch) && !String.IsNullOrEmpty(writerSearch))
            {
                movies = movies.Where(m => m.Name.Contains(nameSearch) &&m.WrittenBy.Contains(writerSearch));
            }

            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.GenreSortParm = sortOrder == "genre_asc" ? "genre_desc" : "genre_asc";
            ViewBag.RatingSortParm = sortOrder == "rating_asc" ? "rating_desc" : "rating_asc";

            ViewBag.CurrentSortParm = sortOrder;
            ViewBag.NameSearch = nameSearch;
            ViewBag.WriterSearch = writerSearch;

            switch (sortOrder)
            {
                case "name_desc":
                    movies = movies.OrderByDescending(m => m.Name);
                    break;
                case "genre_desc":
                    movies = movies.OrderByDescending(m => m.Genre.GenrePlace);
                    break;
                case "genre_asc":
                    movies = movies.OrderBy(m => m.Genre.GenrePlace);
                    break;
                case "rating_desc":
                    movies = movies.OrderByDescending(m => m.Rating.RatingPlace);
                    break;
                case "rating_asc":
                    movies = movies.OrderBy(m => m.Rating.RatingPlace);
                    break;
                default:
                    movies = movies.OrderBy(m => m.Name);
                    break;
            }


            return View(movies.ToPagedList(page ?? 1, 7));
        }

        [Authorize]
        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [Authorize(Roles = "Admin")]
        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreID", "GenrePlace");
            ViewBag.RatingId = new SelectList(db.Ratings, "RatingID", "RatingPlace");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieID,Name,DirectedBy,WrittenBy,ReleaseDate,RatingId,GenreId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreID", "GenrePlace", movie.GenreId);
            ViewBag.RatingId = new SelectList(db.Ratings, "RatingID", "RatingPlace", movie.RatingId);
            return View(movie);
        }

        [Authorize(Roles = "Admin")]
        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreID", "GenrePlace", movie.GenreId);
            ViewBag.RatingId = new SelectList(db.Ratings, "RatingID", "RatingPlace", movie.RatingId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,Name,DirectedBy,WrittenBy,ReleaseDate,RatingId,GenreId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreID", "GenrePlace", movie.GenreId);
            ViewBag.RatingId = new SelectList(db.Ratings, "RatingID", "RatingPlace", movie.RatingId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [Authorize(Roles = "Admin")]
        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
