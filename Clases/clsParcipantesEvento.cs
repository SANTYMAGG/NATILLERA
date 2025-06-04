using NATILLERA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NATILLERA.Clases
{
    public class clsParcipantesEvento
    {
        private NATILLERAEntities DBNatillera = new NATILLERAEntities();
        public tblParticipantesEvento Parcipante { get; set; }

        public tblParticipantesEvento ConsultarPorID(int idParcipante)
        {
            try
            {
                tblParticipantesEvento participante = DBNatillera.tblParticipantesEventos.FirstOrDefault(p => p.intIdParticipacionPk == idParcipante);
                return participante;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar participante: " + ex.Message);
            }
        }
        public List<tblParticipantesEvento> Listar()
        {
            try
            {
                return DBNatillera.tblParticipantesEventos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar participantes: " + ex.Message);
            }
        }
       
    }
}