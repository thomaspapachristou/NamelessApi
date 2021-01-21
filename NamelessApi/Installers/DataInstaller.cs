using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NamelessApi.Data;
using NamelessApi.Services;

namespace NamelessApi.Installers
{
    public class DataInstaller : IInstaller
    {

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataContext>();


            // A la base on utilise un AddSingleton mais puisqu'on ne peut pas ajouter un scope service, nous le modifions
            services.AddScoped<IGameService, GameService>();

        }

    }
}
