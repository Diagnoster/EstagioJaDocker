using System.Text;

namespace EstagioJaAPI.Utils;

public class EncriptadorDeSenha {

    public static string Criptografar(string senha) {
        byte[] senhaEmBytes = Encoding.ASCII.GetBytes(senha);
        senhaEmBytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(senhaEmBytes);
        return Encoding.ASCII.GetString(senhaEmBytes);
    }

}