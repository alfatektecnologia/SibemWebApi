using Microsoft.EntityFrameworkCore;

namespace SibemWebApi.Models
{
    [Index(nameof(id_inventario), IsUnique = true)]
    public class InventarioModel
    {
        public required string id_igreja { get; set; }
        public required string id_inventario { get; set; }
        public required string inventariantes { get; set; }
        public required string responsaveis { get; set; }
        public required DateTime inicio { get; set; }
        public required DateTime termino { get; set; }
        public required DateTime data { get; set; }
        public required string tempo { get; set; }
        public  string? pdf { get; set; } = null;
        public required string status { get; set; }
        public required Int32 bens {  get; set; }

    }
}
