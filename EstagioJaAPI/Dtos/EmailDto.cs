using System.Text.Json.Serialization;

namespace EstagioJaAPI.Dtos
{
    public class EmailDto
    {
        [JsonConstructorAttribute]
        public EmailDto(string email, string nome)
        {
            this.email = email;
            this.nome = nome;
        }

        public string email { get; set; }
        public string nome { get; set; }
    }
}
