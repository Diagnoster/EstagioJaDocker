namespace EstagioJaAPI.Dtos
{
    public class CandidaturaDto
    {

        public CandidaturaDto(int idVaga, int idEstudante) {
            this.idVaga = idVaga;
            this.idEstudante = idEstudante;
        }

        public int idVaga { get; set; }
        public int idEstudante { get; set; }

    }
}
