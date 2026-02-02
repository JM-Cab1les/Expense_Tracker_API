using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Application.Helper;
using ExpenseTracker.Infrastructure.Persistence;
using ExpenseTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<ExpenseTracker_DBContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IExpensesRepository, ExpenseRepositories>();
            services.AddScoped<IUserRepository, UserRepositories>();
            services.AddScoped<IBudgetRepository, BudgetRepositories>();
            services.AddScoped<JwtTokenHelper>();

            return services;
        }
    }
}
