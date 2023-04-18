using ShopAPI.Models.Entities;

namespace ShopAPI.Models.ViewModels.Admin
{
    public class RoleRequestViewModel : RoleViewModel
    {
        public RoleRequestViewModel() { }

        public RoleRequestViewModel(Role role) : base(role)
        {
        }
    }
}
