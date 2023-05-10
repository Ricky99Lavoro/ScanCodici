namespace DXMauiApp_ScanCodici.Pages;

public partial class LoginPage : ContentPage
{
    public static int _textEditCodeLogin;
	public LoginPage()
	{
        InitializeComponent();
	}

    private async void Button_RetrieveIdDocTes(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(textEditCodeLogin.Text))
        {
            _textEditCodeLogin = int.Parse(textEditCodeLogin.Text);
            await Navigation.PushAsync(new MainPage(int.Parse(textEditCodeLogin.Text)));
        }
    }
}