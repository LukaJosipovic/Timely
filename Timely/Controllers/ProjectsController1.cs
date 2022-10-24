using Microsoft.AspNetCore.Mvc;
using Timely.Context;
using Timely.Dal;
using Timely.Models;

namespace Timely.Controllers
{
    public class ProjectsController1 : Controller
    {
        private readonly IRepository repository;

        public ProjectsController1(IRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            
            return View(repository.GetProjects());
        }

        [HttpPost]
        public IActionResult Add(IFormCollection form)
        {
            repository.AddProject(form);
            return RedirectToAction("Add");
        }

        public IActionResult Update(IFormCollection form)
        {
            repository.UpdateProject(form);
            return RedirectToAction("Add");
        }

        public IActionResult Delete(int id)
        {

            repository.DeleteProject(id);
            return RedirectToAction("Add");
        }
        private static string GenerateDate(IFormCollection form)
        {
            return form["Date"] + " " + form["Time"];
        }
    }
}
