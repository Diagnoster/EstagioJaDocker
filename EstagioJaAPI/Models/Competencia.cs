using System.Collections;
using System.Text.Json.Serialization;
using EstagioJaAPI.Dtos;
using NHibernate.Mapping.Attributes;    

namespace EstagioJaAPI.Models;


[Class(Table = "tb_competencias")]
public class Competencia
{

    public Competencia(){}
    public Competencia(string descricao, IEnumerable<Vaga> vagas)
    {
        this.descricao = descricao;
        this.vagas = vagas;
    }

    [JsonConstructorAttribute]
    public Competencia(int? id, string descricao, IEnumerable<Vaga> vagas)
    {
        this.id = id;
        this.descricao = descricao;
        this.vagas = vagas;
    }

    public Competencia(int? id, string descricao)
    {
        this.descricao = descricao;
        this.id = id;
    }

    [Id(Name = "id", Column = "id_competencia", TypeType = typeof(int))]
    [Generator(1, Class = "native")]
    public virtual int? id { get; set; }

    [Property(Column = "desc_competencia")]
    public virtual string descricao { get; set; }

    [Bag(0, Table = "tb_competencias_vaga", Inverse = true)]
    [Key(1, Column = "id_competencia")]
    [ManyToMany(2, Column = "id_vaga", ClassType = typeof (Vaga))]
    public virtual IEnumerable<Vaga> vagas { get; set; }

    [Bag(0, Table = "tb_competencias_estudante", Inverse = true)]
    [Key(1, Column = "id_competencia")]
    [ManyToMany(2, Column = "id_estudante", ClassType = typeof(Estudante))]
    public virtual IEnumerable<Estudante> estudantes { get; set; }

    public static Competencia FromCompetenciaDto(CompetenciaDto dto)
    {
        return new Competencia(
            dto.id,
            dto.descricao
        ); 
    }

    public static CompetenciaDto ToCompetenciaDto(Competencia competencia)
    {
        return new CompetenciaDto(
            competencia.id,
            competencia.descricao
        );
    }

    public static IEnumerable<Competencia> FromCompetenciaDtoList(IEnumerable<CompetenciaDto> dtoList)
    {
        IList<Competencia> competencias = new List<Competencia>();    
        foreach (var item in dtoList)
        {
            competencias.Add(FromCompetenciaDto(item));
        }
        return competencias;    
    }

    public static IEnumerable<CompetenciaDto> ToCompetenciaDtoList(IEnumerable<Competencia> competencias)
    {
        IList<CompetenciaDto> competenciasDto = new List<CompetenciaDto>();
        foreach (var item in competencias)
        {
            competenciasDto.Add(ToCompetenciaDto(item));
        }
        return competenciasDto;
    }

}