using NATILLERA.Clases;
using NATILLERA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NATILLERA.Controllers
{
    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("insertar")]
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
        [Route("ConsultarTodos")]
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
        [Route("Eliminar")]
        public string Eliminar(int idUsuario)
        {
            clsUsuarios objUsuarios = new clsUsuarios();
            return objUsuarios.EliminarUsuario(idUsuario);
        }
    }
}