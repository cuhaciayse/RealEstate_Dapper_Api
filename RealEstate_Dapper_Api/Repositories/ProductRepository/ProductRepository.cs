using Dapper;
using RealEstate_Dapper_Api.Dtos.ProdctDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using(var connection= _context.CreateConnection()) 
            {
                var values= await connection.QueryAsync<ResultProductDto>(query);   
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID,Title,Price,City,District,CategoryName,CoverImage,Type,Address,DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var connection= _context.CreateConnection()) 
            {
                var values= await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "Select Top(5) ProductID, Title, Price,City, District,ProductCategory, CategoryName, AdvertisementDate From Product inner join Category on Product.ProductCategory=Category.CategoryID Where Type='Kiralık' order by ProductID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public void ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay=0  where ProductID=@productID";
            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, new { ProductID = id });
            }
        }

        public void ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update Product Set DealOfTheDay=1  where ProductID=@productID";
            using ( var connection = _context.CreateConnection())
            {
                connection.Execute(query , new { ProductID = id });
            }
        }

        public async Task<IEnumerable<ResultProductDto>> SearchProductsByCityAsync(string city)
        {
            string query = "SELECT * FROM Product WHERE City = @City";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query, new { City = city });
                return values.ToList();
            }
        }
    }
}
