using AVSoftTest.DAL.Models;

namespace AVSoftTest.DAL.Interfaces
{
    public interface ICounterRepository
    {
        public List<CounterEntity> GetAllCounters();

        public void AddCounter(CounterEntity counters);
    }
}
