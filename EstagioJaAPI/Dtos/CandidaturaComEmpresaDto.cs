namespace EstagioJaAPI.Dtos
{
    public class CandidaturaComEmpresaDto
    {

        public CandidaturaComEmpresaDto(int idVaga, int idEstudante, int idEmpresa)
        {
            this.idVaga = idVaga;
            this.idEstudante = idEstudante;
            this.idEmpresa = idEmpresa;
        }

        public int idVaga { get; set; }
        public int idEstudante { get; set; }
        public int idEmpresa { get; set; }

    }
}
