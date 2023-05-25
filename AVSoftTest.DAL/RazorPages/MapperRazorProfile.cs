using AutoMapper;
using AVSoftTest.BLL.Models;
using RazorPages.Models;


namespace RazorPages
{
	public class MapperRazorProfile : Profile
	{
		public MapperRazorProfile()
		{
			CreateMap<CounterRequest, CounterModelBLL>();
			CreateMap<CounterModelBLL, CounterResponse>();
			CreateMap<CountOfKeyAndValueGreaterThanOneModelBLL, CountOfKeyAndValueGreaterThanOneResponse>();
		}
	}
}
