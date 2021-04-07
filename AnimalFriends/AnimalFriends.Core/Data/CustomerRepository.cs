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
                @"INSERT INTO Customer (
                         FirstName
                        ,Surname
                        ,PolicyReferenceNumber
                        ,DateOfBirth
                        ,Email
                     VALUES (
                         @FirstName
                        ,@Surname
                        ,@PolicyReferenceNumber
                        ,@DateOfBirth
                        ,@Email", customer);
        }
    }
}