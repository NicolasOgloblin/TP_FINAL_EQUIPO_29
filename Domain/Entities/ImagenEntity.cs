using System;

namespace Domain.Entities
{
    [Serializable]
    public class ImagenEntity
    {
        public int Id { get; set; }
        public int ArticuloId { get; set; }
        public string UrlImagen { get; set; }

        public override string ToString()
        {
            return UrlImagen;
        }

    }

}
