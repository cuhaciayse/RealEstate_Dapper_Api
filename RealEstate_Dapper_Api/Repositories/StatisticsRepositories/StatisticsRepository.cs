using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }

        public int ActiveCategoryCount()
        {
            string query = "Select Count(*) From Category where CategoryStatus=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = " Select count (*) from Employee where Status=1 ";
            using (var connection = _context.CreateConnection())
            {
                var values= connection.QueryFirstOrDefault<int>(query);
                return values;  
            }
        }

        public int ApartmentCount()
        {
            string query = "Select Count(*) From Product where Title like '%Daire%'";
            using (var connection = _context.CreateConnection()) 
            { 
                var values= connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal AverageProductPriceByRent()
        {
            string query = "select AVG(Price) from Product where Type='Kiralık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public decimal AverageProductPriceBySale()
        {
            string query = "select AVG(Price) from Product where Type='Satılık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public int AvereageRoomCount()
        {
            string query = "select AVG(RoomCount) from ProductDetails";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int CategoryCount()
        {
            string query = "select COUNT(*) from Category";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string CategoryNameByMaxProductCount()
        {
            string query = "Select top(1) CategoryName,Count(*) From Product inner join Category On Product.ProductCategory=Category.CategoryID Group By CategoryName order by Count(*) Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string CityNameByMaxProductCount()
        {
            string query = "SELECT City, COUNT(*) AS 'İlan_Sayısı' FROM Product GROUP BY City ORDER BY İlan_Sayısı DESC";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int DifferentCityCount()
        {
            string query = "Select Count(Distinct(City)) From Product ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string EmployeeNameByMaxProductCount()
        {
            string query = "Select EmployeeID, COUNT(*) From Product group by EmployeeID";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public decimal LastProductPrice()
        {
            string query = "Select Top(1) Price From Product order by ProductID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public string NewestBuildingYear()
        {
            string query = "Select Top(1) BuildYear From ProductDetails order by BuildYear desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string OldestBuildingYear()
        {
            string query = "Select Top(1) BuildYear From ProductDetails order by BuildYear asc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int PassiveCategoryCount()
        {
            string query = "Select Count(*) From Category Where CategoryStatus=0";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ProductCount()
        {
            string query = "Select Count(*) From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
    }
}
