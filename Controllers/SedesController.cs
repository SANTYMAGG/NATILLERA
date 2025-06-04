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

        [HttpPut]
        [Route("actualizar")]
        public string Actualizar([FromBody] tblSede sede)
        {
            Clases.clsSedes objSede = new Clases.clsSedes();
            objSede.Sede = sede;
            return objSede.Actualizar();
        }


        [HttpDelete]
        [Route("eliminar/{idsede}")]
        public string Eliminar(int idsede)
        {
            clsSedes objSedes = new clsSedes();
            return objSedes.EliminarSede(idsede);
        }

        [HttpGet]
        [Route("consultartodos")]
        public List<tblSede> ConsultarTodasLasSedes()
        {
            Clases.clsSedes objSede = new Clases.clsSedes();
            return objSede.Listar();
        }
        [HttpGet]
        [Route("LlenarCombo")]
        public List<tblSede> LlenarCombo()
        {
            clsSedes sede = new clsSedes();
            return sede.LlenarCombo();
        }

    }
}