using BVallejoT6.Models;
using System.Collections.ObjectModel;
using System.Net;

namespace BVallejoT6.Views;

public partial class VAgregar : ContentPage
{
    private const string url = "http://192.168.100.19/Movile/wsuser.php";
    public VAgregar()
	{
		InitializeComponent();
	}

    private void btnSave_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros= new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
			cliente.UploadValues(url, "POST", parametros);
			Navigation.PushAsync(new VUser());
        }
		catch (Exception ex)
		{

			DisplayAlert("Alert", ex.Message, "ok");
		}

    }
}