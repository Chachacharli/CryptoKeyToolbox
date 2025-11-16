using CryptoKeyToolbox.App.Services;
using CryptoKeyToolbox.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoKeyToolbox.Infrastructure.Infra
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddCryptoKeyToolboxServices(this IServiceCollection services)
		{
			services.AddScoped<ISSHKeyService, SSHKeyService>();

			return services;
		}
	}
}
