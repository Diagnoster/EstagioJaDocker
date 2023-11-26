using System.Text.Json.Serialization;
using EstagioJaAPI.Models;

namespace EstagioJaAPI.Dtos
{
    public class CompetenciaDto
    {

        [JsonConstructorAttribute]
        public CompetenciaDto(int? id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
        }

        public int? id { get; set; }
        public string descricao { get; set; }

    }
}
