using NATILLERA.Clases;
using NATILLERA.Entidades;
using NATILLERA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NATILLERA.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    [AllowAnonymous]
    public class AutorizacionController : ApiController
    {
        private clsAutorizacion clsAutorizacion = new clsAutorizacion();

        [HttpPost]
        [Route("acceso")]
        public IHttpActionResult Login([FromBody] AccesoUsuario loginModel)
        {
            if (loginModel == null)
                return BadRequest("Invalid data.");

            if (clsAutorizacion.ValidacionUsuario(loginModel))
            {
                var token = clsAutorizacion.GenerateToken(loginModel.Usuario);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("recuperarContraseña")]
        public string RecuperarContraseña([FromBody] AccesoUsuario usuario)
        {
            clsUsuarios objUsuarios = new clsUsuarios();
            return objUsuarios.RecuperarContraseña(usuario);
        }
    }
}