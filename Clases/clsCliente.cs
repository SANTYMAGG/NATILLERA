using Microsoft.Ajax.Utilities;
using NATILLERA.Entidades;
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
        public List<ClienteDto> Listar()
        {
            try
            {
                var clientes = DBNatillera.tblClientes
                 .Include(c => c.tblUsuarios)
                 .Include(c => c.tblAhorros)
                 .Include(c => c.tblPrestamos)
                 .Include(c => c.tblLiquidaciones)
                 .Include(c => c.tblTransacciones)
                 .ToList();

                var dtoList = clientes.Select(c => new ClienteDto
                {
                    IdCliente = c.intIdClientePk,
                    DocumentoIdentidad = c.varDocumentoIdentidadUq,
                    FechaRegistro = c.dtFechaRegistro,

                    Usuarios = c.tblUsuarios.Select(u => new UsuarioDto
                    {
                        IdUsuario = u.intIdUsuarioPk,
                        NombreUsuario = u.varNombreUsuario,
                        Rol = u.enmRol
                    }).ToList(),

                    Ahorros = c.tblAhorros.Select(a => new AhorroDto
                    {
                        Monto = a.decMonto,
                        FechaAhorro = a.dtFechaAhorro
                    }).ToList(),

                    Prestamos = c.tblPrestamos.Select(p => new PrestamoDto
                    {
                        Monto = p.decMonto,
                        FechaAprobacion = p.dtFechaAprobacion,
                        FechaVencimiento = p.dtFechaVencimiento,
                        TasaInteres = p.decTasaInteres
                    }).ToList(),

                    Liquidaciones = c.tblLiquidaciones.Select(l => new LiquidacionDto
                    {
                        MontoTotal = l.decMontoTotal,
                        FechaLiquidacion = l.dtFechaLiquidacion
                    }).ToList(),

                    Transacciones = c.tblTransacciones.Select(t => new TransaccionDto
                    {
                        Monto = t.decMonto,
                        FechaOperacion = t.dtFechaOperacion.Value,
                        TipoTransaccion = t.tblTiposTransaccion.varNombre
                    }).ToList()

                }).ToList();

                return dtoList;
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
                var cliente = DBNatillera.tblClientes
                    .Include("tblAhorros")
                    .Include("tblLiquidaciones")
                    .Include("tblPrestamos")
                    .Include("tblTransacciones")
                    .Include("tblUsuarios")
                    .FirstOrDefault(c => c.intIdClientePk == idcliente);

                if (cliente == null)
                    return "Cliente no encontrado";

                // 1. Eliminar transacciones
                DBNatillera.tblTransacciones.RemoveRange(cliente.tblTransacciones.ToList());

                // 2. Eliminar liquidaciones
                DBNatillera.tblLiquidaciones.RemoveRange(cliente.tblLiquidaciones.ToList());

                // 3. Eliminar ahorros
                DBNatillera.tblAhorros.RemoveRange(cliente.tblAhorros.ToList());

                // 4. Eliminar pagos y préstamos asociados al cliente
                foreach (var prestamo in cliente.tblPrestamos.ToList())
                {
                    var pagos = DBNatillera.tblPagosPrestamoes
                        .Where(p => p.intIdPrestamoFk == prestamo.intIdPrestamoPk)
                        .ToList();
                    DBNatillera.tblPagosPrestamoes.RemoveRange(pagos);
                    DBNatillera.tblPrestamos.Remove(prestamo);
                }

                // 5. Por cada usuario del cliente
                foreach (var usuario in cliente.tblUsuarios.ToList())
                {
                    // Eliminar préstamos donde este usuario es aprobador (y sus pagos)
                    var prestamosAprobados = DBNatillera.tblPrestamos
                        .Where(p => p.intIdUsuarioAprobadorFk == usuario.intIdUsuarioPk)
                        .ToList();

                    foreach (var prestamoAprobado in prestamosAprobados)
                    {
                        var pagosPrestamo = DBNatillera.tblPagosPrestamoes
                            .Where(p => p.intIdPrestamoFk == prestamoAprobado.intIdPrestamoPk)
                            .ToList();
                        DBNatillera.tblPagosPrestamoes.RemoveRange(pagosPrestamo);
                        DBNatillera.tblPrestamos.Remove(prestamoAprobado);
                    }

                    // Eliminar tokens del usuario
                    var tokens = DBNatillera.tblTokens
                        .Where(t => t.intIdUsuarioFk == usuario.intIdUsuarioPk)
                        .ToList();
                    DBNatillera.tblTokens.RemoveRange(tokens);

                    // Eliminar participaciones en eventos
                    var eventos = DBNatillera.tblParticipantesEventos
                        .Where(pe => pe.intIdUsuarioFk == usuario.intIdUsuarioPk)
                        .ToList();
                    DBNatillera.tblParticipantesEventos.RemoveRange(eventos);

                    // Eliminar auditorías
                    var auditorias = DBNatillera.tblAuditorias
                        .Where(a => a.intIdUsuarioFk == usuario.intIdUsuarioPk)
                        .ToList();
                    DBNatillera.tblAuditorias.RemoveRange(auditorias);

                    // Finalmente eliminar el usuario
                    DBNatillera.tblUsuarios.Remove(usuario);
                }

                // 6. Finalmente, eliminar el cliente
                DBNatillera.tblClientes.Remove(cliente);

                // 7. Guardar cambios
                DBNatillera.SaveChanges();

                return "Cliente eliminado correctamente";
            }
            catch (Exception ex)
            {
                string detalle = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                return "Error al eliminar cliente: " + detalle;
            }
        }


        public List<tblCliente> LlenarCombo()
        {
            return DBNatillera.tblClientes

                .ToList();
        }
    }

}