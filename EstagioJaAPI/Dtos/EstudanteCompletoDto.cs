using System.Text.Json.Serialization;
using EstagioJaAPI.Models;
using NHibernate.Mapping.Attributes;

namespace EstagioJaAPI.Dtos
{

    public class EstudanteCompletoDto
    {
        [JsonConstructorAttribute]
        public EstudanteCompletoDto(int? id, string nome, string sobre, string telefone, string linkFoto, EnderecoCadastroDto endereco, string cpf, 
            double valorDaBolsa, string linkCurriculo, DateTime dataDeNascimento, CursoDto curso, IEnumerable<CompetenciaDto> competencias,
            Modalidade modalidade, Turno turno)
        {
            this.id = id;
            this.nome = nome;
            this.sobre = sobre;
            this.telefone = telefone;
            this.linkFoto = linkFoto;
            this.endereco = endereco;
            this.cpf = cpf;
            this.valorDaBolsa = valorDaBolsa;
            this.linkCurriculo = linkCurriculo;
            this.dataDeNascimento = dataDeNascimento;
            this.curso = curso;
            this.competencias = competencias;
            this.modalidade = modalidade;
            this.turno = turno;
        }

        public virtual int? id { get; set; }

        public virtual string nome { get; set; }

        public virtual string sobre { get; set; }

        public virtual string telefone { get; set; }

        public virtual string linkFoto { get; set; }

        public virtual EnderecoCadastroDto endereco { get; set; }

        public virtual string cpf { get; set; }

        public virtual double valorDaBolsa { get; set; }

        public virtual string linkCurriculo { get; set; }

        public virtual DateTime dataDeNascimento { get; set; }

        public virtual CursoDto curso { get; set; }

        public virtual IEnumerable<CompetenciaDto> competencias { get; set; }

        public virtual Modalidade modalidade { get; set; }

        public virtual Turno turno { get; set; }

    }

}
