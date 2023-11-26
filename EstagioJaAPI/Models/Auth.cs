using System.Security.Cryptography;
using System.Text.Json.Serialization;
using EstagioJaAPI.Dtos;
using NHibernate.Mapping.Attributes;    

namespace EstagioJaAPI.Models;


[Class(Table = "tb_autenticacao")]
public class Auth
{

    public Auth(){}

    public Auth(string email, string senha)
    {
        this.email = email;
        this.senha = senha;
    }

    public Auth(string email, string senha, PerfilAcesso perfil)
    {
        this.email = email;
        this.senha = senha;
        this.perfil = perfil;
    }

    public Auth(int id, string email, string senha, PerfilAcesso perfil)
    {
        this.id = id;
        this.email = email;
        this.senha = senha;
        this.perfil = perfil;
    }

    [Id(Name = "id", Column = "id_autenticacao", TypeType = typeof(int))]
    [Generator(1, Class = "native")]
    public virtual int id { get; set; }

    [Property(Column = "email_autenticacao", Unique = true)]
    public virtual string email { get; set; }

    [Property(Column = "senha_autenticacao")]
    public virtual string senha { get; set; }

    [Property(Column = "perfil_autenticacao")]
    public virtual PerfilAcesso perfil { get; set; }

    [Bag(0, Table = "tb_autenticacao", Inverse = true, Lazy = CollectionLazy.True)]
    [Key(1, Column = "id_usuario_notificacao", NotNull = false)]
    [OneToMany(2, ClassType = typeof(Notificacao))]
    public virtual IEnumerable<Notificacao> vagas { get; set; }

    public static Auth FromAuthRequestDto(AuthRequestDto dto) {
        return new Auth(
            dto.email,
            dto.senha
        );
    }

    public static AuthResponseDto ToAuthResponseDto(Auth auth) {
        return new AuthResponseDto(
            auth.id,
            auth.email,
            auth.perfil
        );
    }
}