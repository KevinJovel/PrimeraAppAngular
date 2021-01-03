using AngularApp.Clases;
using AngularApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;

namespace AngularApp.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("api/Usuario/listarTipoUsuario")]
        public IEnumerable<TipoUsuarioCLS> listarTipoUsuario() {
            using (BDRestauranteContext bd = new BDRestauranteContext()) {
                List<TipoUsuarioCLS> listaTipoUsuario = (from TipoUsuario in bd.TipoUsuario
                                                         where TipoUsuario.Bhabilitado == 1
                                                         select new TipoUsuarioCLS
                                                         {
                                                             idTipoUsuario=TipoUsuario.Iidtipousuario,
                                                             nombre=TipoUsuario.Nombre
                                                         }
                    ).ToList();
                return listaTipoUsuario;
           }
        }
        [HttpPost]
        [Route("api/Usuario/guardarUsuario")]
        public int guardarUsuario([FromBody]UsuarioCLS oUsuarioCLS) {
            int rpta = 0;
            try
            {
                using (BDRestauranteContext bd = new BDRestauranteContext()) {
                    using (var transaccion = new TransactionScope()) {
                        if (oUsuarioCLS.idUsuario == 0)
                        {
                            Usuario oUsuario = new Usuario();
                            oUsuario.Nombreusuario = oUsuarioCLS.nombreUsiario;
                            //cifrar contraseña
                            SHA256Managed sha = new SHA256Managed();
                            string clave = oUsuarioCLS.contra;
                            byte[] dataNoCifrada = Encoding.Default.GetBytes(clave);
                            byte[] dataCifrada= sha.ComputeHash(dataNoCifrada);
                            string claveCifrada=BitConverter.ToString(dataCifrada).Replace("-", "");
                            oUsuario.Contra = claveCifrada;
                            oUsuario.Iidpersona = oUsuarioCLS.idPersona;
                            oUsuario.Iidtipousuario = oUsuarioCLS.idTipoUsuario;
                            oUsuario.Bhabilitado = 1;
                            bd.Usuario.Add(oUsuario);
                           
                            //Modificar persona poner que ya tiene ususario Persona(btieneUsuario de 0 a 1)
                            Persona oPersona = bd.Persona.Where(p => p.Iidpersona == oUsuarioCLS.idPersona).First();
                            oPersona.Btieneusuario = 1;
                            bd.SaveChanges();
                            transaccion.Complete();
                            rpta = 1;
                        }
                        else {
                            Usuario oUsuario = bd.Usuario.Where(p => p.Iidusuario == oUsuarioCLS.idUsuario).First();
                            oUsuario.Nombreusuario = oUsuarioCLS.nombreUsiario;
                            oUsuario.Iidtipousuario = oUsuarioCLS.idTipoUsuario;
                            bd.SaveChanges();
                            transaccion.Complete();
                            rpta = 1;
                        }
                    }
                } 
            }
            catch (Exception ex)
            {

                rpta = 0;
            }
            return rpta;
        }
        [HttpGet]
        [Route("api/Usuario/eliminarUsuario/{idUsuario}")]
        public int eliminarUsuario(int idUsuario) {
            int rpta = 0;
            try
            {
                using (BDRestauranteContext bd=new BDRestauranteContext())
                {
                    Usuario oUsuario = bd.Usuario.Where(p => p.Iidusuario == idUsuario).First();
                    oUsuario.Bhabilitado = 0;
                    bd.SaveChanges();
                    rpta = 1;
                }
            }
            catch (Exception ex)
            {

                rpta = 0;
            }
            return rpta;
        }
        [HttpGet]
        [Route("api/Usuario/RecuperarUsuario/{idUsuario}")]
        public UsuarioCLS RecuperarUsuario(int idUsuario) {
            using (BDRestauranteContext bd = new BDRestauranteContext()) {
                UsuarioCLS oUsuarioCLS = new UsuarioCLS();
                Usuario oUsuario = bd.Usuario.Where(p => p.Iidusuario == idUsuario).First();
                oUsuarioCLS.idUsuario = oUsuario.Iidusuario;
                oUsuarioCLS.nombreUsiario = oUsuario.Nombreusuario;
                oUsuarioCLS.idTipoUsuario = (int)oUsuario.Iidtipousuario;
                return oUsuarioCLS;
            }
        }
        [HttpGet]
        [Route("api/Usuario/listarUsuario")]
        public IEnumerable<UsuarioCLS> listarUsuario() {
            using(BDRestauranteContext bd = new BDRestauranteContext()) {
                List<UsuarioCLS> listaUsuario = (from Usuario in bd.Usuario
                                                 join persona in bd.Persona
                                                 on Usuario.Iidpersona equals persona.Iidpersona
                                                 join TipoUsuario in bd.TipoUsuario
                                                 on Usuario.Iidtipousuario equals TipoUsuario.Iidtipousuario
                                                 where Usuario.Bhabilitado == 1
                                                 select new UsuarioCLS
                                                 {
                                                     idUsuario=Usuario.Iidusuario,
                                                     nombreUsiario=Usuario.Nombreusuario,
                                                     nombrePersona=persona.Nombre+" "+persona.Appaterno+" "+persona.Apmaterno,
                                                     nombreTipoUsuario=TipoUsuario.Nombre
                                                 }).ToList();
                return listaUsuario;
            }
            }
        [HttpGet]
        [Route("api/Usuario/validaUsuario/{idUsuario}/{nombre}")]
        public int validaUsuario(int idUsuario, string nombre) {
            int repta = 0;
            try
            {
                using (BDRestauranteContext bd = new BDRestauranteContext()) {
                    if (idUsuario == 0)
                    {
                        repta = bd.Usuario.Where(p => p.Nombreusuario.ToLower() == nombre.ToLower()).Count();

                    }
                    else {
                        repta = bd.Usuario.Where(p => p.Nombreusuario.ToLower() == nombre.ToLower() && p.Iidusuario!=idUsuario).Count();

                    }
                }
            }
            catch (Exception ex)
            {

                repta = 0;
            }
            return repta;
        }
        [HttpGet]
        [Route("api/Usuario/filtrarUsuarioPorTipo/{idTipo?}")]
        public IEnumerable<UsuarioCLS> filtrarUsuarioPorTipo(int idTipo=0)
        {
            using (BDRestauranteContext bd = new BDRestauranteContext())
            {
                List<UsuarioCLS> listaUsuario = (from Usuario in bd.Usuario
                                                 join persona in bd.Persona
                                                 on Usuario.Iidpersona equals persona.Iidpersona
                                                 join TipoUsuario in bd.TipoUsuario
                                                 on Usuario.Iidtipousuario equals TipoUsuario.Iidtipousuario
                                                 where Usuario.Bhabilitado == 1 && Usuario.Iidtipousuario==idTipo
                                                 select new UsuarioCLS
                                                 {
                                                     idUsuario = Usuario.Iidusuario,
                                                     nombreUsiario = Usuario.Nombreusuario,
                                                     nombrePersona = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                                     nombreTipoUsuario = TipoUsuario.Nombre
                                                 }).ToList();
                return listaUsuario;
            }
        }
        [HttpPost]
        [Route("api/Usuario/login")]
        public UsuarioCLS login([FromBody] UsuarioCLS oUsuarioClS) {
            int rpta = 0;
            using (BDRestauranteContext bd = new BDRestauranteContext())
            {
                UsuarioCLS oUsuario = new UsuarioCLS();
                SHA256Managed sha = new SHA256Managed();
                byte[] dataNoCifrada = Encoding.Default.GetBytes(oUsuarioClS.contra);
                byte[] dataCifrada = sha.ComputeHash(dataNoCifrada);
                string claveCifrada = BitConverter.ToString(dataCifrada).Replace("-", "");
                rpta = bd.Usuario.Where(p => p.Nombreusuario.ToUpper() == oUsuarioClS.nombreUsiario.ToUpper() && p.Contra == claveCifrada).Count();
                if (rpta == 1)
                {
                    Usuario ousuariorecuperar = bd.Usuario.Where(p => p.Nombreusuario.ToUpper() == oUsuarioClS.nombreUsiario.ToUpper() && p.Contra == claveCifrada).First();
                    HttpContext.Session.SetString("usuario", oUsuarioClS.idUsuario.ToString());
                    HttpContext.Session.SetString("tipoUsuario", ousuariorecuperar.Iidtipousuario.ToString());
                    oUsuario.idUsuario = ousuariorecuperar.Iidusuario;
                    oUsuario.nombreUsiario = ousuariorecuperar.Nombreusuario;
                }
                else
                {
                    oUsuario.idUsuario = 0;
                    oUsuario.nombreUsiario = "";
                }
                return oUsuario;
            }
      }
        [HttpGet]
        [Route("api/Usuario/listarPaginas")]
        public List<PaginaCLS> ListarPaginas() {
            List<PaginaCLS> listaPagina = new List<PaginaCLS>();
            int idTipoUsuario = int.Parse( HttpContext.Session.GetString("tipoUsuario"));
            using (BDRestauranteContext bd = new BDRestauranteContext())
            {
                listaPagina = (from paginaTipo in bd.PaginaTipoUsuario
                               join pagina in bd.Pagina
                               on paginaTipo.Iidpagina equals pagina.Iidpagina
                               where paginaTipo.Bhabilitado == 1
                               && paginaTipo.Iidtipousuario == idTipoUsuario
                               select new PaginaCLS
                               {
                                   iidPagina = pagina.Iidpagina,
                                   accion = pagina.Accion,
                                   mensaje = pagina.Mensaje,
                                   bhabilitado = (int)pagina.Bhabilitado

                               }).ToList();

                return listaPagina;


            }
        }

      

       
        [HttpGet]
        [Route("api/Usuario/validarSession")]
        public SeguridadCLS obtenervariableSession() {
            SeguridadCLS oSeguridad = new SeguridadCLS();
           string variableSession= HttpContext.Session.GetString("usuario");
            if (variableSession == null)
            {
                oSeguridad.valor = "";
            }
            else {
            
                oSeguridad.valor = variableSession;
                List<PaginaCLS> listaPagina = new List<PaginaCLS>();
                int idUsuario = int.Parse(HttpContext.Session.GetString("usuario"));
                int idTipoUsuario = int.Parse(HttpContext.Session.GetString("tipoUsuario"));
                using (BDRestauranteContext bd = new BDRestauranteContext())
                {
                    listaPagina = (from usuario in bd.Usuario
                                   join tipoUsuario in bd.TipoUsuario
                                   on usuario.Iidtipousuario equals
                                   tipoUsuario.Iidtipousuario
                                   join paginaTipo in bd.PaginaTipoUsuario
                                   on usuario.Iidtipousuario equals paginaTipo.Iidtipousuario
                                   join pagina in bd.Pagina
                                   on paginaTipo.Iidpagina equals pagina.Iidpagina
                                   where usuario.Iidusuario == idUsuario
                                   && usuario.Iidtipousuario == idTipoUsuario
                                   select new PaginaCLS
                                   {
                                       accion = pagina.Accion.Substring(1)
                                   }).ToList();
                    oSeguridad.lista = listaPagina;
                }
                }
            return oSeguridad;
        }
       [HttpGet]
       [Route("api/Usuario/CerrarSesion")]
        public SeguridadCLS CerrarSesion() {
            SeguridadCLS oSeguridadClS = new SeguridadCLS();
            try
            {
                HttpContext.Session.Remove("usuario");
                HttpContext.Session.Remove("tipoUsuario");
                oSeguridadClS.valor = "Ok";

            }
            catch (Exception ex)
            {
                oSeguridadClS.valor = "";
                throw;
            }
            return oSeguridadClS;
        }
    }
}