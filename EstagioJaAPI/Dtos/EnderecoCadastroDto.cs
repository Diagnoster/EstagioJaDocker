using System.Text.Json.Serialization;

namespace EstagioJaAPI.Dtos;

public class EnderecoCadastroDto {

    EnderecoCadastroDto() {}

    [JsonConstructorAttribute]
    public EnderecoCadastroDto(int id, string cep, string localidade, string uf, string bairro, int numero, string logradouro, string complemento)
    {
        this.id = id;
        this.cep = cep;
        this.localidade = localidade;
        this.uf = uf;
        this.bairro = bairro;
        this.numero = numero;
        this.logradouro = logradouro;
        this.complemento = complemento;
    }

    public virtual int id { get; set; }
    public virtual string cep { get; set; }
    public virtual string localidade { get; set; }
    public virtual string uf { get; set; }
    public virtual string bairro { get; set; }
    public virtual int numero { get; set; }
    public virtual string logradouro { get; set; }
    public virtual string complemento { get; set; }

    public override string ToString()  {
        return (
            "{\n id: " + id +
            "\ncep: " + cep +
            "\nlocalidade: " + localidade +
            "\nuf: " + uf +
            "\nbairro: " + bairro +
            "\nnumero: " + numero +
            "\nlogradouro: " + logradouro +
            "\ncomplemento: " + complemento + "\n}"
        );
    }

}