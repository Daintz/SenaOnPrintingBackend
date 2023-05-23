using AutoMapper;
using BusinessCape.DTOs.Finish;
using BusinessCape.DTOs.Machine;

using DataCape.Models;

namespace BusinessCape.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
           
       
            //============================|Machine|==========================//

            CreateMap<MachineCreateDto, MachineModel>();

            CreateMap<MachineUpdateDto, MachineModel>();

            //============================|Finish|==========================//

            CreateMap<FinishDtoCreate, FinishModel>();

            CreateMap<FinishDtoUpdate, FinishModel>();

        }
    }
}
