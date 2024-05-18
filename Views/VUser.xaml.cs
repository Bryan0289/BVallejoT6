using BVallejoT6.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BVallejoT6.Views;

public partial class VUser : ContentPage
{

	private const string url = "http://192.168.100.19/Movile/wsuser.php";
	private readonly HttpClient client= new HttpClient();
	private ObservableCollection<User> users;

	public VUser()
	{
		InitializeComponent();
		Obtener();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

		Obtener();
    }

    public async void Obtener()
	{
		var content = await client.GetStringAsync(url);
		List<User> mostrarUser= JsonConvert.DeserializeObject<List<User>>(content);
		users= new ObservableCollection<User>(mostrarUser);
		listaUser.ItemsSource = users;
	}

    private void Agregar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VAgregar());
    }

    private void listaUser_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		
		var user = (User)e.SelectedItem;
		Navigation.PushAsync(new VEditar(user));

    }
}