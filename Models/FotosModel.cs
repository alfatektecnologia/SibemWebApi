using Microsoft.EntityFrameworkCore;

namespace SibemWebApi.Models
{
    [PrimaryKey(nameof(id))]
    public class FotosModel
    {
        public int? id { get; set; }
        public string id_igreja { get; set; }
        public string foto { get; set; }
    }
}
