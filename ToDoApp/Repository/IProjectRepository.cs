using ToDoApp.Models.Dtos;

namespace ToDoApp.Repository
{
    public interface IProjectRepository
    {
        Task<ProjectDto> GetProject(string projectName, Guid? userId);
        Task<ProjectDto> GetProjectById(Guid projectId);
        Task<List<ProjectDto>> GetUserProjects(Guid userId);
        Task<ProjectDto> CreateProject(ProjectDto projectDto);
        Task<ProjectDto> UpdateProject(ProjectDto projectDto);
        Task<bool> DeleteProject(Guid projectId);

    }
}
