using AutoMapper;
using GymCore.Dto.Incoming.Attendence;
using GymCore.Dto.Incoming.SubcriptionCategory;
using GymCore.Dto.Incoming.Trainee;
using GymCore.Dto.Outcoming.Trainee;
using GymCore.Entities;

namespace GymApi.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<TraineeInDto, Trainee>();
            CreateMap<Trainee, TraineeOutDto>().ForMember(p => p.SCName, x => x.MapFrom(z => z.subscriptionCategory.Name));
            CreateMap<Trainee, TraineeDetailsOutDto>().ForMember(p => p.SCName, x => x.MapFrom(z => z.subscriptionCategory.Name)).
                ForMember(p => p.Price, x => x.MapFrom(z => z.subscriptionCategory.Price)).
                ForMember(p => p.Attendences, x => x.MapFrom(z => z.Attendences.Where(y=>y.TraineeId==z.Id).ToList()));
            CreateMap<UpdateTraineeDto, TraineeOutDto>();
            CreateMap<UpdateTraineeDto, Trainee>();
            CreateMap<AddAttendenceDto, Attendence>().ForMember(p => p.TraineeId, x => x.MapFrom(z => z.TraineeId));
            CreateMap<AddSubCategoryDto, SubscriptionCategory>();
            CreateMap<SubscribtionCategory, SubscriptionCategory>();
        }
    }
}
