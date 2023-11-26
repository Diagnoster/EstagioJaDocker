using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EstagioJaAPI.Dtos;
using NHibernate.Mapping.Attributes;    

namespace EstagioJaAPI.Models;


[Class(Table = "tb_empresas")]
public class Empresa
{

    public Empresa(){}
    
    [JsonConstructorAttribute]
    public Empresa(int id, string email, string telefone, Endereco endereco, string cnpj, string razaoSocial, string nomeFantasia)
    {
        this.id = id;
        this.email = email;
        this.telefone = telefone;
        this.endereco = endereco;
        this.cnpj = cnpj;
        this.razaoSocial = razaoSocial;
        this.nomeFantasia = nomeFantasia;
    }

    public Empresa(int id, string descricao, string ramoDeAtuacao, string telefone, string linkFoto, Endereco endereco, string cnpj
    , string email, string nomeFantasia, string razaoSocial)
    {
        this.id = id;
        this.sobre = descricao;
        this.ramoDeAtuacao = ramoDeAtuacao;
        this.telefone = telefone;
        this.linkFoto = linkFoto;
        this.endereco = endereco;
        this.cnpj = cnpj;
        this.email = email;
        this.nomeFantasia = nomeFantasia;
        this.razaoSocial = razaoSocial;
    }

    public Empresa(string email, string telefone, Endereco endereco, string cnpj,  string nomeFantasia, string razaoSocial)
    {
        this.email = email;
        this.telefone = telefone;
        this.endereco = endereco;
        this.cnpj = cnpj;
        this.nomeFantasia = nomeFantasia;
        this.razaoSocial = razaoSocial;
    }

    [Id(Name = "id", Column = "id_empresa", TypeType = typeof(int))]
    [Generator(1, Class = "native")]
    public virtual int id { get; set; }

    [Property(Column = "email_empresa", Unique = true)]
    public virtual string email { get; set; }

    [Property(Column = "desc_empresa", NotNull = false)]
    public virtual string sobre { get; set; }

    [Property(Column = "telefone_empresa", NotNull = false)]
    public virtual string telefone { get; set; }

    [Property(Column = "link_foto_empresa", NotNull = false)]
    public virtual string linkFoto { get; set; }

    [ManyToOne(Column = "id_endereco_empresa")]
    public virtual Endereco endereco { get; set; }

    [Property(Column = "cnpj_empresa", Unique = true)]
    public virtual string cnpj { get; set; }

    [Property(Column = "ramo_empresa", NotNull = false)]
    public virtual string ramoDeAtuacao { get; set; }

    [Property(Column = "fantasia_empresa")]
    public virtual string nomeFantasia { get; set; }

    [Property(Column = "razao_empresa", NotNull = false)]
    public virtual string razaoSocial { get; set; }

    [Bag(0, Table = "tb_empresas", Inverse = true, Lazy = CollectionLazy.True)]
    [Key(1, Column = "id_empresa_vaga", NotNull = false)]
    [OneToMany(2, ClassType = typeof(Vaga))]
    public virtual IEnumerable<Vaga> vagas { get; set; }

    public static Empresa FromEmpresaCadastroDto(EmpresaDto dto) {
        return new Empresa(
            dto.email,
            dto.telefone ,
            Endereco.FromEnderecoCadastroDto(dto.endereco),
            dto.cnpj,
            dto.nomeFantasia,
            dto.razaoSocial
        );
    }

    public static EmpresaDto ToEmpresaDto(Empresa empresa) {
        return new EmpresaDto(
            empresa.id,
            empresa.cnpj,
            empresa.razaoSocial,
            empresa.nomeFantasia,
            empresa.telefone,
            Endereco.ToEnderecoCadastroDto(empresa.endereco),
            empresa.email,
            null
        );
    }

    public static EmpresaCompletoDto ToEmpresaCompletoDto(Empresa empresa)
    {
        return new EmpresaCompletoDto(
            empresa.id,
            empresa.sobre,
            empresa.ramoDeAtuacao,
            empresa.telefone,
            empresa.linkFoto,
            Endereco.ToEnderecoCadastroDto(empresa.endereco),
            empresa.cnpj,
            empresa.email,
            empresa.nomeFantasia,
            empresa.razaoSocial
        );
    }

    public static Empresa FromEmpresaCompletoDto(EmpresaCompletoDto dto)
    {
        return new Empresa(
            dto.id ?? 0,
            dto.descricao,
            dto.ramoDeAtuacao,
            dto.telefone,
            dto.linkFoto,
            Endereco.FromEnderecoCompletoDto(dto.endereco),
            dto.cnpj,
            dto.email,
            dto.nomeFantasia,
            dto.razaoSocial
        );
    }

}