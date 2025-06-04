using System;
using System.Collections.Generic;

namespace NATILLERA.Entidades
{
    public class ClienteDto
    {
        public int IdCliente { get; set; }
        public string DocumentoIdentidad { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public List<UsuarioDto> Usuarios { get; set; }
        public List<AhorroDto> Ahorros { get; set; }
        public List<PrestamoDto> Prestamos { get; set; }
        public List<LiquidacionDto> Liquidaciones { get; set; }
        public List<TransaccionDto> Transacciones { get; set; }
    }

    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
    }

    public class AhorroDto
    {
        public decimal Monto { get; set; }
        public DateTime FechaAhorro { get; set; }
    }

    public class PrestamoDto
    {
        public decimal Monto { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal TasaInteres { get; set; }
    }

    public class LiquidacionDto
    {
        public decimal MontoTotal { get; set; }
        public DateTime FechaLiquidacion { get; set; }
    }

    public class TransaccionDto
    {
        public decimal Monto { get; set; }
        public DateTime FechaOperacion { get; set; }
        public string TipoTransaccion { get; set; }
    }

}