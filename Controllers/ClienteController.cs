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
        [Route("ConsultarPorID")]
        public tblCliente ConsultarPorID(int idcliente)
        {
            clsCliente objcliente = new clsCliente();
            return objcliente.ConsultarPorID(idcliente);
        }
        [HttpGet]
        [Route("ConsultarTodos")]

        public List<tblCliente> ConsultarTodos()

        {
            clsCliente objCliente = new clsCliente();  // ✅
            var x = objCliente.Listar();
            return x;

        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] tblCliente cliente)
        {
            clsCliente objcliente = new clsCliente();
            objcliente.Cliente = cliente;
            return objcliente.ActualizarCliente();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idcliente)
        {
            clsCliente objcliente = new clsCliente();
            return objcliente.EliminarCliente(idcliente);
        }
        [HttpGet]
        [Route("LlenarCombo")]
        public List<tblCliente> LlenarCombo()
        {
            clsCliente cliente = new clsCliente();
            return cliente.LlenarCombo();
        }


    }
}