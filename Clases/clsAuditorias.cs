using NATILLERA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NATILLERA.Clases
{
    public class clsAuditorias
    {
        private NATILLERAEntities DBNatillera = new NATILLERAEntities();
        public tblAuditoria Auditoria { get; set; }
        
        public string Insertar()
        {
            try
            {
                DBNatillera.tblAuditorias.Add(Auditoria);
                DBNatillera.SaveChanges();
                return "Auditoría registrada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al registrar auditoría: " + ex.Message;
            }
        }
        public tblAuditoria ConsultarPorID(int idAuditoria)
        {
            try
            {
                tblAuditoria auditoria = DBNatillera.tblAuditorias.FirstOrDefault(a => a.intIdAuditoriaPk == idAuditoria);
                return auditoria;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar auditoría: " + ex.Message);
            }
        }
    }
}