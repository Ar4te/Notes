using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Notes.Helper;
using Notes.Models;
using Notes.ServerRequest;

namespace Notes.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void LoginBtnClick(object sender, EventArgs e)
    {
        if (BindingContext is Login login && !string.IsNullOrEmpty(login.userNo) && !string.IsNullOrEmpty(login.password))
        {
            var res = await HttpHelper.GetAsync(ServerUrls.GetToken(login));
            //await DisplayAlert("登陆成功", $"欢迎您{login.userNo}", "OK");
            await Toast.Make("登陆成功", ToastDuration.Short, 14).Show(new CancellationTokenRegistration().Token);
            await Shell.Current.GoToAsync("..");
        }
        else
        {
            //DisplayAlert("登陆失败", $"请正确输入登录名及密码", "OK");
            await Toast.Make("请正确输入登录名及密码", ToastDuration.Short, 14).Show(new CancellationTokenSource().Token);
        }
    }
}