using EstagioJaAPI.Models;
using System.Text.Json.Serialization;

namespace EstagioJaAPI.Dtos
{
    public class EmpresaCompletoDto
    {

        [JsonConstructorAttribute]
        public EmpresaCompletoDto(int? id, string descricao, string ramoDeAtuacao, string telefone, string linkFoto, EnderecoCadastroDto endereco, string cnpj
            , string email, string nomeFantasia, string razaoSocial)
        {
            this.id = id;
            this.descricao = descricao;
            this.ramoDeAtuacao = ramoDeAtuacao;
            this.telefone = telefone;
            this.linkFoto = linkFoto;
            this.endereco = endereco;
            this.cnpj = cnpj;
            this.email = email;
            this.nomeFantasia = nomeFantasia;
            this.razaoSocial = razaoSocial;
        }

        public virtual int? id { get; set; }

        public virtual string descricao { get; set; }

        public virtual string ramoDeAtuacao { get; set; }

        public virtual string telefone { get; set; }

        public virtual string linkFoto { get; set; }

        public virtual EnderecoCadastroDto endereco { get; set; }

        public virtual string cnpj { get; set; }

        public virtual string email { get; set; }

        public virtual string nomeFantasia { get; set; }

        public virtual string razaoSocial { get; set; }

    }
}
