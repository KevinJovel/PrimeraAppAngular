using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AngularApp.Clases;
using AngularApp.Models;

namespace AngularApp.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("api/Producto/listarProductos")]
        public IEnumerable<ProductoCLS> listarProductos() {
            using (BDRestauranteContext db = new BDRestauranteContext())
            { 
                List<ProductoCLS> lista=( from producto in db.Producto
                                         join categoria in db.Categoria
                                         on producto.Iidcategoria equals
                                         categoria.Iidcategoria
                                         select new ProductoCLS
                                         { idProducto=producto.Iidproducto,
                                         nombre=producto.Nombre,
                                         precio=(decimal)producto.Precio,
                                         stock=(int)producto.Stock,
                                         nombreCategoria=categoria.Nombre
                                         }).ToList();
                return lista;
            }
        }
    }
}