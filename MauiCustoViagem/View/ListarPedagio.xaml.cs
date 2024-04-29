using MauiCustoViagem.Models;
using System.Collections.ObjectModel;

namespace MauiCustoViagem.View;

public partial class ListarPedagio : ContentPage
{
    ObservableCollection<Pedagio> lista_pedagios = new ObservableCollection<Pedagio>();
    public ListarPedagio()
	{
		InitializeComponent();
        lst_pedagios.ItemsSource = lista_pedagios;
    }

    protected async override void OnAppearing()
    {
        if (lista_pedagios.Count == 0)
        {
            List<Pedagio> tmp = await App.Db.GetAll();
            foreach (Pedagio p in tmp)
            {
                lista_pedagios.Add(p);
            }
        }
    }

    private void lst_pedagios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }
}