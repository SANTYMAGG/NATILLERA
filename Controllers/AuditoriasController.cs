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
    [RoutePrefix("api/Auditorias")]
    public class AuditoriasController : ApiController
    {
        [HttpGet]
        [Route("ConsultarPorID")]
        public tblAuditoria ConsultarPorID(int idAuditoria)
        {
            clsAuditorias objAuditorias = new clsAuditorias();
            return objAuditorias.ConsultarPorID(idAuditoria);
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] tblAuditoria auditoria)
        {
            clsAuditorias objAuditorias = new clsAuditorias();
            objAuditorias.Auditoria = auditoria;
            return objAuditorias.Insertar();
        }
    }
}