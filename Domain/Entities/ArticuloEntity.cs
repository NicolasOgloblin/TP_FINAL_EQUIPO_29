using System;

namespace Domain.Entities
{
    [Serializable]
    public class ArticuloEntity
    {   
        public int Id { get; set; }
        public string CodArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public MarcaEntity Marca { get; set; }
        public CategoriaEntity Categoria { get; set; }
        public ImagenEntity Imagen { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; } = 1;
    }
}
