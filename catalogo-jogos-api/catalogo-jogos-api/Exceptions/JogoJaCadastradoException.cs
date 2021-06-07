using System;

namespace catalogo_jogos_api.Exceptions
{
    public class JogoJaCadastradoException : Exception
    {
        public JogoJaCadastradoException()
            : base("Este jogo já está cadastrado")
        {
        }
    }
}
