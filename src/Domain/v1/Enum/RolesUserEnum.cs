using System.ComponentModel;

namespace Fatec.Store.Orders.Domain.v1.Enum
{
    public enum RolesUserEnum
    {
        [Description("Admin")]
        All,

        [Description("User")]
        Admin,

        [Description("User")]
        User
    }
}
