using Timely.Context;
using Timely.Models;

namespace Timely.Dal
{
    public class DBRepository : IRepository
    {
        DataContext db;
        public DBRepository(DataContext db)
        {
            this.db = db;
        }
        public void AddProject(IFormCollection form)
        {
            string date = GenerateDate(form);

            db.Projects.Add(new Project
            {
                StartDate = Convert.ToDateTime(date)
            });
            db.SaveChanges();
        }


        public void DeleteProject(int id)
        {
            Project project = db.Projects.FirstOrDefault(element => element.ProjectId == id);
            if (project != null)
            {
                db.Remove(project);
                db.SaveChanges();
            }
        }

        public IEnumerable<Project> GetProjects()
        {
            IEnumerable<Project> projects = db.Projects.Select(element => element).ToList();
            return projects;
        }

        public void UpdateProject(IFormCollection form)
        {
            string name = form["Name"];
            string date = GenerateDate(form);

            var update = db.Projects.Where(element => element.ProjectName == null && element.StopDate == null && element.Duration == null).FirstOrDefault();
            if (update != null)
            {
                update.ProjectName = name;
                update.StopDate = Convert.ToDateTime(date);
                update.Duration = update.StopDate - update.StartDate; 
                db.SaveChanges();
            }
        }
        private string GenerateDate(IFormCollection form)
        {
            return form["Date"] + " " + form["Time"];
        }
    }
}
