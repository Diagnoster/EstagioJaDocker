using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EstagioJaAPI.Dtos;
using Microsoft.Extensions.Logging.Console;
using NHibernate.Linq.Functions;
using NHibernate.Mapping;
using NHibernate.Mapping.Attributes;    

namespace EstagioJaAPI.Models;


[Class(Table = "tb_estudantes")]
public class Estudante
{

    public Estudante(){}

    public Estudante(int id)
    {
        this.id = id;
    }

    public Estudante(int id, string nome, string sobre, string telefone, string linkFoto, Endereco endereco, 
        string cpf, double pretencaoSalarial, string linkCurriculo, DateTime dataDeNascimento, Curso curso, IEnumerable<Competencia> competencias, Modalidade modalidade, Turno turno)
    {
        this.nome = nome;
        this.sobre = sobre;
        this.telefone = telefone;
        this.linkFoto = linkFoto;
        this.endereco = endereco;
        this.cpf = cpf;
        this.pretencaoSalarial = pretencaoSalarial;
        this.linkCurriculo = linkCurriculo;
        this.dataDeNascimento = dataDeNascimento;
        this.curso = curso;
        this.competencias = competencias;
        this.modalidade = modalidade;
        this.turno = turno;
    }

    [JsonConstructorAttribute]
    public Estudante(int id, string email, string nome, string telefone, Endereco endereco, string cpf, DateTime dataDeNascimento)
    {
        this.id = id;
        this.nome = nome;
        this.email = email;
        this.telefone = telefone;
        this.endereco = endereco;
        this.cpf = cpf;
        this.dataDeNascimento = dataDeNascimento;
    }

    public Estudante(string cpf, string nome, DateTime dataDeNascimento, string telefone, Endereco endereco, string email)
    {
        this.nome = nome;
        this.email = email;
        this.telefone = telefone;
        this.endereco = endereco;
        this.cpf = cpf;
        this.dataDeNascimento = dataDeNascimento;
    }

    [Id(Name = "id", Column = "id_estudante", TypeType = typeof(int))]
    [Generator(1, Class = "native")]
    public virtual int id { get; set; }

    [Property(Column = "nome_estudante")]
    public virtual string nome { get; set; }

    [Property(Column = "email_estudante", Unique = true)]
    public virtual string email { get; set; }

    [Property(Column = "desc_estudante", NotNull = false)]
    public virtual string sobre { get; set; }

    [Property(Column = "telefone_estudante")]
    public virtual string telefone { get; set; }

    [Property(Column = "link_foto_estudante", NotNull = false)]
    public virtual string linkFoto { get; set; }

    [ManyToOne(Column = "id_endereco_estudante")]
    public virtual Endereco endereco { get; set; }

    [Property(Column = "cpf_estudante", Unique = true)]
    public virtual string cpf { get; set; }

    [Property(Column = "pretencao_estudante", NotNull = false)]
    public virtual double pretencaoSalarial { get; set; }

    [Property(Column = "link_curriculo_estudante", NotNull = false)]
    public virtual string linkCurriculo { get; set; }

    [Property(Column = "nascimento_estudante")]
    public virtual DateTime dataDeNascimento { get; set; }

    [ManyToOne(Column = "id_curso_estudante", NotNull = false)]
    public virtual Curso curso { get; set; }

    [Bag(0, Table = "tb_competencias_estudante")]
    [Key(1, Column = "id_estudante")]
    [ManyToMany(2, Column = "id_competencia", ClassType = typeof(Competencia))]
    public virtual IEnumerable<Competencia> competencias { get; set; }

    [Bag(0, Table = "tb_vagas_estudante")]
    [Key(1, Column = "id_estudante", NotNull = false)]
    [ManyToMany(2, Column = "id_vaga", ClassType = typeof (Vaga))]
    public virtual IEnumerable<Vaga> vagas { get; set; }

    [Property(Column = "modalidade_estudante")]
    public virtual Modalidade modalidade { get; set; }

    [Property(Column = "turno_estudante")]
    public virtual Turno turno { get; set; }

    public static Estudante FromEstudanteCadastroDto(EstudanteCadastroDto dto) {
        return new Estudante(
            dto.cpf,
            dto.nome,
            dto.dataNascimento,
            dto.telefone,
            Endereco.FromEnderecoCadastroDto(dto.endereco),
            dto.email
        );
    }

    public static IEnumerable<int> GetIdFromList(IEnumerable<Estudante> lista)
    {
        IList<int> idEstudantes = new List<int>();
        foreach (Estudante estudante in lista)
            idEstudantes.Add(estudante.id);
        return idEstudantes;
    }

    public static EstudanteCandidatoDto ToEstudanteCandidatoDto(Estudante estudante)
    {
        return new EstudanteCandidatoDto(
            estudante.id,
            estudante.nome,
            estudante.dataDeNascimento,
            Endereco.ToEnderecoCadastroDto(estudante.endereco),
            estudante.linkCurriculo,
            estudante.linkFoto,
            estudante.telefone
        );
    }
    
    public static IEnumerable<EstudanteCandidatoDto> ToEstudanteCandidatoDtoList(IEnumerable<Estudante> lista)
    {
        IList<EstudanteCandidatoDto> candidatos = new List<EstudanteCandidatoDto>();
        foreach (Estudante estudante in lista)
            candidatos.Add(ToEstudanteCandidatoDto(estudante));
        return candidatos;
    }

    public static Estudante FromEstudanteCompletoDto(EstudanteCompletoDto estudanteDto)
    {
        return new Estudante(
            estudanteDto.id ?? 0,
            estudanteDto.nome,
            estudanteDto.sobre,
            estudanteDto.telefone,
            estudanteDto.linkFoto,
            Endereco.FromEnderecoCompletoDto(estudanteDto.endereco),
            estudanteDto.cpf,
            estudanteDto.valorDaBolsa,
            estudanteDto.linkCurriculo,
            estudanteDto.dataDeNascimento,
            Curso.FromCursoDto(estudanteDto.curso),
            Competencia.FromCompetenciaDtoList(estudanteDto.competencias),
            estudanteDto.modalidade,
            estudanteDto.turno
        );
    }

    public static EstudanteCompletoDto ToEstudanteCompletoDto(Estudante estudante)
    {
        return new EstudanteCompletoDto(
            estudante.id,
            estudante.nome,
            estudante.sobre,
            estudante.telefone,
            estudante.linkFoto,
            Endereco.ToEnderecoCadastroDto(estudante.endereco),
            estudante.cpf,
            estudante.pretencaoSalarial,
            estudante.linkCurriculo,
            estudante.dataDeNascimento,
            estudante.curso is null ? null : Curso.ToCursoDto(estudante.curso),
            Competencia.ToCompetenciaDtoList(estudante.competencias),
            estudante.modalidade,
            estudante.turno
        );
    }


}