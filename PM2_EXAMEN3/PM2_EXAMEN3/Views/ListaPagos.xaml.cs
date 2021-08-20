using PM2_EXAMEN3.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2_EXAMEN3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPagos : ContentPage
    {
        public ListaPagos()
        {
            InitializeComponent();
            BindingContext = new ListaViewModel(this);
        }
    }
}