using Microsoft.EntityFrameworkCore;

namespace SibemWebApi.Models
{
    [Keyless]
    public class BemModel
    {
        public required string id_igreja { get; set; } 
        public required string id_bem { get; set; }
        public required string descricao { get; set; }
        public required string dependencia { get; set; }
        public required string status { get; set; }

        public static implicit operator BemModel(List<BemModel?> v)
        {
            throw new NotImplementedException();
        }
        // public required string observacao { get; set; }

    }
}
