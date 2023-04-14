using ShopAPI.Models.Entities;

namespace ShopAPI.Models.ViewModels.Admin
{
    public class RoleResponseViewModel : RoleViewModel
    {
        public string Id { get; set; }

        public RoleResponseViewModel(Role role) : base(role)
        {
            Id = role.Id;
        }
    }
}
