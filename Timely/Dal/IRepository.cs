using Timely.Models;

namespace Timely.Dal
{
    public interface IRepository
    {
        IEnumerable<Project> GetProjects();
        void DeleteProject(int id);
        void AddProject(IFormCollection form);
        void UpdateProject(IFormCollection form);
    }
}
