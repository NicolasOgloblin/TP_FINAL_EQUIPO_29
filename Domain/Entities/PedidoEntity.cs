using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class PedidoEntity
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public DateTime FechaPedido { get; set; }
        public decimal MontoTotal { get; set; }
        public List<PedidoDetalleEntity> Detalles { get; set; }
        public bool? Envio { get; set; }
        public short? EstadoPedidoid { get; set; }
        public string EstadoPedido { get; set; }
        public MetodoPagoEntity MetodoPago { get; set; }
        public bool Pagado {  get; set; } 
    }

    public class PedidoDetalleEntity
    {
        public long ArticuloId { get; set; }
        public ArticuloEntity Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public List<ImagenEntity> Imagenes { get; set; }
    }


}


