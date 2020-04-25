﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AngularApp.Clases;
using AngularApp.Models;

namespace AngularApp.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("api/Persona/listarPersonas")]
        public IEnumerable<PersonaCLS> ListarPersonas()
        {
            using (BDRestauranteContext bd = new BDRestauranteContext())
            {
                List<PersonaCLS> listaPersona = (from persona in bd.Persona
                                                 where persona.Bhabilitado == 1
                                                 select new PersonaCLS
                                                 {
                                                     idPersona = persona.Iidpersona,
                                                     nombreCompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                                     telefono = persona.Telefono,
                                                     correo = persona.Correo,
                                                 }).ToList();
                return listaPersona;
            }
        }
        [HttpGet]
        [Route("api/Persona/filtrarPersona/{nombreCompleto?}")]
        public IEnumerable<PersonaCLS> filtrarPersona(string nombreCompleto="") {
            List<PersonaCLS> listaPersona;
            using (BDRestauranteContext bd = new BDRestauranteContext()) {
                if (nombreCompleto == "")
                {
                  listaPersona = (from persona in bd.Persona
                                                     where persona.Bhabilitado == 1
                                                     select new PersonaCLS
                                                     {
                                                         idPersona = persona.Iidpersona,
                                                         nombreCompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                                         telefono = persona.Telefono,
                                                         correo = persona.Correo,
                                                     }).ToList();
                    return listaPersona;
                }
                else {
                    listaPersona = (from persona in bd.Persona
                                    where persona.Bhabilitado == 1
                                    && (persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno).ToLower().Contains(nombreCompleto.ToLower())
                                    select new PersonaCLS
                                    {
                                        idPersona = persona.Iidpersona,
                                        nombreCompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno,
                                        telefono = persona.Telefono,
                                        correo = persona.Correo,
                                    }).ToList();
                    return listaPersona;
                }
            }
        }
        [HttpPost]
        [Route("api/Persona/guardarPersona")]
        public int guardarPersona([FromBody] PersonaCLS oPersonaCLS) {
            int rta = 0;
            try
            {
                using (BDRestauranteContext bd = new BDRestauranteContext())
                {
                    if (oPersonaCLS.idPersona == 0)
                    {
                        Persona oPersona = new Persona();
                        oPersona.Iidpersona = oPersonaCLS.idPersona;
                        oPersona.Nombre = oPersonaCLS.nombre;
                        oPersona.Appaterno = oPersonaCLS.aPaterno;
                        oPersona.Apmaterno = oPersonaCLS.aMaterno;
                        oPersona.Correo = oPersonaCLS.correo;
                        oPersona.Telefono = oPersonaCLS.telefono;
                        oPersona.Fechanacimiento = oPersonaCLS.fechaNacimiento;
                        oPersona.Bhabilitado = 1;
                        oPersona.Btieneusuario = 0;
                        bd.Persona.Add(oPersona);
                        bd.SaveChanges();
                        rta = 1;
                    }
                    else {
                        Persona oPersona = bd.Persona.Where(p => p.Iidpersona == oPersonaCLS.idPersona).First();
                        oPersona.Nombre = oPersonaCLS.nombre;
                        oPersona.Appaterno = oPersonaCLS.aPaterno;
                        oPersona.Apmaterno = oPersonaCLS.aMaterno;
                        oPersona.Correo = oPersonaCLS.correo;
                        oPersona.Telefono = oPersonaCLS.telefono;
                        oPersona.Fechanacimiento = oPersonaCLS.fechaNacimiento;
                        bd.SaveChanges();
                        rta = 1;
                    }

                }
            }
            catch (Exception ex)
            {
                rta = 0;
            }
            return rta;
        }
        [HttpGet]
        [Route("api/Persona/recuperarPersona/{idPersona}")]
        public PersonaCLS recuperarPersona(int idPersona) {
            using (BDRestauranteContext bd = new BDRestauranteContext()) {
                PersonaCLS oPersonaCLS = (from persona in bd.Persona
                                          where persona.Bhabilitado == 1
                                          && persona.Iidpersona == idPersona
                                          select new PersonaCLS
                                          {
                                              idPersona = persona.Iidpersona,
                                              nombre = persona.Nombre,
                                              aPaterno = persona.Appaterno,
                                              aMaterno = persona.Apmaterno,
                                              telefono = persona.Telefono,
                                              correo = persona.Correo,
                                              fechaCadena = persona.Fechanacimiento == null ? " " : ((DateTime)persona.Fechanacimiento).ToString("yyyy-MM-dd")

                                          }).First();
                return oPersonaCLS;
            }
        }
        [HttpGet]
        [Route("api/Persona/eliminarPersona/{idPersona}")]
        public int eliminarPersona(int idPersona)
        {
            int rpta = 0;
            try
            {
                using (BDRestauranteContext bd = new BDRestauranteContext())
                {
                    Persona oPersona = bd.Persona.Where(p => p.Iidpersona == idPersona).First();
                    oPersona.Bhabilitado = 0;
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
        [Route("api/Persona/listarPersonaCombo")]
        public IEnumerable<PersonaCLS> listarPersonaCombo()
        {
            using (BDRestauranteContext bd = new BDRestauranteContext()) {
                IEnumerable<PersonaCLS> listaPersona = (from persona in bd.Persona
                                                        where persona.Bhabilitado == 1
                                                        && persona.Btieneusuario == 0
                                                        select new PersonaCLS
                                                        {
                                                            idPersona = persona.Iidpersona,
                                                            nombreCompleto = persona.Nombre + " " + persona.Appaterno + " " + persona.Apmaterno
                                                        }).ToList();
                return listaPersona;
            }        
        }
    }

}