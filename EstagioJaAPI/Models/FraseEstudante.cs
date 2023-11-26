using NHibernate.Mapping.Attributes;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace EstagioJaAPI.Models
{

    [Class(Table = "tb_frases_estudante")]
    public class FraseEstudante
    {
        public FraseEstudante() { }

        [JsonConstructorAttribute]
        public FraseEstudante(int id, string texto)
        {
            this.id = id;
            this.texto = texto;
        }

        public FraseEstudante(string texto)
        {
            this.texto = texto;
        }

        [Id(Name = "id", Column = "id_frase", TypeType = typeof(int))]
        [Generator(1, Class = "native")]
        public virtual int id { get; set; }

        [Property(Column = "texto_frase", NotNull = false)]
        public virtual string texto { get; set; }
    }
}
