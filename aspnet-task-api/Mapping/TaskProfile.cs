using aspnet_task_api.DTOs;
using aspnet_task_api.Models;
using AutoMapper;

namespace aspnet_task_api.Mapping
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskItem, TaskReadDto>();
            CreateMap<TaskCreateDto, TaskItem>();
            CreateMap<TaskUpdateDto, TaskItem>();
        }
    }
}
