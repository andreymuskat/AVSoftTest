using AVSoftTest.BLL.Models;

namespace AVSoftTest.BLL.Interfaces
{
    public interface ICounterManager
    {
        public List<CounterModelBLL> GetAllCounters();

        public void AddCounter(CounterModelBLL counter);

        public List<CountOfKeyAndValueGreaterThanOneModelBLL> GetCountOfKeyAndValueGreaterThanOne();
        
    }
}
