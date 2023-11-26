using EstagioJaAPI.Models;
using System.Text.Json.Serialization;

namespace EstagioJaAPI.Dtos
{
    public class VagaCandidaturaDto
    {

        [JsonConstructorAttribute]
        public VagaCandidaturaDto(int? id, string titulo, Turno turno, string descricao, IEnumerable<CompetenciaDto> requisitos, IEnumerable<CursoDto> cursos,
            string responsabilidades, string beneficios, string status, double valorDaBolsa, Modalidade modalidade, int idEmpresa, string? nomeEmpresa, IEnumerable<int> idEstudantes, DateTime prazo, int quantidadeCandidaturas)
        {
            this.id = id;
            this.titulo = titulo;
            this.turno = turno;
            this.descricao = descricao;
            this.requisitos = requisitos;
            this.cursos = cursos;
            this.responsabilidades = responsabilidades;
            this.beneficios = beneficios;
            this.status = status;
            this.valorDaBolsa = valorDaBolsa;
            this.modalidade = modalidade;
            this.idEmpresa = idEmpresa;
            this.nomeEmpresa = nomeEmpresa;
            this.idEstudantes = idEstudantes;
            this.prazo = prazo;
            this.quantidadeCandidaturas = quantidadeCandidaturas;
        }

        public int? id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public IEnumerable<CompetenciaDto> requisitos { get; set; }
        public IEnumerable<CursoDto> cursos { get; set; }
        public string responsabilidades { get; set; }
        public string beneficios { get; set; }
        public string status { get; set; }
        public double valorDaBolsa { get; set; }
        public Modalidade modalidade { get; set; }
        public Turno turno { get; set; }
        public int idEmpresa { get; set; }
        public DateTime prazo { get; set; }
        public IEnumerable<int> idEstudantes { get; set; } 
        public int quantidadeCandidaturas { get; set; }
        public string? nomeEmpresa { get; set; }

    }
}
