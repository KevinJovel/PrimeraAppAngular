using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AngularApp.Clases;
using AngularApp.Models;


namespace AngularApp.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("api/Categoria/listarCategorias")]
        public IEnumerable<CategoriaCLS> listarCategorias(){
            using (var db = new BDRestauranteContext()) {
                IEnumerable<CategoriaCLS> listarCategoria = (from categoria in db.Categoria
                                                             where categoria.Bhabilitado == 1
                                                             select new CategoriaCLS
                                                             {
                                                                 idCategoria = categoria.Iidcategoria,
                                                                 nombre = categoria.Nombre
                                                             }).ToList();
                return listarCategoria;
                    }
        }
  
    }
}