using System;

namespace Domain.Entities
{
    [Serializable]
    public class MarcaEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
