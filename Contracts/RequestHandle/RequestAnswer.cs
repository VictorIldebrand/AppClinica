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

        [Display(Description = "Erro no UserFilter")]
        UserFilterError,

        #endregion

        #region Student

        [Display(Description = "Aluno não encontrado.")]
        StudentNotFound,

        [Display(Description = "Email ou senha incorretos.")]
        StudentCredError,

        [Display(Description = "Aluno criado com sucesso!")]
        StudentCreateSuccess,

        [Display(Description = "Erro ao registrar o aluno.")]
        StudentCreateError,

        [Display(Description = "Aluno já cadastrado.")]
        StudentDuplicateCreateError,

        [Display(Description = "Aluno atualizado com sucesso!")]
        StudentUpdateSuccess,

        [Display(Description = "Erro ao atualizar o aluno.")]
        StudentUpdateError,

        [Display(Description = "Aluno excluído com sucesso!")]
        StudentDeleteSuccess,

        [Display(Description = "Erro ao excluir o aluno.")]
        StudentDeleteError,

        [Display(Description = "Você receberá um email informando a sua senha!")]
        StudentPasswordReminderEmailRequestSuccess,

        [Display(Description = "Erro ao enviar o email informando a sua senha.")]
        StudentPasswordReminderEmailRequestError,

        #endregion

        #region Professor

        [Display(Description = "Professor não encontrado.")]
        ProfessorNotFound,

        [Display(Description = "Email ou senha incorretos.")]
        ProfessorCredError,

        [Display(Description = "Professor criado com sucesso!")]
        ProfessorCreateSuccess,

        [Display(Description = "Erro ao registrar o professor.")]
        ProfessorCreateError,

        [Display(Description = "Professor já cadastrado.")]
        ProfessorDuplicateCreateError,

        [Display(Description = "Professor atualizado com sucesso!")]
        ProfessorUpdateSuccess,

        [Display(Description = "Erro ao atualizar o professor.")]
        ProfessorUpdateError,

        [Display(Description = "Professor excluído com sucesso!")]
        ProfessorDeleteSuccess,

        [Display(Description = "Erro ao excluir o professor.")]
        ProfessorDeleteError,

        [Display(Description = "Você receberá um email informando a sua senha!")]
        ProfessorPasswordReminderEmailRequestSuccess,

        [Display(Description = "Erro ao enviar o email informando a sua senha.")]
        ProfessorPasswordReminderEmailRequestError,

        #endregion

        #region Patient

        [Display(Description = "Paciente não encontrado.")]
        PatientNotFound,

        [Display(Description = "Email ou senha incorretos.")]
        PatientCredError,

        [Display(Description = "Paciente criado com sucesso!")]
        PatientCreateSuccess,

        [Display(Description = "Erro ao registrar o paciente.")]
        PatientCreateError,

        [Display(Description = "Paciente já cadastrado.")]
        PatientDuplicateCreateError,

        [Display(Description = "Paciente atualizado com sucesso!")]
        PatientUpdateSuccess,

        [Display(Description = "Erro ao atualizar o paciente.")]
        PatientUpdateError,

        [Display(Description = "Paciente excluído com sucesso!")]
        PatientDeleteSuccess,

        [Display(Description = "Erro ao excluir o paciente.")]
        PatientDeleteError,

        [Display(Description = "Você receberá um email informando a sua senha!")]
        PatientPasswordReminderEmailRequestSuccess,

        [Display(Description = "Erro ao enviar o email informando a sua senha.")]
        PatientPasswordReminderEmailRequestError,

        #endregion

        #region Employee

        [Display(Description = "Funcionário não encontrado.")]
        EmployeeNotFound,

        [Display(Description = "Email ou senha incorretos.")]
        EmployeeCredError,

        [Display(Description = "Funcionário criado com sucesso!")]
        EmployeeCreateSuccess,

        [Display(Description = "Erro ao registrar o funcionário.")]
        EmployeeCreateError,

        [Display(Description = "Funcionário já cadastrado.")]
        EmployeeDuplicateCreateError,

        [Display(Description = "Funcionário atualizado com sucesso!")]
        EmployeeUpdateSuccess,

        [Display(Description = "Erro ao atualizar o funcionário.")]
        EmployeeUpdateError,

        [Display(Description = "Funcionário excluído com sucesso!")]
        EmployeeDeleteSuccess,

        [Display(Description = "Erro ao excluir o funcionário.")]
        EmployeeDeleteError,

        [Display(Description = "Você receberá um email informando a sua senha!")]
        EmployeePasswordReminderEmailRequestSuccess,

        [Display(Description = "Erro ao enviar o email informando a sua senha.")]
        EmployeePasswordReminderEmailRequestError,
        
        #endregion

        #region Schedule

        [Display(Description = "Agenda não encontrada.")]
        ScheduleNotFound,

        [Display(Description = "Agenda criada com sucesso!")]
        ScheduleCreateSuccess,

        [Display(Description = "Erro ao registrar a agenda.")]
        ScheduleCreateError,

        [Display(Description = "Agenda já cadastrada.")]
        ScheduleDuplicateCreateError,

        [Display(Description = "Agenda atualizada com sucesso!")]
        ScheduleUpdateSuccess,

        [Display(Description = "Erro ao atualizar a agenda.")]
        ScheduleUpdateError,

        [Display(Description = "Agenda excluída com sucesso!")]
        ScheduleDeleteSuccess,

        [Display(Description = "Erro ao excluir a agenda.")]
        ScheduleDeleteError,

        #endregion

        #region PatientRequest

        [Display(Description = "Requerimento de paciente não encontrado.")]
        PatientRequestNotFound,

        [Display(Description = "Requerimento de paciente criado com sucesso!")]
        PatientRequestCreateSuccess,

        [Display(Description = "Erro ao registrar o requerimento de paciente.")]
        PatientRequestCreateError,

        [Display(Description = "Requerimento de paciente já cadastrado.")]
        PatientRequestDuplicateCreateError,

        [Display(Description = "Requerimento de paciente atualizado com sucesso!")]
        PatientRequestUpdateSuccess,

        [Display(Description = "Erro ao atualizar o requerimento de paciente.")]
        PatientRequestUpdateError,

        [Display(Description = "Requerimento de paciente excluído com sucesso!")]
        PatientRequestDeleteSuccess,

        [Display(Description = "Erro ao excluir o requerimento de paciente.")]
        PatientRequestDeleteError,

        #endregion

        #region Appointment

        [Display(Description = "Consulta não encontrada.")]
        AppointmentNotFound,

        [Display(Description = "Consulta criada com sucesso!")]
        AppointmentCreateSuccess,

        [Display(Description = "Erro ao registrar a consulta.")]
        AppointmentCreateError,

        [Display(Description = "Consulta já cadastrada.")]
        AppointmentDuplicateCreateError,

        [Display(Description = "Consulta atualizada com sucesso!")]
        AppointmentUpdateSuccess,

        [Display(Description = "Erro ao atualizar a consulta.")]
        AppointmentUpdateError,

        [Display(Description = "Consulta excluída com sucesso!")]
        AppointmentDeleteSuccess,

        [Display(Description = "Erro ao excluir a consulta.")]
        AppointmentDeleteError,

        #endregion

        #region Notification

        [Display(Description = "Notificação não encontrada.")]
        NotificationNotFound,

        [Display(Description = "Notificação criada com sucesso!")]
        NotificationCreateSuccess,

        [Display(Description = "Erro ao registrar a notificação.")]
        NotificationCreateError,

        [Display(Description = "Notificação já cadastrada.")]
        NotificationDuplicateCreateError,

        [Display(Description = "Notificação atualizada com sucesso!")]
        NotificationUpdateSuccess,

        [Display(Description = "Erro ao atualizar a notificação.")]
        NotificationUpdateError,

        [Display(Description = "Notificação excluída com sucesso!")]
        NotificationDeleteSuccess,

        [Display(Description = "Erro ao excluir a notificação.")]
        NotificationDeleteError,

        #endregion

        // #region PatientOrder

        // [Display(Description = "Solicitação de paciente não encontrado.")]
        // PatientOrderNotFound,

        // [Display(Description = "Solicitação de paciente criado com sucesso!")]
        // PatientOrderCreateSuccess,

        // [Display(Description = "Erro ao registrar o solicitação de paciente.")]
        // PatientOrderCreateError,

        // [Display(Description = "Solicitação de paciente já cadastrado.")]
        // PatientOrderDuplicateCreateError,

        // [Display(Description = "Solicitação de paciente atualizado com sucesso!")]
        // PatientOrderUpdateSuccess,

        // [Display(Description = "Erro ao atualizar o solicitação de paciente.")]
        // PatientOrderUpdateError,

        // [Display(Description = "Solicitação de paciente excluído com sucesso!")]
        // PatientOrderDeleteSuccess,

        // [Display(Description = "Erro ao excluir o solicitação de paciente.")]
        // PatientOrderDeleteError,

        // #endregion

        #region ScheduleProfessor

        [Display(Description = "Agenda professor não encontrada.")]
        ScheduleProfessorNotFound,

        [Display(Description = "Agenda professor criada com sucesso!")]
        ScheduleProfessorCreateSuccess,

        [Display(Description = "Erro ao registrar a agenda professor.")]
        ScheduleProfessorCreateError,

        [Display(Description = "Agenda professor já cadastrada.")]
        ScheduleProfessorDuplicateCreateError,

        [Display(Description = "Agenda professor atualizada com sucesso!")]
        ScheduleProfessorUpdateSuccess,

        [Display(Description = "Erro ao atualizar a agenda professor.")]
        ScheduleProfessorUpdateError,

        [Display(Description = "Agenda professor excluída com sucesso!")]
        ScheduleProfessorDeleteSuccess,

        [Display(Description = "Erro ao excluir a agenda professor.")]
        ScheduleProfessorDeleteError,

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