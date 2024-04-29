using MauiCustoViagem.Models;

namespace MauiCustoViagem.View;

public partial class CalcularViagem : ContentPage
{
    double total = 0;
    double valor_pedagio = 0;

    public CalcularViagem()
	{
		InitializeComponent();

        lbl_local.Text = "Origem: " + MainPage.vg.origem;
        lbl_destino.Text = "Destino: " + MainPage.vg.destino;
        lbl_valor.IsVisible = false;
    }

    private void btn_sum_Clicked(object sender, EventArgs e)
    {
        Viagem empty_viagem = new Viagem
        {
            valor_gas = 1.0,
            rendimento = 1.0,
            destino = "",
            distancia = 1.0,
            origem = "",
        };

        MainPage.vg = empty_viagem;
        Navigation.PushAsync(new MainPage());
    }

    private async void btn_newViagem_Clicked(object sender, EventArgs e)
    {
        double consumo_Carro = ((MainPage.vg.distancia / MainPage.vg.rendimento) * MainPage.vg.valor_gas);

        List<Pedagio> pedagios = await App.Db.GetAll();
        foreach (Pedagio p in pedagios)
        {
            valor_pedagio += p.valor;
        }

        total = consumo_Carro + valor_pedagio;
        await DisplayAlert("Soma total:", $"Pedagio: {valor_pedagio.ToString("C")}\nConsumo: {consumo_Carro.ToString("C")}\n---------\nTotal: {total.ToString("C")}", "Ok");
        lbl_valor.Text = "Valor: " + total.ToString("C");
        lbl_valor.IsVisible = true;
    }
}