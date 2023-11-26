using EstagioJaAPI.Models;
using System.Text.Json.Serialization;

namespace EstagioJaAPI.Dtos
{
    public class CursoDto
    {

        [JsonConstructorAttribute]
        public CursoDto(int? id, string descricao, Modalidade modalidade, Turno turno)
        {
            this.id = id;
            this.descricao = descricao;
            this.modalidade = modalidade;
            this.turno = turno;
        }

        public int? id { get; set; }
        public string descricao { get; set;}
        public Modalidade modalidade { get; set; } 
        public Turno turno { get; set; }

    }
}
