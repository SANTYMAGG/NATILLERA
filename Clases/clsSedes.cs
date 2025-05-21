using NATILLERA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                return "Error al registrar Sede" + ex.Message;
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
    }
}