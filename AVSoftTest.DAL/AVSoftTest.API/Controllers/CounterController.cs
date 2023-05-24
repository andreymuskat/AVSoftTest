using AutoMapper;
using AVSoftTest.API.Models.Request;
using AVSoftTest.API.Models.Response;
using AVSoftTest.BLL.Interfaces;
using AVSoftTest.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AVSoftTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICounterManager _counterManager;

        public CounterController(IMapper mapper, ICounterManager counterManager)
        {
            _mapper = mapper;
            _counterManager = counterManager;
        }

        [HttpGet(Name = "GetAllCounters")]
        public IActionResult GetAllCounters()
        {
            try
            {
                var counters = _counterManager.GetAllCounters();
                var result = _mapper.Map<List<CounterResponse>>(counters);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddCounter")]
        public ActionResult AddCounter([FromBody] CounterRequest counter)
        {
            try
            {
                var counterBLL = _mapper.Map<CounterModelBLL>(counter);
                _counterManager.AddCounter(counterBLL);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetCountOfKeyAndValueGreaterThanOne", Name = "GetCountOfKeyAndValueGreaterThanOne")]
        public IActionResult GetCountOfKeyAndValueGreaterThanOne()
        {
            try
            {
                var counters = _counterManager.GetCountOfKeyAndValueGreaterThanOne();
                var result = _mapper.Map<List<CountOfKeyAndValueGreaterThanOneResponse>>(counters);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
