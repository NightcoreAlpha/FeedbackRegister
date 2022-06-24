using Handicraft.Infrastructure;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Handicraft.Data
{
    public class RegistrationModel : ComponentBase
    {
        [Inject] public ILocalStorageService LocalStorageService { get; set; }
        [Inject] public NavigationManager navigationManager { get; set; }
        public RegistrationModel()
        {
            LoginData = new RegistrationViewModel();
        }
        public RegistrationViewModel LoginData { get; set; }
        protected async Task LoginAsync()
        {
            var token = new SecurityToken
            {
                AccessToken = LoginData.Password,
                UserName = LoginData.UserName,
                ExpiredAt = DateTime.UtcNow.AddDays(1)
            };
            await LocalStorageService.SetAsync(nameof(SecurityToken), token);
            navigationManager.NavigateTo("/", true);
        }
    }
    public class RegistrationViewModel
    {
        [Required]
        public string UserName { get; set; }
        //[Required]
        //public string Login { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Не более 15 символов")]
        public string Password { get; set; }
    }
    public class SecurityToken
    {
        public string UserName { get; set; }
        //public string Login { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
