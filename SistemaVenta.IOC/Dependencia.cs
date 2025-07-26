﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.DAL.DbContext;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.DAL.Implementacion;
using SistemVenta.DAL.Interfaces;
using SistemVenta.DAL.Implementacion;
using SistemaVenta.BLL.Interfaces;
using SistemaVenta.BLL.Implementacion;

namespace SistemaVenta.IOC
{
    public static class Dependencia
    {
        //Cadena de Conexión
        public static void InyectarDependencia(this IServiceCollection services, IConfiguration Configuration) {
            services.AddDbContext<DbVentaContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CadenaSQL"));
            });

            //Registrar Ventas y realizar reportes
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IVentaRepository, VentaRepository>();

            //Enviar correos
            services.AddScoped<ICorreoService, CorreoService>();

            //Servicio de FireBase Storage
            services.AddScoped<IFireBaseService, FireBaseService>();

            //Servicio de utilizades
            services.AddScoped<IUtilidadesService, UtilidadesService>();
            
            //Servicio de Roles
            services.AddScoped<IRolService, RolService>();

            //Servicio de usuario
            services.AddScoped<IUsuarioService, UsuarioService>();

        }
    }
}
