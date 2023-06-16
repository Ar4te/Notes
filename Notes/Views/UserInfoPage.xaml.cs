namespace Notes.Views;

public partial class UserInfoPage : ContentPage
{
    public UserInfoPage()
    {
        InitializeComponent();
        //webView.Source = @"http://121.196.199.65:18882/swagger/index.html";
        webView.Source = @"https://www.csdn.net";
        webView.HeightRequest = DeviceDisplay.Current.MainDisplayInfo.Height / 3;
        webView.WidthRequest = DeviceDisplay.Current.MainDisplayInfo.Width / 3;
    }
}