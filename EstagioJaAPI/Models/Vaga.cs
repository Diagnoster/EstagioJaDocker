using System.Text.Json.Serialization;
using EstagioJaAPI.Dtos;
using NHibernate.Mapping.Attributes;
using NHibernate.Util;

namespace EstagioJaAPI.Models;

[Class(Table = "tb_vagas")]
public class Vaga 
{

    public Vaga(){}

    public Vaga(string titulo, Turno turno, string descricao, IEnumerable<Competencia> requisitos, IEnumerable<Curso> cursos, string responsabilidades, string beneficios, string status, double valorDaBolsa, Modalidade modalidade)
    {
        this.titulo = titulo;
        this.descricao = descricao;
        this.requisitos = requisitos;
        this.cursos = cursos;
        this.responsabilidades = responsabilidades;
        this.beneficios = beneficios;
        this.status = status;
        this.valorDaBolsa = valorDaBolsa;
        this.modalidade = modalidade;
        this.turno = turno;
    }

    [JsonConstructorAttribute]
    public Vaga(int? id, string titulo, Turno turno, string descricao, IEnumerable<Competencia> requisitos, IEnumerable<Curso> cursos, 
        string responsabilidades, string beneficios, string status, double valorDaBolsa, Modalidade modalidade, IEnumerable<Estudante> estudantes,
        Empresa empresa)
    {
        this.id = id;
        this.titulo = titulo;
        this.descricao = descricao;
        this.requisitos = requisitos;
        this.cursos = cursos;
        this.responsabilidades = responsabilidades;
        this.beneficios = beneficios;
        this.status = status;
        this.valorDaBolsa = valorDaBolsa;
        this.modalidade = modalidade;
        this.turno = turno;
        this.estudantes = estudantes;
        this.empresa = empresa;
    }

    public Vaga(int? id, string titulo, Turno turno, string descricao, IEnumerable<Competencia> requisitos, IEnumerable<Curso> cursos,
        string responsabilidades, string beneficios, string status, double valorDaBolsa, Modalidade modalidade, DateTime prazo)
    {
        this.id = id;
        this.titulo = titulo;
        this.descricao = descricao;
        this.requisitos = requisitos;
        this.cursos = cursos;
        this.responsabilidades = responsabilidades;
        this.beneficios = beneficios;
        this.status = status;
        this.valorDaBolsa = valorDaBolsa;
        this.modalidade = modalidade;
        this.turno = turno;
        this.prazo = prazo;
    }

    [Id(Name = "id", Column = "id_vaga", TypeType = typeof(int))]
    [Generator(1, Class = "native")]
    public virtual int? id { get; set; }

    [Property(Column = "titulo_vaga")]
    public virtual string titulo { get; set; }

    [Property(Column = "desc_vaga")]
    public virtual string descricao { get; set; }

    [Bag(0, Table = "tb_competencias_vaga")]
    [Key(1, Column = "id_vaga")]
    [ManyToMany(2, Column = "id_competencia", ClassType = typeof (Competencia))]
    public virtual IEnumerable<Competencia> requisitos { get; set; }

    [Bag(0, Table = "tb_cursos_vaga")]
    [Key(1, Column = "id_vaga")]
    [ManyToMany(2, Column = "id_curso", ClassType = typeof (Curso))]
    public virtual IEnumerable<Curso> cursos { get; set; }

    [Property(Column = "responsabilidades_vaga", NotNull = true)]
    public virtual string responsabilidades { get; set; }

    [Property(Column = "turno_vaga", NotNull = true)]
    public virtual Turno turno { get; set; }

    [Property(Column = "beneficios_vaga", NotNull = true)]
    public virtual string beneficios { get; set; }

    [Property(Column = "status_vaga", NotNull = true)]
    public virtual string status { get; set; }

    [Property(Column = "bolsa_vaga", NotNull = true)]
    public virtual double valorDaBolsa { get; set; }

    [Property(Column = "prazo_vaga", NotNull = true)]
    public virtual DateTime prazo { get; set; }

    [Property(Column = "modalidade_vaga")]
    public virtual Modalidade modalidade {get; set;}

    [Bag(0, Table = "tb_vagas_estudante", Inverse = true)]
    [Key(1, Column = "id_vaga")]
    [ManyToMany(2, Column = "id_estudante", ClassType = typeof (Estudante))]
    public virtual IEnumerable<Estudante> estudantes { get; set; }

    [ManyToOne(Column = "id_empresa_vaga")]
    public virtual Empresa empresa { get; set; }

    public static Vaga FromVagaDto(VagaDto dto)
    {
        Empresa empresa = new Empresa();
        empresa.id = dto.idEmpresa;
        return new Vaga(
            dto.id,
            dto.titulo,
            dto.turno,
            dto.descricao,
            Competencia.FromCompetenciaDtoList(dto.requisitos),
            Curso.FromCursoDtoList(dto.cursos),
            dto.responsabilidades,
            dto.beneficios,
            dto.status,
            dto.valorDaBolsa,
            dto.modalidade,
            dto.prazo
        );
    }

    public static VagaDto ToVagaDto(Vaga vaga)
    {
        return new VagaDto(
              vaga.id,
              vaga.titulo,
              vaga.turno,   
              vaga.descricao,
              Competencia.ToCompetenciaDtoList(vaga.requisitos),
              Curso.ToCursoDtoList(vaga.cursos),
              vaga.responsabilidades,
              vaga.beneficios,
              vaga.status,
              vaga.valorDaBolsa,
              vaga.modalidade,
              vaga.empresa.id,
              vaga.prazo
        );
    } 

    public static Vaga FromVagaCandidaturaDto(VagaCandidaturaDto dto) {
        return new Vaga(
            dto.id,
            dto.titulo,
            dto.turno,
            dto.descricao,
            Competencia.FromCompetenciaDtoList(dto.requisitos),
            Curso.FromCursoDtoList(dto.cursos),
            dto.responsabilidades,
            dto.beneficios,
            dto.status,
            dto.valorDaBolsa,
            dto.modalidade,
            dto.prazo
        );
    } 

    public static VagaCandidaturaDto ToVagaCandidaturaDto(Vaga vaga)
    {
        return new VagaCandidaturaDto(
            vaga.id,
            vaga.titulo,
            vaga.turno,
            vaga.descricao,
            Competencia.ToCompetenciaDtoList(vaga.requisitos),
            Curso.ToCursoDtoList(vaga.cursos),
            vaga.responsabilidades,
            vaga.beneficios,
            vaga.status,
            vaga.valorDaBolsa,
            vaga.modalidade,
            vaga.empresa.id,
            vaga.empresa.nomeFantasia,
            Estudante.GetIdFromList(vaga.estudantes),
            vaga.prazo,
            vaga.estudantes.Count()
        );
    }

}
