using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async void CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            string query = " insert into Employee (Name, Title, Mail, PhoneNumber, ImageUrl, Status ) values (@Name, @Title, @Mail, @PhoneNumber, @ImageUrl, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", createEmployeeDto.Name);
            parameters.Add("@Title", createEmployeeDto.Title);
            parameters.Add("@Mail", createEmployeeDto.Mail);
            parameters.Add("@PhoneNumber", createEmployeeDto.PhoneNumber);
            parameters.Add("@ImageUrl", createEmployeeDto.ImageUrl);
            parameters.Add("@Status", createEmployeeDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteEmployee(int id)
        {
            string query = " Delete from Employee where EmployeeID=@employeeID ";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);   
            }   
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = " Select * From Employee ";
            using (var connection = _context.CreateConnection())
            {
                var values= await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDEmployeeDto> GetEmployee(int id)
        {
            string query = " Select * From Employee where  EmployeeID=@employeeID ";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using ( var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = " Update Employee Set Name=@Name, Title=@Title, Mail=@Mail, PhoneNumber=@PhoneNumber, ImageUrl=@ImageUrl, Status=@Status Where EmployeeID=@EmployeeID ";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", updateEmployeeDto.Name);
            parameters.Add("@Title", updateEmployeeDto.Title);
            parameters.Add("@Mail", updateEmployeeDto.Mail);
            parameters.Add("@PhoneNumber", updateEmployeeDto.PhoneNumber);
            parameters.Add("@ImageUrl", updateEmployeeDto.ImageUrl);
            parameters.Add("@Status", updateEmployeeDto.Status);
            parameters.Add("@EmployeeID", updateEmployeeDto.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
