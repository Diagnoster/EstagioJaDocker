using NHibernate.Mapping.Attributes;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace EstagioJaAPI.Models
{

    [Class(Table = "tb_frases_empresa")]
    public class FraseEmpresa
    {
        public FraseEmpresa() { }

        [JsonConstructorAttribute]
        public FraseEmpresa(int id, string texto)
        {
            this.id = id;
            this.texto = texto;
        }

        public FraseEmpresa(string texto)
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
