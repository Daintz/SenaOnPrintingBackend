using AutoMapper;

using BusinessCape.DTOs.Finish;
using BusinessCape.DTOs.Machine;


using DataCape;

namespace BusinessCape.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {   
            //============================|Machine|==========================//

            CreateMap<MachineCreateDto, Machine>();

            CreateMap<MachineUpdateDto, Machine>();

            //============================|Finish|==========================//

            CreateMap<FinishDtoCreate, Finish>();

            CreateMap<FinishDtoUpdate, Finish>();
       

         
        }
    }
}
