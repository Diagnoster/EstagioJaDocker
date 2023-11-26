namespace EstagioJaAPI.Exceptions;

public class RegistroNaoEncontradoException : Exception {

    public RegistroNaoEncontradoException()
    {
    }

    public RegistroNaoEncontradoException(string message)
        : base(message)
    {
    }

    public RegistroNaoEncontradoException(string message, Exception inner)
        : base(message, inner)
    {
    }

}