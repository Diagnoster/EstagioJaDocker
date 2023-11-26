using EstagioJaAPI.Dtos;
using NHibernate.Mapping.Attributes;

namespace EstagioJaAPI.Models
{

    [Class(Table = "tb_notificacoes")]
    public class Notificacao
    {

        public Notificacao(int id, string mensagem, Auth usuario)
        {
            this.id = id;
            this.mensagem = mensagem;
            this.usuario = usuario;
        }

        public Notificacao(int id, string mensagem)
        {
            this.id = id;
            this.mensagem = mensagem;
        }

        public Notificacao()
        {
        }

        [Id(Name = "id", Column = "id_notificacao", TypeType = typeof(int))]
        [Generator(1, Class = "native")]
        public virtual int id { get; set; }

        [Property(Column = "mensagem_notificacao")]
        public virtual string mensagem { get; set;}

        [ManyToOne(Column = "id_usuario_notificacao")]
        public virtual Auth usuario { get; set; }

        public static Notificacao FromNotificacaoDto(NotificacaoDto dto)
        {
            return new Notificacao(
                dto.id ?? 0,
                dto.mensagem
            );
        }

        public static NotificacaoDto ToNotificacaoDto(Notificacao notificacao)
        {
            return new NotificacaoDto(
                notificacao.id,
                notificacao.mensagem,
                notificacao.usuario.id
            );
        }

    }
}
