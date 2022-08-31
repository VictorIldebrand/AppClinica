using System.ComponentModel.DataAnnotations;

namespace Contracts.RequestHandle
{
    public enum RequestAnswer
    {
        #region User

        [Display(Description = "Usuário não encontrado.")]
        UserNotFound,

        [Display(Description = "Email ou senha incorretos.")]
        UserCredError,

        [Display(Description = "Usuário criado com sucesso!")]
        UserCreateSuccess,

        [Display(Description = "Erro ao registrar o usuário.")]
        UserCreateError,

        [Display(Description = "Usuário já cadastrado.")]
        UserDuplicateCreateError,

        [Display(Description = "Usuário atualizado com sucesso!")]
        UserUpdateSuccess,

        [Display(Description = "Erro ao atualizar o usuário.")]
        UserUpdateError,

        [Display(Description = "Usuário excluído com sucesso!")]
        UserDeleteSuccess,

        [Display(Description = "Erro ao excluir o usuário.")]
        UserDeleteError,

        [Display(Description = "Você receberá um email informando a sua senha!")]
        UserPasswordReminderEmailRequestSuccess,

        [Display(Description = "Erro ao enviar o email informando a sua senha.")]
        UserPasswordReminderEmailRequestError,

        [Display(Description = "Ocorreu um error ao tentar fazer o login.")]
        LoginError,

        #endregion

        #region Token

        [Display(Description = "Senha atualizada com sucesso")]
        ResetPasswordSuccess,

        [Display(Description = "Token inválido")]
        InvalidToken,

        [Display(Description = "Token expirado")]
        TokenExpired,

        [Display(Description = "Este token já foi utilizado")]
        TokenIsTaken,

        [Display(Description = "Token criado com sucesso")]
        TokenCreateSuccess,

        [Display(Description = "Token atualizado com sucesso")]
        TokenUpdateSuccess

        #endregion
    }
}