using System.Diagnostics.Metrics;
using AutoMapper;
using AVSoftTest.BLL.Interfaces;
using AVSoftTest.BLL.Models;
using AVSoftTest.DAL.Interfaces;
using AVSoftTest.DAL.Models;

namespace AVSoftTest.BLL
{
    public class CounterManager: ICounterManager
    {
        private readonly ICounterRepository _counterRepository;
        private readonly IMapper _mapper;

        public CounterManager(ICounterRepository counterRepository, IMapper mapper) 
        {
            _counterRepository = counterRepository;
            _mapper = mapper;
        }

        public List<CounterModelBLL> GetAllCounters()
        {
            var countersEntity = _counterRepository.GetAllCounters();
            var resulte = _mapper.Map<List<CounterModelBLL>>(countersEntity);
            return resulte;
        }

        public void AddCounter(CounterModelBLL counter)
        {
            var counterEntity = _mapper.Map<CounterEntity>(counter);
            _counterRepository.AddCounter(counterEntity);
        }

        public List<CountOfKeyAndValueGreaterThanOneModelBLL> GetCountOfKeyAndValueGreaterThanOne()
        {
            var countersValueGreaterThanOne = _counterRepository.GetAllCounters().ToList();
            var countersOfDistinctKey = countersValueGreaterThanOne.GroupBy(m => m.Key)
                                         .Select(g => g.First())
                                         .ToList();

            var result = new List<CountOfKeyAndValueGreaterThanOneModelBLL>();
            foreach (var counter in countersOfDistinctKey)
            {
                result.Add(new CountOfKeyAndValueGreaterThanOneModelBLL { Key = counter.Key});
            }

            foreach(var counter in countersValueGreaterThanOne)
            {
                foreach(var counterRes in result)
                {
                    if (counterRes.Key == counter.Key)
                    {
                        counterRes.Count++;

                        if (counter.Value > 1)
                            counterRes.CountMoreThenOne++;
                    }
                }
            }

            return result;
        }
    }
}
