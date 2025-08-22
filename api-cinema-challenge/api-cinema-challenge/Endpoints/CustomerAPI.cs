using api_cinema_challenge.DOTs.CustomerDTOs;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repository;
using Microsoft.EntityFrameworkCore;


namespace api_cinema_challenge.Endpoints
{
    public static class CustomerAPI
    {
        public static void ConfigueCustomer(this WebApplication app)
        {
            var customerGroup = app.MapGroup("customer");

            customerGroup.MapGet("/", GetCustomers);
            customerGroup.MapGet("/customer{id}", GetCustomerById);
            customerGroup.MapPost("/", CreateCustomer);
            customerGroup.MapPut("/customer{id}", UpdateCustomer);
            customerGroup.MapDelete("/customer{id}", DeleteCustomer);
        }

        private static async Task<IResult> GetCustomers(IGenericRepository<Customer> repository)
        {
            var response = await repository.GetWithIncludes(q => q.Include(p => p.Tickets).ThenInclude(t => t.Screening).ThenInclude(s => s.Movie));
            var result = response.Select(c => new CustomerGet(c));
            return TypedResults.Ok(result);
        }

        private static async Task<IResult> GetCustomerById(IGenericRepository<Customer> repository, int id)
        {
            var response = await repository.GetByIdWithIncludes(q => q.Where(i => i.Id == id)
                                                                        .Include(p => p.Tickets)
                                                                        .ThenInclude(t => t.Screening)
                                                                        .ThenInclude(s => s.Movie).FirstOrDefaultAsync().Result);
            var result = new CustomerGet(response);

            return TypedResults.Ok(result);
        }

        private static async Task<IResult> CreateCustomer(IGenericRepository<Customer> repository, CustomerPost newCustomer)
        {
            Customer customer = new Customer(newCustomer);
            var response = await repository.Create(customer);
            return TypedResults.Created("", newCustomer);
        }

        private static async Task<IResult> UpdateCustomer(IGenericRepository<Customer> repository, int id, CustomerPut model)
        {
            Customer entity = await repository.GetByIdWithIncludes(q => q.Where(i => i.Id == id)
                                                                        .Include(p => p.Tickets)
                                                                        .ThenInclude(t => t.Screening)
                                                                        .ThenInclude(s => s.Movie).FirstOrDefaultAsync().Result);
            if (model.Name is not null) entity.Name = model.Name;
            if (model.Email is not null) entity.Email = model.Email;
            if (model.Phone is not null) entity.Phone = model.Phone;
            var response = await repository.Update(entity);
            return TypedResults.Created("",new CustomerGet(response));
        }
        private static async Task<IResult> DeleteCustomer(IGenericRepository<Customer> repository, int id)
        {
            Customer entity = await repository.GetByIdWithIncludes(q => q.Where(i => i.Id == id).FirstOrDefaultAsync().Result);
            repository.Delete(entity);
            return TypedResults.Ok(entity);
        }
    }
}
