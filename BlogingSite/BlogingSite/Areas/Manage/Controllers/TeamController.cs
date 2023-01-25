using BlogingSite.Helper;
using BlogingSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogingSite.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamController : Controller
    {
        private readonly BlogContext _blogContext;
        private readonly IWebHostEnvironment _env;

        public TeamController(BlogContext blogContext, IWebHostEnvironment env)
        {
            _blogContext = blogContext;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_blogContext.Teams.ToList());
        }

        public IActionResult Create()
        {
             
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            string name = team.ImageFile.FileName;



            team.Image = FileManager.SaveFile(_env.WebRootPath, "uploads/team", team.ImageFile);

            _blogContext.Teams.Add(team);
            _blogContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            Team team = _blogContext.Teams.Find(id);
            if (team == null) return View("Error");
            return View();
        }
        [HttpPost]
        public IActionResult Update(Team team)
        {
            if(team == null) return View("Error");

            Team existTeam = _blogContext.Teams.FirstOrDefault(x => x.Id == team.Id);

            if(team.Image!=null)


                if (team.ImageFile != null)
                {
                    string name = FileManager.SaveFile(_env.WebRootPath, "uploads/slider", team.ImageFile);
                    existTeam.Image = name;
                }

            existTeam.FullName = team.FullName;
            existTeam.Job = team.Job;
            existTeam.TwitterUrl = team.TwitterUrl;
            existTeam.FacebookUrl = team.FacebookUrl;
            existTeam.InstagramUrl = team.InstagramUrl;

            _blogContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Team team = _blogContext.Teams.FirstOrDefault(x => x.Id == id);
            if (team == null) return View("Error");

            _blogContext.Teams.Remove(team);
            _blogContext.SaveChanges();



            return RedirectToAction("index");
            
        }
    }
}
