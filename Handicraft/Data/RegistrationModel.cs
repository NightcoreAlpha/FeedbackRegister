﻿using Handicraft.Infrastructure;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Handicraft.Data;

namespace Handicraft.Data
{
    public class RegistrationModel : ComponentBase
    {
        [Inject] public ILocalStorageService LocalStorageService { get; set; }
        [Inject] public NavigationManager navigationManager { get; set; }
        ConnectDB.User userData = new ConnectDB.User();
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
            userData = new ConnectDB.User
            {
                login = LoginData.UserName,
                password = LoginData.Password
            };
            var checkLogin = GetDataClass.GetUserData(LoginData.UserName, LoginData.Password);
            if(checkLogin.Count == 0)
            {
                return;
            }
            await LocalStorageService.SetAsync(nameof(SecurityToken), token);
            navigationManager.NavigateTo("/", true);
        }
    }
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Укажите имя пользователя")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(15, ErrorMessage = "Не более 15 символов")]
        public string Password { get; set; }
    }
    public class SecurityToken
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
