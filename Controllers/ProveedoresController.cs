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
    [RoutePrefix("api/Proveedores")]
    public class ProveedoresController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] tblProveedore proveedor)
        {
            clsProveedores objProveedores = new clsProveedores();
            objProveedores.Proveedores = proveedor;
            return objProveedores.Insertar();
        }

        [HttpGet]
        [Route("ConsultarPorID")]
        public tblProveedore ConsultarPorID(int idProveedor)
        {
            clsProveedores objProveedores = new clsProveedores();
            return objProveedores.ConsultarPorID(idProveedor);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<tblProveedore> ConsultarTodos()
        {
            clsProveedores objProveedores = new clsProveedores();
            return objProveedores.Listar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] tblProveedore proveedor)
        {
            clsProveedores objProveedores = new clsProveedores();
            objProveedores.Proveedores = proveedor;
            return objProveedores.ActualizarProveedor();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idProveedor)
        {
            clsProveedores objProveedores = new clsProveedores();
            return objProveedores.EliminarProveedor(idProveedor);
        }
    }

}