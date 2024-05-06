using MauiCustoViagem.Models;

namespace MauiCustoViagem.View;

public partial class CriarPedagio : ContentPage
{
	public CriarPedagio()
	{
		InitializeComponent();
	}

    private async void btn_enviar_Clicked(object sender, EventArgs e)
    {
        try
        {
            Pedagio p = new Pedagio();
            p.local = txt_local.Text;
            p.valor = Convert.ToDouble(txt_valor.Text);

            await App.Db.Insert(p);
            await DisplayAlert("Sucesso!", "Pedagio foi adicionado", "Ok");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Ok");
        }
    }

    private void btn_voltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}