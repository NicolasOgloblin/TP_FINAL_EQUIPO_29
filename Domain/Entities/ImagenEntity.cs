using System;

namespace Domain.Entities
{
    [Serializable]
    public class ImagenEntity
    {
        public long ArticuloId { get; set; }
        public string UrlImagen { get; set; }

        public override string ToString()
        {
            return UrlImagen;
        }

    }

}
