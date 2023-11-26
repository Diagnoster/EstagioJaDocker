using System.Text.Json.Serialization;
using EstagioJaAPI.Dtos;
using NHibernate.Mapping;
using NHibernate.Mapping.Attributes;    

namespace EstagioJaAPI.Models;


[Class(Table = "tb_enderecos")]
public class Endereco
{

    public Endereco(){}

    [JsonConstructorAttribute]
    public Endereco(int id, string cep, string localidade, string uf, string bairro, string logradouro, int numero, string complemento)
    {
        this.id = id;  
        this.cep = cep;
        this.localidade = localidade;
        this.uf = uf;
        this.bairro = bairro;
        this.logradouro = logradouro;
        this.numero = numero;
        this.complemento = complemento;
    }

    public Endereco(string cep, string localidade, string uf, string bairro, string logradouro, int numero, string complemento)
    {  
        this.cep = cep;
        this.localidade = localidade;
        this.uf = uf;
        this.bairro = bairro;
        this.logradouro = logradouro;
        this.numero = numero;
        this.complemento = complemento;
    }

    [Id(Name = "id", Column = "id_endereco", TypeType = typeof(int))]
    [Generator(1, Class = "native")]
    public virtual int id { get; set; }

    [Property(Column = "cep_endereco")]
    public virtual string cep { get; set; }

    [Property(Column = "localidade_endereco")]
    public virtual string localidade { get; set; }

    [Property(Column = "estado_endereco")]
    public virtual string uf { get; set; }

    [Property(Column = "bairro_endereco")]
    public virtual string bairro { get; set; }

    [Property(Column = "logradouro_endereco")]
    public virtual string logradouro { get; set; }

    [Property(Column = "numero_endereco")]
    public virtual int numero { get; set; }

    [Property(Column = "complemento_endereco")]
    public virtual string complemento { get; set; }

    [OneToOne(Cascade = "all")]
    public virtual Empresa empresa { get; set; }

    [OneToOne(Cascade = "all")]
    public virtual Estudante estudante { get; set; }

    public static Endereco FromEnderecoCadastroDto(EnderecoCadastroDto dto) {
        return new Endereco (
            dto.cep,
            dto.localidade,
            dto.uf,
            dto.bairro,
            dto.logradouro,
            dto.numero,
            dto.complemento
        );
    }

    public static EnderecoCadastroDto ToEnderecoCadastroDto(Endereco endereco) {
        return new EnderecoCadastroDto (
            endereco.id,
            endereco.cep,
            endereco.localidade,
            endereco.uf,
            endereco.bairro,
            endereco.numero,
            endereco.logradouro,
            endereco.complemento
        );
    }

    public static Endereco FromEnderecoCompletoDto(EnderecoCadastroDto dto)
    {
        return new Endereco(
            dto.id,
            dto.cep,
            dto.localidade,
            dto.uf,
            dto.bairro,
            dto.logradouro,
            dto.numero,
            dto.complemento
        );
    }

}