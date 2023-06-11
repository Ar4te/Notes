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
            //await DisplayAlert("��½�ɹ�", $"��ӭ��{login.userNo}", "OK");
            await Toast.Make("��½�ɹ�", ToastDuration.Short, 14).Show(new CancellationTokenRegistration().Token);
            await Shell.Current.GoToAsync("..");
        }
        else
        {
            //DisplayAlert("��½ʧ��", $"����ȷ�����¼��������", "OK");
            await Toast.Make("����ȷ�����¼��������", ToastDuration.Short, 14).Show(new CancellationTokenSource().Token);
        }
    }
}