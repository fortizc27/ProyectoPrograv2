using DB;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBL;

namespace Programacion61
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
