using System;
namespace backend.Models
{
    public class Restaurante
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Dueño { get; set; }
        public string? Provincia { get; set; }
        public string? Cantón { get; set; }
        public string? Distrito { get; set; }
        public string? DirecciónExacta { get; set; }
    }
}

