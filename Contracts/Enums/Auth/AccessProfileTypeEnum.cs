using System.ComponentModel.DataAnnotations;

namespace Contracts.Enums.Auth
{
    public enum AccessProfileTypeEnum
    {
        [Display(Name = "Admin", Description = "Admin Geral")]
        GeneralAdmin = 1
    }
}
