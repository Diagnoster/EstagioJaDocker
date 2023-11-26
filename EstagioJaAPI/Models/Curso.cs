using System.Text.Json.Serialization;
using EstagioJaAPI.Dtos;
using NHibernate.Mapping.Attributes;

namespace EstagioJaAPI.Models;

[Class(Table = "tb_cursos")]
public class Curso
{

    public Curso(){}

    public Curso(string descricao, Modalidade modalidade, IEnumerable<Vaga> vagas)
    {
        this.descricao = descricao;
        this.modalidade = modalidade;
        this.vagas = vagas;
    }

    [JsonConstructorAttribute]
    public Curso(int? id, string descricao, Modalidade modalidade, IEnumerable<Vaga> vagas, IEnumerable<Estudante> estudantes)
    {
        this.id = id;
        this.descricao = descricao;
        this.modalidade = modalidade;
        this.vagas = vagas;
        this.estudantes = estudantes;
    }

    public Curso(int? id, string descricao, Modalidade modalidade, Turno turno)
    {
        this.id = id;
        this.descricao = descricao;
        this.modalidade = modalidade;
        this.turno = turno;
    }

    [Id(Name = "id", Column = "id_curso", TypeType = typeof(int))]
    [Generator(1, Class = "native")]
    public virtual int? id { get; set; }

    [Property(Column = "desc_curso")]
    public virtual string descricao { get; set; }

    [Property(Column = "modalidade_curso")]
    public virtual Modalidade modalidade {get; set;}

    [Property(Column = "turno_curso")]
    public virtual Turno turno {get; set;}

    [Bag(0, Table = "tb_cursos_vaga", Inverse = true)]
    [Key(1, Column = "id_curso")]
    [ManyToMany(2, Column = "id_vaga", ClassType = typeof (Vaga))]
    public virtual IEnumerable<Vaga> vagas { get; set; }

    [OneToMany(2, ClassType = typeof(Estudante))]
    public virtual IEnumerable<Estudante> estudantes { get; set; }

    public static Curso FromCursoDto(CursoDto dto)
    {
        return new Curso(
            dto.id,
            dto.descricao,
            dto.modalidade,
            dto.turno
        );
    }

    public static CursoDto ToCursoDto(Curso curso)
    {
        return new CursoDto(
            curso.id,
            curso.descricao,
            curso.modalidade,
            curso.turno
        );
    }

    public static IEnumerable<Curso> FromCursoDtoList(IEnumerable<CursoDto> dtoList)
    {
        IList<Curso> cursos = new List<Curso>();
        foreach (var item in dtoList)
        {
            cursos.Add(FromCursoDto(item));
        }
        return cursos;
    }

    public static IEnumerable<CursoDto> ToCursoDtoList(IEnumerable<Curso> cursos)
    {
        IList<CursoDto> cursosDto = new List<CursoDto>();
        foreach (var item in cursos)
        {
            cursosDto.Add(ToCursoDto(item));
        }
        return cursosDto;
    }

}