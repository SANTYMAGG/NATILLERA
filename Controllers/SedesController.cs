using NATILLERA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NATILLERA.Controllers
{
    [RoutePrefix("api/sedes")]
    public class SedesController : ApiController
    {
        [HttpPost]
        [Route("insertar")]
        public string Insertar([FromBody] tblSede sede)
        {
            Clases.clsSedes objSede = new Clases.clsSedes();
            objSede.Sede = sede;
            return objSede.Insertar();
        }
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<tblSede> ConsultarTodasLasSedes()
        {
            Clases.clsSedes objSede = new Clases.clsSedes();
            return objSede.Listar();
        }
    }
}