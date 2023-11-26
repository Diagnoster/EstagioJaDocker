using System.Text.Json.Serialization;
using EstagioJaAPI.Models;

namespace EstagioJaAPI.Dtos;

public class AuthResponseDto {

    AuthResponseDto() {}

    [JsonConstructorAttribute]
    public AuthResponseDto(int id, string email, PerfilAcesso perfil)
    {
        this.id = id;
        this.email = email;
        this.perfil = perfil;
    }

    public virtual int id { get; set; }
    public virtual string email { get; set; }
    public virtual PerfilAcesso perfil { get; set; }


}