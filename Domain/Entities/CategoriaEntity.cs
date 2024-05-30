using System;

namespace Domain.Entities
{
    [Serializable]
    public class CategoriaEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
