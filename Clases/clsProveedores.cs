using NATILLERA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace NATILLERA.Clases
{
    public class clsProveedores
    {
        private NATILLERAEntities DBNatillera = new NATILLERAEntities();
        public tblProveedore Proveedores { get; set; }
        public string Insertar()
        {
            try
            {
                DBNatillera.tblProveedores
                    .Add(Proveedores);
                DBNatillera.SaveChanges();
                return "Proveedor registrado";
            }
            catch (Exception ex)
            {
                return "Error al registrar Proveedor: " + ex.Message;
            }
        }
        public tblProveedore ConsultarPorID(int idProveedor)
        {
            try
            {
                tblProveedore proveedor = DBNatillera.tblProveedores.FirstOrDefault(c => c.intIdProveedorPk == idProveedor);
                return proveedor;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar Proveedor: " + ex.Message);
            }
        }
        public List<tblProveedore> Listar()
        {
            try
            {
                return DBNatillera.tblProveedores.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar Proveedores: " + ex.Message);
            }
        }
        public string ActualizarProveedor()
        {
            try
            {
                tblProveedore proveedor = ConsultarPorID(Proveedores.intIdProveedorPk);
                if (proveedor == null)
                {
                    return "Proveedor no encontrado";
                }
                DBNatillera.tblProveedores.AddOrUpdate(Proveedores);
                DBNatillera.SaveChanges();
                return "Proveedor actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar Proveedor: " + ex.Message;
            }
        }
        public string EliminarProveedor(int idProveedor)
        {
            try
            {
                var proveedor = DBNatillera.tblProveedores
                    .Include("tblAlquileres")
                    .FirstOrDefault(c => c.intIdProveedorPk == idProveedor);

                if (proveedor == null)
                {
                    return "Proveedor no encontrado";
                }

                if (proveedor.tblAlquileres.Any())
                {
                    DBNatillera.tblAlquileres.RemoveRange(proveedor.tblAlquileres.ToList());
                }

                DBNatillera.tblProveedores.Remove(proveedor);
                DBNatillera.SaveChanges();

                return "Proveedor eliminado correctamente";
            }
            catch (Exception ex)
            {
                string detalle = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                return "Error al eliminar proveedor: " + detalle;
            }
        }

    }
}