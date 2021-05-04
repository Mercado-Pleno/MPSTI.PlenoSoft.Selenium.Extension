using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace PlenoChatBot.DialogFlow
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints => endpoints.MapControllers());
			app.UseStaticFiles();
			app.UseStaticFiles(GetStaticFileOptions("/pages", "./static-files/"));
		}

		public static StaticFileOptions GetStaticFileOptions(string requestPath, string relativePath = null)
		{
			var directoryInfo = new DirectoryInfo(relativePath ?? "./static-files/");
			return new StaticFileOptions
			{
				RequestPath = requestPath,
				DefaultContentType = "plain/text",
				ServeUnknownFileTypes = true,
				HttpsCompression = HttpsCompressionMode.DoNotCompress,
				FileProvider = new PhysicalFileProvider(directoryInfo.FullName),
			};
		}
	}
}