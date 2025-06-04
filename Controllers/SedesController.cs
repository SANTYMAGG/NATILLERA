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