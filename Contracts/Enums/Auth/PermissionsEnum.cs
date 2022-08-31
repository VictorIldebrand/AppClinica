using System.ComponentModel.DataAnnotations;

namespace Contracts.Enums.Auth
{
    public enum PermissionsEnum
    {
        #region User

        [Display(Name = "CreateUser", ShortName = "[INSERT]:Login")]
        Login = 1,

        [Display(Name = "CreateUser", ShortName = "[INSERT]:Register")]
        CreateUser = 2,

        [Display(Name = "UpdateUser", ShortName = "[UPDATE]:User")]
        UpdateUser = 3,

        [Display(Name = "DeleteUser", ShortName = "[DELETE]:User")]
        DeleteUser = 4,

        #endregion
    }
}
