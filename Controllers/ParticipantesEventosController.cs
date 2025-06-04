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
    [RoutePrefix("api/ParticipantesEventos")]
    public class ParticipantesEventosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarPorID")]
        public tblParticipantesEvento ConsultarPorID(int idParticipante)
        {
           clsParcipantesEvento objParticipantes = new clsParcipantesEvento();
            return objParticipantes.ConsultarPorID(idParticipante);
        }
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<tblParticipantesEvento> ConsultarTodosLosParticipantes()
        {
            clsParcipantesEvento objParticipantes = new clsParcipantesEvento();
            var x = objParticipantes.Listar();
            return x;
        }
    }
}