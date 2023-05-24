using AutoMapper;
using AVSoftTest.BLL.Models;
using AVSoftTest.DAL.Models;

namespace AVSoftTest.BLL
{
    public class MapperBLLProfile: Profile
    {
        public MapperBLLProfile() 
        {
            CreateMap<CounterEntity, CounterModelBLL>().ReverseMap();
        }
    }
}
