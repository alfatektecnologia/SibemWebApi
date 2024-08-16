using Microsoft.EntityFrameworkCore;

namespace SibemWebApi.Models
{
    [PrimaryKey(nameof(id_bem))]
    public class BemModel
    {
        public required string id_igreja { get; set; } 
        public required string id_bem { get; set; }
        public required string descricao { get; set; }
        public required string dependencia { get; set; }
        public required string status { get; set; }
       
    }
}
