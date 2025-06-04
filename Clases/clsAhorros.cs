using NATILLERA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace NATILLERA.Clases
{
    public class clsAhorros
    {
        private NATILLERAEntities DBNatillera = new NATILLERAEntities();
        public tblAhorro Ahorro { get; set; }

        public string Insertar()
        {
            try
            {
                DBNatillera.tblAhorros.Add(Ahorro);
                DBNatillera.SaveChanges();
                return "Ahorro registrado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al registrar ahorro: " + ex.Message;
            }
        }
        public tblAhorro ConsultarPorID(int idAhorro)
        {
            try
            {
                tblAhorro ahorro = DBNatillera.tblAhorros.FirstOrDefault(a => a.intIdAhorroPk == idAhorro);
                return ahorro;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar ahorro: " + ex.Message);
            }
        }
        public List<tblAhorro> Listar()
        {
            try
            {
                return DBNatillera.tblAhorros.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar ahorros: " + ex.Message);
            }
        }
        public string ActualizarAhorro()
        {
            try
            {
                tblAhorro ahorroExistente = ConsultarPorID(Ahorro.intIdAhorroPk);
                if (ahorroExistente == null)
                {
                    return "Ahorro no encontrado";
                }
                DBNatillera.tblAhorros.AddOrUpdate(Ahorro);
                DBNatillera.SaveChanges();
                return "Ahorro actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar ahorro: " + ex.Message;
            }
        }
        public string EliminarAhorro(int idAhorro)
        {
            try
            {
                var ahorro = DBNatillera.tblAhorros.FirstOrDefault (c => c.intIdAhorroPk == idAhorro);
                if (ahorro != null)
                {
                    DBNatillera.tblAhorros.Remove(ahorro);
                    DBNatillera.SaveChanges();
                    return "Ahorro eliminado correctamente";
                }
               else                 
                {
                    return "Ahorro no encontrado";
                }
            }
            catch (Exception ex)
            {
                return "Error al eliminar ahorro: " + ex.Message;
            }
        }
    }
}