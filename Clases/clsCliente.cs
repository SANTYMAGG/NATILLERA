using NATILLERA.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace NATILLERA.Clases
{
    public class clsCliente
    {
        private NATILLERAEntities DBNatillera = new NATILLERAEntities();
        public tblCliente Cliente { get; set; }
        public string Insertar()
        {
            try
            {
                DBNatillera.tblClientes
                    .Add(Cliente);
                DBNatillera.SaveChanges();
                return "Cliente registrado";
            }
            catch (Exception ex)
            {
                return "Error al registrar Cliente" + ex.Message;
            }
        }
        public tblCliente ConsultarPorID(int idcliente)
        {
            try
            {
                tblCliente cliente = DBNatillera.tblClientes.FirstOrDefault(c => c.intIdClientePk == idcliente);
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar cliente: " + ex.Message);
            }
        }
        public List<tblCliente> Listar()
        {
            try
            {
                return DBNatillera.tblClientes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar clientes: " + ex.Message);
            }
        }
        public string ActualizarCliente()
        {
            try
            {
                tblCliente clien = ConsultarPorID(Cliente.intIdClientePk);
                if (clien == null)
                {       
                    return "Cliente no encontrado";
                }
                DBNatillera.tblClientes.AddOrUpdate(Cliente);
                DBNatillera.SaveChanges();
                return "Cliente actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar cliente: " + ex.Message;
            }

        }
        public string EliminarCliente(int idcliente)
        {
            try
            {
                var cliente = DBNatillera.tblClientes.FirstOrDefault(c => c.intIdClientePk == idcliente);
                if (cliente != null)
                {
                    DBNatillera.tblClientes.Remove(cliente);
                    DBNatillera.SaveChanges();
                    return "Cliente eliminado correctamente";
                }
                else
                {
                    return "Cliente no encontrado";
                }
            }
            catch (Exception ex)
            {
                return "Error al eliminar cliente: " + ex.Message;
            }
        }
        public List<tblCliente> LlenarCombo()
        {
            return DBNatillera.tblClientes

                .ToList();
        }
    }

    }
}