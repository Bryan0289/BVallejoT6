using BVallejoT6.Models;
using GoogleGson.Annotations;
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
	public async void Obtener()
	{
		var content = await client.GetStringAsync(url);
		List<User> mostrarUser= JsonConvert.DeserializeObject<List<User>>(content);
		users= new ObservableCollection<User>(mostrarUser);
		listaUser.ItemsSource = users;
	}
}