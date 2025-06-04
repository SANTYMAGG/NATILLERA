using NATILLERA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NATILLERA.Clases
{
    public class clsSedes
    {
        private NATILLERAEntities DBNatillera = new NATILLERAEntities();
        public tblSede Sede { get; set; }

        public string Insertar()
        {
            try
            {
                DBNatillera.tblSedes.Add(Sede);
                DBNatillera.SaveChanges();
                return "Sede registrada";
            }
            catch (Exception ex)
            {
                return "Error al registrar la sede: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                var sedeExistente = DBNatillera.tblSedes.FirstOrDefault(s => s.intIdSedePk == Sede.intIdSedePk);
                if (sedeExistente != null)
                {
                    sedeExistente.varNombreSede = Sede.varNombreSede;
                    sedeExistente.varDireccion = Sede.varDireccion;
                    sedeExistente.intCapacidadMaxima = Sede.intCapacidadMaxima;

                    DBNatillera.SaveChanges();
                    return "Sede actualizada";
                }
                else
                {
                    return "Sede no encontrada";
                }
            }
            catch (Exception ex)
            {
                return "Error al actualizar la sede: " + ex.Message;
            }
        }

        public string EliminarSede(int idsede)
        {
            try
            {
                var sedeExistente = DBNatillera.tblSedes.FirstOrDefault(s => s.intIdSedePk == idsede);
                if (sedeExistente != null)
                {
                    DBNatillera.tblSedes.Remove(sedeExistente);
                    DBNatillera.SaveChanges();
                    return "Sede eliminada";
                }
                else
                {
                    return "Sede no encontrada";
                }
            }
            catch (Exception ex)
            {
                return "Error al eliminar la sede: " + ex.Message;
            }
        }


        public tblSede ConsultarPorId(int id)
        {
            try
            {
                return DBNatillera.tblSedes.FirstOrDefault(s => s.intIdSedePk == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la sede: " + ex.Message);
            }
        }

        public List<tblSede> Listar()
        {
            try
            {
                return DBNatillera.tblSedes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar sedes: " + ex.Message);
            }
        }
        public List<tblSede> LlenarCombo()
        {
            return DBNatillera.tblSedes
             
                .ToList();
        }

    }
}
