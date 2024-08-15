using Microsoft.EntityFrameworkCore;

namespace SibemWebApi.Models
{
    [Index(nameof(id_igreja), IsUnique = true)]
    public class FotosModel
    {
        public int? id { get; set; } = null;
        public string id_igreja { get; set; }
        public string foto { get; set; }
    }
}
