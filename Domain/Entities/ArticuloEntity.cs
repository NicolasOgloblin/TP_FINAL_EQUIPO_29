using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    [Serializable]
    public class ArticuloEntity
    {   
        public long Id { get; set; }
        public string CodArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public MarcaEntity Marca { get; set; }
        public CategoriaEntity Categoria { get; set; }
        public List<ImagenEntity> Imagenes { get; set; }
        public DateTime FechaAgregado { get; set; }
        public decimal Precio { get; set; } = 0;
        public int Stock { get; set; } = 0;
    }
}
