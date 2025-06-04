using NATILLERA.Clases;
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
    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] tblUsuario usuario)
        {
            clsUsuarios objUsuarios = new clsUsuarios();
            objUsuarios.Usuario = usuario;
            return objUsuarios.Insertar();
        }

        [HttpGet]
        [Route("ConsultarPorID")]
        public tblUsuario ConsultarPorID(int idUsuario)
        {
            clsUsuarios objUsuarios = new clsUsuarios();
            return objUsuarios.ConsultarPorID(idUsuario);
        }

        [HttpGet]
        [Route("ListadoUsuarios")]
        public List<tblUsuario> ConsultarTodosLosUsuarios()
        {
            clsUsuarios objUsuarios = new clsUsuarios();
            return objUsuarios.Listar();
        }


        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] tblUsuario usuario)
        {
            clsUsuarios objUsuarios = new clsUsuarios();
            objUsuarios.Usuario = usuario;
            return objUsuarios.ActualizarUsuario();
        }

        [HttpDelete]
        [Route("Eliminar/{idUsuario}")]
        public string Eliminar(int idUsuario)
        {
            clsUsuarios objUsuarios = new clsUsuarios();
            return objUsuarios.EliminarUsuario(idUsuario);
        }


    }
}
