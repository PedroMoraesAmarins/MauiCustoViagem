﻿using MauiCustoViagem.Models;
using static System.Net.Mime.MediaTypeNames;

namespace MauiCustoViagem
{
    public partial class MainPage : ContentPage
    {
        public static Viagem vg;

        public MainPage()
        {
            InitializeComponent();
        }

        private void btn_createPedagio_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.CriarPedagio());
        }

        private void btn_listPedagio_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.ListarPedagio());
        }

        private async void btn_calcular_Clicked(object sender, EventArgs e)
        {
            if (txt_origem.Text == null)
            {
                await DisplayAlert("Erro", "Preencha o lugar de origem", "Ok");
                return;
            }
            if (txt_destino.Text == null)
            {
                await DisplayAlert("Erro", "Preencha o destino", "Ok");
                return;
            }
            if (txt_distancia.Text == null)
            {
                await DisplayAlert("Erro", "Preencha o valor da distancia", "Ok");
                return;
            }
            if (txt_rendimento.Text == null)
            {
                await DisplayAlert("Erro", "Preencha o valor do rendimento", "Ok");
                return;
            }
            if (txt_combustivel.Text == null)
            {
                await DisplayAlert("Erro", "Preencha o valor do combustivel", "Ok");
                return;
            }

            vg = new Viagem
            {
                valor_gas = Convert.ToDouble(txt_combustivel.Text),
                destino = txt_destino.Text,
                origem = txt_origem.Text,
                distancia = Convert.ToDouble(txt_distancia.Text),
                rendimento = Convert.ToDouble(txt_rendimento.Text),
            };


            await Navigation.PushAsync(new View.CalcularViagem());
        }
    }

}
