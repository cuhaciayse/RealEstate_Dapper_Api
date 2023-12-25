using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository:IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async void CreateService(CreateServiceDto createServiceDto)
        {
            string query = " insert into Service (ServiceName, ServiceStatus) values (@ServiceName, @ServiceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceName", createServiceDto.ServiceName);
            parameters.Add("@ServiceStatus", createServiceDto.ServiceStatus);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteService(int id)
        {
            string query = "Delete From Service Where ServiceID=@serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }


        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "Select * From Service";
            using(var connection=_context.CreateConnection())
            {
                var values=await connection.QueryAsync<ResultServiceDto>(query);    
                return values.ToList(); 
            }
        }

        public async Task<GetByIDServiceDto> GetService(int id)
        {
            string query = " Select * From Service where ServiceID=@ServiceID";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceID", id);
            using (var connection = _context.CreateConnection())
            {
                var values= await connection.QueryFirstOrDefaultAsync<GetByIDServiceDto>(query , parameters);
                return values;
            }
        }

        public async void UpdateService(UpdateServiceDto updateServiceDto)
        {
            string query = " Update Service Set ServiceName=@ServiceName, ServiceStatus=@ServiceStatus where ServiceID=@ServiceID";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceName", updateServiceDto.ServiceName);
            parameters.Add("@ServiceStatus", updateServiceDto.ServiceStatus);
            parameters.Add("@ServiceID", updateServiceDto.ServiceID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
