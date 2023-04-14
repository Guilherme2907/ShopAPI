using ShopAPI.Models.Entities;

namespace ShopAPI.Models.ViewModels.Admin
{
    public abstract class RoleViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        protected RoleViewModel(Role role)
        {
            Name = role.Name;
            Description = role.Description;
        }
    }
}
