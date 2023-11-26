using System.Text.Json.Serialization;

namespace EstagioJaAPI.Dtos;

public class AuthRequestDto {

    AuthRequestDto() {}

    [JsonConstructorAttribute]
    public AuthRequestDto(string email, string senha)
    {
        this.email = email;
        this.senha = senha;
    }

    public virtual string email { get; set; }
    public virtual string senha { get; set; }

}