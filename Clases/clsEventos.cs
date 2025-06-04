using NATILLERA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace NATILLERA.Clases
{
    public class clsEventos
    {
        private NATILLERAEntities DBNatillera = new NATILLERAEntities();
        public tblEvento Evento { get; set; }
        public string Insertar()
        {
            try
            {
                DBNatillera.tblEventos.Add(Evento);
                DBNatillera.SaveChanges();
                return "Evento registrado";
            }
            catch (Exception ex)
            {
                return "Error al registrar Evento: " + ex.Message;
            }
        }
        public tblEvento ConsultarPorID(int idEvento)
        {
            try
            {
                return DBNatillera.tblEventos.FirstOrDefault(e => e.intIdEventoPk == idEvento);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar evento: " + ex.Message);
            }
        }
        public List<tblEvento> Listar()
        {
            try
            {
                return DBNatillera.tblEventos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar eventos: " + ex.Message);
            }
        }
        public string ActualizarEvento()
        {
            try
            {
                tblEvento eventoExistente = ConsultarPorID(Evento.intIdEventoPk);
                if (eventoExistente == null)
                {
                    return "Evento no encontrado";
                }
                DBNatillera.tblEventos.AddOrUpdate(Evento);
                DBNatillera.SaveChanges();
                return "Evento actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar evento: " + ex.Message;
            }
        }
        public string EliminarEvento(int idEvento)
        {
            try
            {
                var evento = DBNatillera.tblEventos.FirstOrDefault(e => e.intIdEventoPk == idEvento);
                if (evento == null)
                {
                    return "Evento no encontrado";
                }
                DBNatillera.tblEventos.Remove(evento);
                DBNatillera.SaveChanges();
                return "Evento eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar evento: " + ex.Message;
            }
        }
    }
}