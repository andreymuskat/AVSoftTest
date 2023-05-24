using AVSoftTest.DAL.Interfaces;
using AVSoftTest.DAL.Models;

namespace AVSoftTest.DAL
{
    public class CounterRepository : ICounterRepository
    {
        private readonly Context _context;

        public CounterRepository(Context context) 
        {
            _context = context;
        }

        public List<CounterEntity> GetAllCounters()
        {
            return _context.Counters.ToList();
        }

        public void AddCounter(CounterEntity counter)
        {
            _context.Counters.Add(counter);
            _context.SaveChanges();
        }

        public void FirstCode() { 
        }
    }
}
