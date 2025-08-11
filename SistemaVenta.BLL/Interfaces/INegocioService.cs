﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVenta.Entity;
using SistemaVenta.Entity.Models;

namespace SistemaVenta.BLL.Interfaces
{
    public interface INegocioService
    {
        Task<Negocio> Obtener();

        Task<Negocio> GuardarCambios(Negocio entidad, Stream Logo = null, string NombreLogo = "");

    }
}
