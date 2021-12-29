using DataAccess;
using DataAccess.Repository;
using Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockData;
using WebAPI.Schedule;

namespace WebAPI
{
    public class TestStartup
    {
        public TestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Microsoft.EntityFrameworkCore.Sqlite;
            var dbConnection = new SqliteConnection("Data Source=:memory:");
            dbConnection.Open();

            services.AddDbContext<MySqlContext>(options =>
                options.UseSqlite(dbConnection));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserCourseRepository, UserCourseRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<CourseService>();

            services.AddControllers();

            IServiceProvider provider = services.BuildServiceProvider();

            MySqlContext dbContext = provider.GetRequiredService<MySqlContext>();
            MockMySqlContext.Fillup(dbContext);
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
