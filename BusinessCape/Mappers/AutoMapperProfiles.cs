using AutoMapper;

using BusinessCape.DTOs.Finish;
using BusinessCape.DTOs.Machine;
using BusinessCape.DTOs.UnitMesureCreate;
using BusinessCape.DTOs.UnitMesureUpdate;
using DataCape;

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

            CreateMap<UnitMesureCreate, UnitMeasureModel>();

            CreateMap<UnitMesureUpdate, UnitMeasureModel>();




        }
    }
}
