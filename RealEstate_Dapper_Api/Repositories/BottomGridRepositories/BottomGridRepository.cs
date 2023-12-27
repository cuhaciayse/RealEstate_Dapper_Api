using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
    public class BottomGridRepository:IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public async void CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            string query = " insert into BottomGrid (Icon, Title, Description) values (@Icon, @Title, @Description)";
            using(var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new
                {
                    createBottomGridDto.Icon,
                    createBottomGridDto.Title,
                    createBottomGridDto.Description
                });
            }
        }

        public async void DeleteBottomGrid(int id)
        {
            string query = " Delete From BottomGrid where BottomGridID=@BottomGridID";
            using(var connection=_context.CreateConnection()) 
            {
                await connection.ExecuteAsync(query, new { BottomGridID = id });  
            }
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "Select * From BottomGrid";
            using(var connection=_context.CreateConnection())
            {
                var values= await connection.QueryAsync<ResultBottomGridDto>(query);    
                return values.ToList(); 
            }
        }

        public async Task<GetBottomGridDto> GetBottomGrid(int id)
        {
            string query = " Select * From BottomGrid where BottomGridID=@BottomGridID";
            using (var connection=_context.CreateConnection()) {
                var values = await connection.QueryFirstOrDefault(query);
                return values.FirstOrDefault();
               }
        }

        public async void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            using(var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync("Update BottomGrid Set Icon=@Icon, Title=@Title, Description=@Description where BottomGridID=@BottomGridID", updateBottomGridDto);
            }
        }
    }
}
