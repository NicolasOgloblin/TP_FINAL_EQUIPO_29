using System;
using System.ComponentModel;

namespace Domain.Entities
{
    [Serializable]
    public class MarcaEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
