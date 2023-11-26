using System.Text.Json.Serialization;

namespace EstagioJaAPI.Dtos
{
    public class NotificacaoDto
    {
        [JsonConstructorAttribute]
        public NotificacaoDto(int? id, string mensagem, int idUsuario)
        {
            this.id = id;
            this.mensagem = mensagem;
            this.idUsuario = idUsuario;
        }

        public int? id { get; set; }
        public string mensagem { get; set; }
        public int idUsuario { get; set; }

    }
}
