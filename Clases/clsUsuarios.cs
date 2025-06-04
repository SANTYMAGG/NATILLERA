using NATILLERA.Entidades;
using NATILLERA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace NATILLERA.Clases
{
    public class clsUsuarios
    {
        private NATILLERAEntities DBNatillera = new NATILLERAEntities();
        public tblUsuario Usuario { get; set; }
        public string Insertar()
        {
            try
            {
                DBNatillera.tblUsuarios
                    .Add(Usuario);
                DBNatillera.SaveChanges();
                return "Usuario registrado";
            }
            catch (Exception ex)
            {
                return "Error al registrar Usuario" + ex.Message;
            }
        }
        public tblUsuario ConsultarPorID(int idUsuario)
        {
            try
            {
                tblUsuario usuario = DBNatillera.tblUsuarios.FirstOrDefault(c => c.intIdClienteFk == idUsuario);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar Usuario: " + ex.Message);
            }
        }

        public tblUsuario ConsultarNombreUsuario(string nombreUsuario)
        {
            try
            {
                tblUsuario usuario = DBNatillera.tblUsuarios.FirstOrDefault(c => c.varNombreUsuario == nombreUsuario);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar Usuario: " + ex.Message);
            }
        }
        public List<tblUsuario> Listar()
        {
            try
            {
                return DBNatillera.tblUsuarios.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar Usuario: " + ex.Message);
            }
        }
        public string ActualizarUsuario()
        {
            try
            {
    
                tblUsuario usuario = ConsultarPorID(Usuario.intIdUsuarioPk);

                if (usuario == null)
                {
                    return "Usuario no encontrado";
                }
                DBNatillera.tblUsuarios.AddOrUpdate(Usuario);
                DBNatillera.SaveChanges();
                return "Usuario actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar Usuario: " + ex.Message;
            }

        }
        public string EliminarUsuario(int idUsuario)
        {
            try
            {
                var usuario = DBNatillera.tblUsuarios.FirstOrDefault(c => c.intIdUsuarioPk == idUsuario);
                if (usuario != null)
                {
                    DBNatillera.tblUsuarios.Remove(usuario);
                    DBNatillera.SaveChanges();
                    return "Usuario eliminado correctamente";
                }
                else
                {
                    return "Usuario no encontrado";
                }
            }
            catch (Exception ex)
            {
                return "Error al eliminar Usuario: " + ex.Message;
            }
        }

        public string RecuperarContraseña(AccesoUsuario acceso)
        {
            try
            {
                var usuario = DBNatillera.tblUsuarios.FirstOrDefault(c => c.varNombreUsuario == acceso.Usuario);
                if (usuario != null)
                {
                    usuario.varPasswordHash = acceso.Contraseña;
                    DBNatillera.SaveChanges();
                    return "Contraseña actualizada";
                }
                else
                {
                    return "Usuario no encontrado";
                }
            }
            catch (Exception ex)
            {
                return "Error al cambiar contraseña Usuario: " + ex.Message;
            }
        }
    }
}