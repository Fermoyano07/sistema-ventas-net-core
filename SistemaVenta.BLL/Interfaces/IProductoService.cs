using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVenta.Entity;
using SistemaVenta.Entity.Models;

namespace SistemaVenta.BLL.Interfaces
{
    public interface IProductoService
    {
        Task<List<Producto>> Lista();
        Task<Producto> Crear(Producto entidad, Stream imagen = null, string NombreImagen = "");
        Task<Producto> Editar(Producto entidad, Stream imagen = null);
        Task<bool> Eliminar(int idProducto);
    }
}
