using AutoMapper;
using AVSoftTest.BLL.Interfaces;
using AVSoftTest.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RazorPages.Models;

namespace RazorPages.Controllers
{
	public class CounterController : Controller
	{
		private readonly IMapper _mapper;
		private readonly ICounterManager _counterManager;

		public CounterController(IMapper mapper, ICounterManager counterManager)
		{
			_mapper = mapper;
			_counterManager = counterManager;
		}

		public ActionResult Index()
		{
			return View();
		}

		public JsonResult GetAllCounters()
		{
			var counters = _counterManager.GetAllCounters();
			var result = _mapper.Map<List<CounterResponse>>(counters);


			var json = JsonConvert.SerializeObject(result);
			return Json(json);
		}

        public JsonResult GetCountOfKeyAndValueGreaterThanOne()
        {
            var counters = _counterManager.GetCountOfKeyAndValueGreaterThanOne();
            var result = _mapper.Map<List<CountOfKeyAndValueGreaterThanOneResponse>>(counters);

            var json = JsonConvert.SerializeObject(result);
            return Json(json);
        }

        public ActionResult AddCounter([FromBody] CounterRequest counter)
        {
                var counterBLL = _mapper.Map<CounterModelBLL>(counter);
                _counterManager.AddCounter(counterBLL);

                return Ok();
        }
    }
}
