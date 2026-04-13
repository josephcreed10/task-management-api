using AutoMapper;
using TaskManagement_API.Entities;
using TaskManagement_API.Models.DTOs;
namespace TaskManagement_API.Profiles
{
    public class TaskProfile: Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskCreateDTO, TaskItem>();
            CreateMap<TaskUpdateDTO, TaskItem>();
            CreateMap<TaskReadDTO, TaskItem>().ReverseMap();
        }
    }
}
