using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ToDoApp.DbContexts;
using ToDoApp.Models;
using ToDoApp.Models.Dtos;

namespace ToDoApp.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;
        public ProjectRepository(AppDbContext db, IMapper mapper) 
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProjectDto> GetProject(string projectName, Guid? userId)
        {
            Project project = await _db.Projects
                .Include(b => b.Duties)
                .Where(x => x.UserId == userId && x.Title == projectName )
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<ProjectDto> GetProjectById(Guid projectId)
        {
            Project project = await _db.Projects.Where(x => x.ProjectId == projectId).FirstOrDefaultAsync();

            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<List<ProjectDto>> GetUserProjects(Guid userId)
        {
            List<Project> projectsList = await _db.Projects.Where(x => x.UserId == userId).ToListAsync();

            return _mapper.Map<List<ProjectDto>>(projectsList);
        }
        public async Task<ProjectDto> CreateProject(ProjectDto projectDto)
        {
            Project project = _mapper.Map<Project>(projectDto);
            _db.Projects.Add(project);

            await _db.SaveChangesAsync();
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<bool> DeleteProject(Guid projectId)
        {
            try
            {
                Project project = await _db.Projects.Where(x => x.ProjectId == projectId).FirstOrDefaultAsync();
                _db.Projects.Remove(project);

                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<ProjectDto> UpdateProject(ProjectDto projectDto)
        {
            Project projectToUpdate = await _db.Projects.Where(x => x.ProjectId == projectDto.ProjectId).FirstOrDefaultAsync();

            projectToUpdate.Title = projectDto.Title;
            projectToUpdate.Description = projectDto.Description;
            
            _db.Update(projectToUpdate);
            await _db.SaveChangesAsync();

            return _mapper.Map<ProjectDto>(projectToUpdate);
        }
    }
}
