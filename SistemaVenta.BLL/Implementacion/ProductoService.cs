using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SistemaVenta.BLL.Interfaces;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.Entity;
using SistemaVenta.Entity.Models;
using SistemVenta.DAL.Implementacion;
using SistemVenta.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.BLL.Implementacion
{
    public class ProductoService : IProductoService
    {
        private readonly IGenericRepository<Producto> _repository;
        private readonly IFireBaseService _fireBaseService;

        public ProductoService(IGenericRepository<Producto> repositorio,
            IFireBaseService fireBaseService)
        {
            _repository = repositorio;
            _fireBaseService = fireBaseService;
        }

        public async Task<List<Producto>> Lista()
        {
            IQueryable<Producto> query = await _repository.Consultar();
            return query.Include(c=>c.IdCategoriaNavigation).ToList();
        }
        public async Task<Producto> Crear(Producto entidad, Stream imagen = null, string NombreImagen = "")
        {
            Producto producto_existe = await _repository.Obtener(p => p.CodigoBarra == entidad.CodigoBarra);

            if (producto_existe != null)
                throw new TaskCanceledException("El código de barra ya existe");

            try
            {
                entidad.NombreImagen = NombreImagen;
                if (imagen != null)
                {
                    string urlImagen = await _fireBaseService.SubirStorage(imagen, "carpeta_producto", NombreImagen);
                    entidad.UrlImagen = urlImagen;
                }

                Producto producto_creado = await _repository.Crear(entidad);

                if (producto_creado.IdProducto == 0)
                    throw new TaskCanceledException("No se pudo crear el producto");

                IQueryable<Producto> query = await _repository.Consultar(p => p.IdProducto == producto_creado.IdProducto);

                producto_creado = query.Include(c => c.IdCategoriaNavigation).First();

                return producto_creado;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<Producto> Editar(Producto entidad, Stream imagen = null)
        {
            Producto producto_existe = await _repository.Obtener(p => p.CodigoBarra == entidad.CodigoBarra && p.IdProducto != entidad.IdProducto);

            if (producto_existe != null)
                throw new TaskCanceledException("El código de barra ya existe");

            try 
            {
                IQueryable<Producto> queryProducto = await _repository.Consultar(p => p.IdProducto == entidad.IdProducto);

                Producto producto_para_editar = queryProducto.First();

                producto_para_editar.CodigoBarra = entidad.CodigoBarra;
                producto_para_editar.Marca = entidad.Marca;
                producto_para_editar.Descripcion = entidad.Descripcion;
                producto_para_editar.IdCategoria = entidad.IdCategoria;
                producto_para_editar.Stock = entidad.Stock;
                producto_para_editar.Precio = entidad.Precio;
                producto_para_editar.EsActivo = entidad.EsActivo;

                if (imagen != null) 
                {
                    string urlImagen = await _fireBaseService.SubirStorage(imagen, "carpeta_producto", producto_para_editar.NombreImagen);
                    producto_para_editar.UrlImagen = urlImagen;
                }

                bool respuesta = await _repository.Editar(producto_para_editar);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar el producto");

                Producto producto_editado = queryProducto.Include(c => c.IdCategoriaNavigation).First();

                return producto_editado;
                
            }
            catch (Exception ex) { throw; }
        }

        public async Task<bool> Eliminar(int idProducto)
        {
            try 
            {
                Producto producto_encontrado = await _repository.Obtener(p => p.IdProducto == idProducto);

                if (producto_encontrado == null)
                    throw new TaskCanceledException("El producto no existe");

                string nombreImagen = producto_encontrado.NombreImagen;

                bool respuesta = await _repository.Eliminar(producto_encontrado);

                if (respuesta)
                    await _fireBaseService.EliminarStorage("carpeta_producto", nombreImagen);

                return true;
            }
            catch (Exception ex) { throw; }
        }

        
    }
}
