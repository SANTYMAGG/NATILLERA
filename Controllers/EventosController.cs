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
    public class EventosController : ApiController
    {
        [HttpPost]
        [Route("insertar")]
        public string Insertar([FromBody] tblEvento evento)
        {
            clsEventos objEventos = new clsEventos();
            objEventos.Evento = evento;
            return objEventos.Insertar();
        }
        [HttpGet]
        [Route("ConsultarPorID")]
        public tblEvento ConsultarPorID(int idEvento)
        {
            clsEventos objEventos = new clsEventos();
            return objEventos.ConsultarPorID(idEvento);
        }
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<tblEvento> ConsultarTodosLosEventos()
        {
            clsEventos objEventos = new clsEventos();
            var x = objEventos.Listar();
            return x;

        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] tblEvento evento)
        {
            clsEventos objEventos = new clsEventos();
            objEventos.Evento = evento;
            return objEventos.ActualizarEvento();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idEvento)
        {
            clsEventos objEventos = new clsEventos();
            return objEventos.EliminarEvento(idEvento);

        }
    }
}