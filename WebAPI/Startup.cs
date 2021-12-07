using DataAccess;
using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Schedule;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MySqlContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("MySqlContext")));

            //services.AddSingleton(typeof(IRepository<>), typeof(BaseRepository<>));       

            //组件具有依赖项，则可以从服务集合构建服务提供程序并从中获取必要的依赖项
            //IServiceProvider provider = services.BuildServiceProvider();

            //MySqlContext dbContext = provider.GetRequiredService<MySqlContext>();
            //services.AddSingleton<IUserRepository>(new UserRepository(dbContext));

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddControllers();

            //services.AddQuartz(typeof(QuartzJob));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //QuartzService.StartJob<QuartzJob>();
        }
    }
}
