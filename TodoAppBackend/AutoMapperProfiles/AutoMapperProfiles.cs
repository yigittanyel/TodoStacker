using AutoMapper;
using TodoAppBackend.DTOs;
using TodoAppBackend.Models;

namespace TodoAppBackend.AutoMapperProfiles;

public class AutoMapperProfiles: Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<TodoItemCreateDto, TodoItem>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.title))
            .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.isCompleted));

        CreateMap<TodoItem, TodoItemDto>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.isCompleted, opt => opt.MapFrom(src => src.IsCompleted));
    }
}
