using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Repository;
using StudentManagement.Client;
using StudentManagement.Client.Services;

namespace StudentManagement.Client;

internal class Program
{
	static async Task Main(string[] args)
	{
		var builder = WebAssemblyHostBuilder.CreateDefault(args);

		builder.Services.AddAuthorizationCore();
		builder.Services.AddCascadingAuthenticationState();
		builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

		builder.Services.AddScoped<IStudentRepository, StudentService>();

		builder.Services.AddScoped(http => new HttpClient
		{
			BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
		});

		await builder.Build().RunAsync();
	}
}
