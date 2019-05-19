using AspApplication.Storage.Core;
using AspApplication.Storage.InMemory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AspApplication
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc()
				.AddMvcOptions(o =>
				{
					o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
				});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc(
					"v1",
					new OpenApiInfo
					{
						Title = "Cities API",
						Version = "v1"
					});
			});

			services.AddLogging();

			services.AddSingleton<ICitiesDataStore>(
				new CitiesDataStore());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStatusCodePages();
			app.UseMvc();
			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cities API v1");
			});
		}
	}
}
