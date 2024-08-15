using Microsoft.EntityFrameworkCore;

namespace SibemWebApi.Models
{
    [Index(nameof(id_igreja), IsUnique = true)]
    public class IgrejaModel
    {
        public required string id_igreja { get; set; }
        public required string id_setor { get; set; }
        public required string endereco { get; set; }
        public required string igreja { get; set; }
        public string? last_Inventario { get; set; } = null;
        public required Int32 situacao { get; set; }
        public string? foto { get; set; } = null;
    }
}
