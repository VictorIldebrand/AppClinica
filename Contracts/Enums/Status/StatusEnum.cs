using System.ComponentModel.DataAnnotations;

namespace Contracts.Enums.Status {
    public enum StatusEnum {
        #region Appointment
        
        [Display(Name = "Cancelado")]
        Canceled = 1,

        [Display(Name = "Confirmado")]
        Confirmed = 2,

        [Display(Name = "Notificado")]
        Notified = 3,

        [Display(Name = "Criado")]
        Created = 4,

        #endregion
    }
}
