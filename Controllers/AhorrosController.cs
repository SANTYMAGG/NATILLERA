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
    [RoutePrefix("api/eventos")]
    public class AhorrosController : ApiController
    {
        [HttpPost]
        [Route("insertar")]
        public string Insertar([FromBody] tblAhorro ahorro)
        {
            clsAhorros objAhorros = new clsAhorros();
            objAhorros.Ahorro = ahorro;
            return objAhorros.Insertar();
        }
        [HttpGet]
        [Route("ConsultarPorID")]
        public tblAhorro ConsultarPorID(int idAhorro)
        {
            clsAhorros objAhorros = new clsAhorros();
            return objAhorros.ConsultarPorID(idAhorro);
        }
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<tblAhorro> ConsultarTodosLosAhorros()
        {
            clsAhorros objAhorros = new clsAhorros();
            var x = objAhorros.Listar();
            return x;
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] tblAhorro ahorro)
        {
            clsAhorros objAhorros = new clsAhorros();
            objAhorros.Ahorro = ahorro;
            return objAhorros.ActualizarAhorro();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idAhorro)
        {
            clsAhorros objAhorros = new clsAhorros();
            return objAhorros.EliminarAhorro(idAhorro);

        }
    }
}