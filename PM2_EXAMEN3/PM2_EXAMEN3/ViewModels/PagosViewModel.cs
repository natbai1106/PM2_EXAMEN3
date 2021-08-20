using Acr.UserDialogs;
using PM2_EXAMEN3.Models;
using PM2_EXAMEN3.Utils;
using PM2_EXAMEN3.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM2_EXAMEN3.ViewModels
{

    public class PagosViewModel : BaseViewModel
    {
        Page Page;

        public Command SaveInformation { get; }
        public Command TakePhotoCommand { get; }
        public Command OpenGalleryCommand { get; }
        public Command SelectMedia { get; }
        public Command SendVerifyCommand { get; }
        public Command listViewPagos { get; }

        //String UrlFoto;
        String urlphoto;
        int idpago;
        string descripcion;
        double monto;
        string fecha;
        byte[] photoArray;
        bool takeNewPhoto;
        ImageSource foto_recibo;

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

        public byte[] PhotoByteArray { get => photoArray; set { photoArray = value; } }

        public ImageSource Foto_recibo
        {
            get => foto_recibo;
            set
            {
                SetProperty(ref foto_recibo, value);
            }
        }

        public bool TakeNewPhoto 
        {
            get => takeNewPhoto; 
            set => takeNewPhoto = value; 
        }

        public string UrlPhoto
        {
            get => urlphoto; 
            set { SetProperty(ref urlphoto, value); }
        }

        public PagosViewModel(Page pag)
        {
            Page = pag;
            
            UrlPhoto = Constanst.CAR_IMAGE_DEFAULT;
            SaveInformation = new Command(SalvarPago);
            SelectMedia = new Command(OnSelectedMedia);
            listViewPagos = new Command(Lista);
            //SendVerifyCommand = new Command(SalvarPago);
        }

        public async void SalvarPago(object obj)
        {

            if (string.IsNullOrEmpty(Descripcion) || string.IsNullOrEmpty(Fecha) || Monto == 0)
            {
                await Page.DisplayAlert("Mensaje", "Existen campos vacíos ", "Ok");
            }
            else
            {
                var pagos = new Pagos
                {
                    Descripcion = Descripcion,
                    Monto = Convert.ToDouble(Monto),
                    Fecha = Convert.ToString(Fecha),
                    Foto_recibo = PhotoByteArray
                };

                {
                    int resultado = await App.InstanciaBD.InsertPago(pagos);

                    if (resultado > 0)
                    {
                        await Page.DisplayAlert("Aviso", "Guardado exitosamente", "Ok");

                    
                    }

                    else
                        await Page.DisplayAlert("Aviso", "Error", "Ok");
                }
            }
        }
        private async void Lista()
        {
            await Page.Navigation.PushAsync(new ListaPagos());
        }

        /*Abrimos la camara*/
        private async void OnOpenGalery()
        {
            var media = new MediaManager();
            UserDialogs.Instance.ShowLoading("Cargando");
            bool isSuccess = await media.TakePicture();
            LoadPhoto(isSuccess, media);
            UserDialogs.Instance.HideLoading();
        }

        private async void OnTakePhoto()
        {
            var media = new MediaManager();
            //Se crea una instancia de la clase MediaManager para mostrar los cuando se esta cargando
            UserDialogs.Instance.ShowLoading("Cargando");
            bool isSuccess = await media.PickPicture();
            LoadPhoto(isSuccess, media);
            UserDialogs.Instance.HideLoading();
        }

        //Se carga la foto obtenidad de la galeria o camara y la almacena en las variables para mostrarla en la vista
        private void LoadPhoto(bool isSucces, MediaManager media)
        {
            if (isSucces)
            {
                photoArray = media.ByteImage;
                UrlPhoto = media.Path;
                TakeNewPhoto = true;
            }
        }        

        public async void OnSelectedMedia()
        {
            string action = await Page.DisplayActionSheet("Abrir", "Cancel", null, Constanst.CAMARA, Constanst.GALERIA);

            if (action == Constanst.CAMARA)
            {
                OnOpenGalery();
            }
            else if (action == Constanst.GALERIA)
            {
                OnTakePhoto();
            }
        }
    }
}