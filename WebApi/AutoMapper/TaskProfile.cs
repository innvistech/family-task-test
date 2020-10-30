using AutoMapper;
using Domain.Commands;
using Domain.DataModels;
using Domain.ViewModel;

namespace WebApi.AutoMapper
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<CreateTaskCommand, Task>()
                .ForMember(vm => vm.AssignedToId, m => m.MapFrom(u => u.AssignedMemberId));
            CreateMap<CompleteTaskCommand, Task>();
            CreateMap<AssignTaskCommand, Task>()
                .ForMember(vm => vm.AssignedToId, m => m.MapFrom(u => u.AssignedMemberId));
            CreateMap<Task, TaskVm>()
                .ForMember(vm => vm.AssignedMemberId, m => m.MapFrom(u => u.AssignedToId))
                .ForMember(vm => vm.AssignedMember, m => m.MapFrom(u => u.AssignedTo));
        }
    }
}
