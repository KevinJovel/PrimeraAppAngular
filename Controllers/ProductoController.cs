﻿using System;
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
                                          where producto.Bhabilitado == 1
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
        [HttpGet]
        [Route("api/Producto/obtenerProductoPorId/{idProducto}")]
        public ProductoCLS obtenerProductoPorId(int idProducto) {
            try
            {
                using (BDRestauranteContext bd=new BDRestauranteContext())
                {
                    ProductoCLS oProductoCLS = (from producto in bd.Producto
                                                where producto.Bhabilitado == 1
                                                && producto.Iidproducto== idProducto
                                                select new ProductoCLS
                                                {
                                                    idProducto = producto.Iidproducto,
                                                    nombre = producto.Nombre,
                                                    idCategoria = (int) producto.Iidcategoria,
                                                    idMarca = (int) producto.Iidmarca,
                                                    precio = (decimal) producto.Precio,
                                                    stock = (int) producto.Stock
                                                }).First();
                    return oProductoCLS;
                }

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        [HttpGet]
        [Route("api/Producto/listarProductosPorNombre/{nombre}")]
        public IEnumerable<ProductoCLS> listarProductosPorNombre(string nombre)
        {
            using (BDRestauranteContext db = new BDRestauranteContext())
            {
                List<ProductoCLS> lista = (from producto in db.Producto
                                           join categoria in db.Categoria
                                           on producto.Iidcategoria equals
                                           categoria.Iidcategoria
                                           where producto.Bhabilitado==1 && producto.Nombre.ToLower().Contains(nombre.ToLower())  
                                           select new ProductoCLS
                                           {
                                               idProducto = producto.Iidproducto,
                                               nombre = producto.Nombre,
                                               precio = (decimal)producto.Precio,
                                               stock = (int)producto.Stock,
                                               nombreCategoria = categoria.Nombre
                                           }).ToList();
                return lista;
            }
        }
        [HttpGet]
        [Route("api/Producto/listarProductosPorCetegoria/{cat}")]
        public IEnumerable<ProductoCLS> listarProductosPorCategoria(int cat)
        {
            using (BDRestauranteContext db = new BDRestauranteContext())
            {
                List<ProductoCLS> lista = (from producto in db.Producto
                                           join categoria in db.Categoria
                                           on producto.Iidcategoria equals
                                           categoria.Iidcategoria
                                           where producto.Bhabilitado == 1 &&
                                           producto.Iidcategoria == cat
                                           select new ProductoCLS
                                           {
                                               idProducto = producto.Iidproducto,
                                               nombre = producto.Nombre,
                                               precio = (decimal)producto.Precio,
                                               stock = (int)producto.Stock,
                                               nombreCategoria = categoria.Nombre
                                           }).ToList();
                return lista;
            }
        }
        [HttpGet]
        [Route("api/Producto/listarMarcas")]
        public IEnumerable<MarcaCLS> listarMarcas() {
            using (BDRestauranteContext bd = new BDRestauranteContext()) {
                List<MarcaCLS> listaMarca = (from Marca in bd.Marca
                                             where Marca.Bhabilitado == 1
                                             select new MarcaCLS
                                             {
                                                 idMarca = Marca.Iidmarca,
                                                 nombre = Marca.Nombre
                                             }).ToList();
                return listaMarca;
            }
        }
        [HttpPost]
        [Route("api/Producto/registrarProducto")]
        public int registrarProducto([FromBody]ProductoCLS oProductoCLS) {
            int rpta = 0;
            try
            {
                using (BDRestauranteContext bd = new BDRestauranteContext()) {
                    if (oProductoCLS.idProducto == 0)
                    {
                        Producto oProducto = new Producto();
                        oProducto.Nombre = oProductoCLS.nombre;
                        oProducto.Precio = oProductoCLS.precio;
                        oProducto.Stock = oProductoCLS.stock;
                        oProducto.Iidmarca = oProductoCLS.idMarca;
                        oProducto.Iidcategoria = oProductoCLS.idCategoria;
                        oProducto.Bhabilitado = 1;
                        bd.Producto.Add(oProducto);
                        bd.SaveChanges();
                        rpta = 1;
                    }else{
                        Producto oProducto = bd.Producto.Where(p => p.Iidproducto == oProductoCLS.idProducto).First();
                        oProducto.Nombre = oProductoCLS.nombre;
                        oProducto.Precio = oProductoCLS.precio;
                        oProducto.Stock = oProductoCLS.stock;
                        oProducto.Iidmarca = oProductoCLS.idMarca;
                        oProducto.Iidcategoria = oProductoCLS.idCategoria;
                        bd.SaveChanges();
                        rpta = 1;
                    }
                    return rpta;
                }

            }
            catch (Exception ex)
            {
                rpta = 0;
            }
            return rpta;
        }
        [HttpGet]
        [Route("api/Producto/eliminarProducto/{idProducto}")]
        public int eliminarProducto(int idProducto) {
            int rpta = 0;
            try
            {
                using (BDRestauranteContext bd = new BDRestauranteContext()) {
                    Producto oProducto = bd.Producto.Where(p => p.Iidproducto == idProducto).First();
                    oProducto.Bhabilitado = 0;
                    bd.SaveChanges();
                    rpta = 1;
                }
                    rpta = 1;
            }
            catch (Exception)
            {

                rpta = 0;
            }
            return rpta;
        }
   
    }
}