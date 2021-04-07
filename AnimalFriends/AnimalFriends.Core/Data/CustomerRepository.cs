using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace AnimalFriends.Core.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _dbConnection;

        public CustomerRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> SaveCustomerAsync(CustomerDto customer, CancellationToken cancellationToken = default)
        {
            return await _dbConnection.ExecuteScalarAsync<int>(
                @"INSERT INTO dbo.Customers (
                         Firstname
                        ,Surname
                        ,PolicyReferenceNumber
                        ,DateOfBirth
                        ,Email
                     ) 
                     VALUES (
                         @Firstname
                        ,@Surname
                        ,@PolicyReferenceNumber
                        ,@DateOfBirth
                        ,@Email
                     );
                     SELECT SCOPE_IDENTITY();", customer);
        }
    }
}