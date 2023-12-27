using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository:IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = " insert into PopularLocation (CityName, ImageUrl) values (@CityName, @ImageUrl)";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new
                {
                    createPopularLocationDto.CityName,
                    createPopularLocationDto.ImageUrl
                });
            }
        }

        public async void DeletePopularLocation(int id)
        {
            string query = " Delete From PopularLocation where LocationID= @LocationID";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { @LocationID = id });
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
                string query = "SELECT * FROM PopularLocation";
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                    return values.ToList();
                }
        }

        public async Task<GetByIDPopularLocationDto> GetPopularLocation(int id)
        {
            string query = "Select * From PopularLocation where LocationID=@LocationID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDPopularLocationDto>(query, new { LocationID = id });
                return values;
            }
        }

    public async void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            using ( var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(" Update PopularLocation Set CityName=@CityName , ImageUrl=@ImageUrl where LocationID=@LocationID", updatePopularLocationDto);
            }
        }
    }
}
