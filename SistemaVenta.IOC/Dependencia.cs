using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.DAL.DbContext;
//using SistemaVenta.DAL.Interfaces;
//using SistemaVenta.DAL.Implementacion;
//using SistemaVenta.BLL.Interfaces;
//using SistemaVenta.BLL.Implementacion;

namespace SistemaVenta.IOC
{
    public static class Dependencia
    {
        //Cadena de Conexión
        public static void InyectarDependencia(this IServiceCollection services, IConfiguration Configuration) {
            services.AddDbContext<DbventaContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CadenaSQL"));
            });
        }


    }
}
