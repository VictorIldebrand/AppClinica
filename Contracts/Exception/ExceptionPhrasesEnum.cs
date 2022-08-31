using System.ComponentModel;

namespace Contracts.Exception
{
    public enum ExceptionPhrasesEnum
    {
        [Description("Email ou senha invalido.")]
        WhrongEmailOrPassword = 401,

        [Description("Email já cadastrado.")]
        EmailAlreadyExists = 400,
    }
}
