using AutoMapper;
using AVSoftTest.API.Models.Request;
using AVSoftTest.API.Models.Response;
using AVSoftTest.BLL.Models;

namespace AVSoftTest.API
{
    public class MapperAPIProfile : Profile
    {
        public MapperAPIProfile()
        {
            CreateMap<CounterRequest, CounterModelBLL>();
            CreateMap<CounterModelBLL, CounterResponse>();
            CreateMap<CountOfKeyAndValueGreaterThanOneModelBLL, CountOfKeyAndValueGreaterThanOneResponse>();
        }
    }
}
