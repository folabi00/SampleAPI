
using SampleAPI.Data;

namespace SampleAPI.Models.Repository
{
    public class StockRepository
    {
        private static AppDbContext db;
        private static int _nextId = 1;
        public static  List<Stock> _stocks = new List<Stock>()
        {
                
        };

        public static bool StockExists(int id)
        {
            return db.Stocks.Any(s => s.Id.Equals(id));
        }
        public static bool StockNameExists(string name)
        {
            return db.Stocks.Any(s => s.Name.Equals(name));
        }
        public static Stock? IsValid(int id)
        {
            return db.Stocks.FirstOrDefault(s => s.Id.Equals(id));

        }
        public static Stock AddStock(Stock newStock)
        {
            newStock.Id = _nextId++;
            _stocks.Add(newStock);
            return newStock;
        }


    }
}
