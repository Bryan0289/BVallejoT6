using BVallejoT6.Models;
using System.Net;

namespace BVallejoT6.Views;

public partial class VEditar : ContentPage
{
    private const string url = "http://192.168.100.19/Movile/wsuser.php";
    public VEditar(User user)
	{
		InitializeComponent();
        txtId.Text = user.id.ToString();
		txtNombre.Text = user.nombre;
        txtApellido.Text = user.apellido;
        txtEdad.Text = user.edad.ToString();
        
    }

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("ok","edita","ok");
        try
        {
            WebClient cliente = new WebClient();
            var newUrl = url + "?id=" + txtId.Text;
            newUrl += "&nombre=" + txtNombre.Text;
            newUrl += "&apellido=" + txtApellido.Text;
            newUrl += "&edad=" + txtEdad.Text;

            cliente.UploadValues(newUrl, "PUT", new System.Collections.Specialized.NameValueCollection());
            DisplayAlert("Bien", "Elemento Editado correctamente", "OK");
            await Navigation.PopToRootAsync();
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void btnDelete_Clicked(object sender, EventArgs e)
    {
        bool respuesta = await DisplayAlert("Confirmar", "¿Estás seguro de que deseas eliminar este elemento?", "Sí", "No");

        if (respuesta)
        {
            try
            {
                WebClient cliente = new WebClient();
                var newUrl = url + "?id=" + txtId.Text;

                cliente.UploadValues(newUrl, "DELETE", new System.Collections.Specialized.NameValueCollection());
                await DisplayAlert("Bien", "Elemento eliminado correctamente", "OK");
                await Navigation.PopToRootAsync();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

    }
}