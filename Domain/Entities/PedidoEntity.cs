using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class PedidoEntity
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public DateTime FechaPedido { get; set; }
        public decimal MontoTotal { get; set; }
        public List<PedidoDetalleEntity> Detalles { get; set; }
        public bool Envio { get; set; }

        public short EstadoPedidoid { get; set; }
    }

    public class PedidoDetalleEntity
    {
        public long ArticuloId { get; set; }
        public string NombreArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }


    public class EstadoPedidoEntity
    {

        public short EstadoPedidoid { get; set; }
        public string Nombre { get; set; }

    }

}


