using System.Text.Json.Serialization;

namespace EstagioJaAPI.Dtos;

public class EmpresaDto {

    EmpresaDto() {}

    [JsonConstructorAttribute]
    public EmpresaDto(int id, string cnpj, string razaoSocial, string nomeFantasia, string telefone, EnderecoCadastroDto endereco, string email, string? senha)
    {
        this.id = id;
        this.cnpj = cnpj;
        this.razaoSocial = razaoSocial;
        this.nomeFantasia = nomeFantasia;
        this.telefone = telefone;
        this.endereco = endereco;
        this.email = email;
        this.senha = senha;
    }

    public virtual int id { get; set; }
    public virtual string cnpj { get; set; }
    public virtual string razaoSocial { get; set; }
    public virtual string nomeFantasia { get; set; }
    public virtual string telefone { get; set; }
    public virtual EnderecoCadastroDto endereco { get; set; }
    public virtual string email { get; set; }
    public virtual string? senha { get; set; }

    public override string ToString()  {
        return (
            "{\nid: " + id +
            "\ncnpj: " + cnpj +
            "\nrazao: " + razaoSocial +
            "\nnomeFantasia: " + nomeFantasia +
            "\ntelefone: " + telefone +
            "\nendereco: " + endereco +
            "\nemail: " + email +
            "\nsenha: " + senha + "\n}"
        );
    }

}