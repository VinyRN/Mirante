using AutoMapper;
using Mirante.ToDo.Core.Dto.Request;
using Mirante.ToDo.Core.Dto.Response;
using Mirante.ToDo.Core.Entity;

namespace Mirante.ToDo.Core.MapperProfile
{
    public class ToDoTaskProfile : Profile
    {
        public ToDoTaskProfile()
        {
            CreateMap<ToDoTaskRequestDto, ToDoTask>().ReverseMap();
            CreateMap<ToDoTask, ToDoTaskResponseDto>()
                .ForMember(dest => dest.DescricaoStatus,
                           opt => opt.MapFrom(src => src.Status.ToString())).ReverseMap();
        }
    }
}
