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
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        [HttpPost]
        [Route("insertar")]
        public string Insertar([FromBody] tblCliente cliente)
        {
            clsCliente objcliente = new clsCliente();
            objcliente.Cliente = cliente;
            return objcliente.Insertar();
        }
        [HttpGet]
        [Route("ConsultarPorDocumento")]
        public tblCliente ConsultarPorDocumento(string documento)
        {
            clsCliente objcliente = new clsCliente();
            return objcliente.ConsultarPorDcoumento(documento);
        }
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<tblCliente> ConsultarTodasLasPrenda()
        {
            clsCliente objPrendas = new clsCliente();
            return objPrendas.Listar();

        }
    }
}