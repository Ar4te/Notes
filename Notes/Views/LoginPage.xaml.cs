using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Newtonsoft.Json;
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
            var res = JsonConvert.DeserializeObject<MessageModel<string>>(await HttpHelper.GetAsync(ServerUrls.GetToken(login)));
            if (res != null)
            {
                if (res.success)
                {
                    ServerUrls.token = res.response;
                    await Toast.Make("登陆成功", ToastDuration.Short, 14).Show(new CancellationTokenRegistration().Token);
                    await Shell.Current.GoToAsync("..");
                }
                else await Toast.Make(res.msg, ToastDuration.Short, 14).Show(new CancellationTokenSource().Token);
            }
            else await Toast.Make("无法连接服务器", ToastDuration.Short, 14).Show(new CancellationTokenSource().Token);
        }
        else
        {
            //DisplayAlert("登陆失败", $"请正确输入登录名及密码", "OK");
            await Toast.Make("请正确输入登录名及密码", ToastDuration.Short, 14).Show(new CancellationTokenSource().Token);
        }
    }
}