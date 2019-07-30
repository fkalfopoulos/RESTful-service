using Newtonsoft.Json;
using RESTful_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RESTful_service.Controllers
{
    public class HomeController : Controller
    {

        private MovieContext _context;
        private MoviesController _contr;

        public HomeController()
        {
            _context = new MovieContext();
            _contr = new MoviesController();
        }

        public async Task<ActionResult> Index()
        {
            List<Movie> MoviesList = new List<Movie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:61462/api/Movies"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    MoviesList = JsonConvert.DeserializeObject<List<Movie>>(apiResponse);
                }
            }
            return View(MoviesList);
        }

        public ActionResult GetMovie()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetMovie(int id)
        {
            Movie item = new Movie();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:61462/api/Movies/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    item = JsonConvert.DeserializeObject<Movie>(apiResponse);
                }
            }
            return View(item);
        }


        public ActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMovie(Movie item)
        {
          
            using (var client = new HttpClient())
            {
                bool checkMail = _contr.MovieExists(item.MovieId);
                if (checkMail)
                {
                    ModelState.AddModelError(string.Empty, "Movie already exists.");
                    return View(item);
                }

                client.BaseAddress = new Uri("http://localhost:61462/api/Movies");
              
                var postTask = client.PostAsJsonAsync<Movie>("Movies", item);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact with administrator.");

            return View(item);
        }

        public ActionResult Edit(int id)
        {
            Movie movie = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61462/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Movies?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Movie>();
                    readTask.Wait();

                    movie = readTask.Result;
                }
            }
            return View(movie);

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Movie item)
        {
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:56337/api/UsersApi");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = client.PutAsJsonAsync("UsersApi", user).Result;
            //return RedirectToAction("Index");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61462/api/Movies");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Movie>("Movies", item);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact with administrator.");
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61462/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Movies/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }



    }
}
  