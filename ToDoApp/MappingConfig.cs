using AutoMapper;
using ToDoApp.Models;
using ToDoApp.Models.Dtos;
using ToDoApp.Models.ViewModels;

namespace ToDoApp
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<UserDto, User>();
				config.CreateMap<User, UserDto>();
				config.CreateMap<SchedulerDto, Scheduler>();
				config.CreateMap<Scheduler, SchedulerDto>();
				config.CreateMap<ProjectDto, Project>();
				config.CreateMap<Project, ProjectDto>();
				config.CreateMap<DutyDto, Duty>();
				config.CreateMap<Duty, DutyDto>();
				config.CreateMap<EventDto, Event>();
				config.CreateMap<Event, EventDto>();
			});

			return mappingConfig;
		}
	}
}
