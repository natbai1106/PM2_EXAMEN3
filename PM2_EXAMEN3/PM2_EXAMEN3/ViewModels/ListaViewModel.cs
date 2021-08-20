using PM2_EXAMEN3.Models;
using PM2_EXAMEN3.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM2_EXAMEN3.ViewModel
{
   public class ListaViewModel : BaseViewModel
    {
        
        Page Page;
        ObservableCollection<Pagos> pago;

        Pagos pagoSelected;
        private byte[] photoArray;
        private ImageSource foto_recibo;
        private bool takeNewPhoto;
        private string urlphoto;
        private string descripcion;
        private double monto;
        private string fecha;

        public Pagos PagoSelected
        {
            get => pagoSelected; set { SetProperty(ref pagoSelected, value); }
        }
        public string Descripcion
        {
            get => descripcion;
            set => SetProperty(ref descripcion, value);
        }

        public double Monto
        {
            get => monto;
            set => SetProperty(ref monto, value);
        }

        public string Fecha
        {
            get => fecha;
            set => SetProperty(ref fecha, value);
        }

        public ObservableCollection<Pagos> ListaPago
        {
            get => pago; set => SetProperty(ref pago, value);
        }
        public byte[] PhotoByteArray { get => photoArray; set { photoArray = value; } }

        public ImageSource Foto_recibo
        {
            get => foto_recibo;
            set
            {
                SetProperty(ref foto_recibo, value);
            }
        }
        public bool TakeNewPhoto { get => takeNewPhoto; set => takeNewPhoto = value; }

        public string UrlPhoto
        {
            get => urlphoto; set { SetProperty(ref urlphoto, value); }
        }

        public ListaViewModel(Page pag)
        {
            Page = pag;
            cargar();
        }

        public async void cargar()
        {
            var list = await App.InstanciaBD.ObtenerPago();
            if (list != null)
                ListaPago = new ObservableCollection<Pagos>(list);
        }
    }
}