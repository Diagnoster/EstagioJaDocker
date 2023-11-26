using System.Text.Json.Serialization;

namespace EstagioJaAPI.Dtos;

public class EstudanteCadastroDto {

    EstudanteCadastroDto() {}

    [JsonConstructorAttribute]
    public EstudanteCadastroDto(int id, string cpf, string nome, DateTime dataNascimento, string telefone, EnderecoCadastroDto endereco, string email, string? senha)
    {
        this.id = id;
        this.cpf = cpf;
        this.nome = nome;
        this.dataNascimento = dataNascimento;
        this.telefone = telefone;
        this.endereco = endereco;
        this.email = email;
        this.senha = senha;
    }

    public virtual int id { get; set; }
    public virtual string cpf { get; set; }
    public virtual string nome { get; set; }
    public virtual DateTime dataNascimento { get; set; }
    public virtual string telefone { get; set; }
    public virtual EnderecoCadastroDto endereco { get; set; }
    public virtual string email { get; set; }
    public virtual string? senha { get; set; }

    public override string ToString()  {
        return (
            "{\nid: " + id +
            "\ncpf: " + cpf +
            "\nnome: " + nome +
            "\ndataNascimento: " + dataNascimento +
            "\ntelefone: " + telefone +
            "\nendereco: " + endereco +
            "\nemail: " + email +
            "\nsenha: " + senha + "\n}"
        );
    }

}