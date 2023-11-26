using System.Text.Json.Serialization;

namespace EstagioJaAPI.Dtos
{
    public class EstudanteCandidatoDto
    {

        [JsonConstructorAttribute]
        public EstudanteCandidatoDto(int id, string nome, DateTime dataDeNascimento, EnderecoCadastroDto endereco, string linkCurriculo, string linkFoto, string? telefone)
        {
            this.id = id;
            this.nome = nome;
            this.dataDeNascimento = dataDeNascimento;
            this.endereco = endereco;
            this.linkCurriculo = linkCurriculo;
            this.linkFoto = linkFoto;
            this.telefone = telefone;
        }

        public virtual int id { get; set; }
        public virtual string nome { get; set; }
        public virtual DateTime dataDeNascimento { get; set; }
        public virtual EnderecoCadastroDto endereco { get; set; }
        public virtual string linkCurriculo { get; set; }
        public virtual string linkFoto { get; set; }
        public virtual string telefone { get; set; }
    }
}
