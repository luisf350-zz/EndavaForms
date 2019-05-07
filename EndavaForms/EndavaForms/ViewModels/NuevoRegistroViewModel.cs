using EndavaForms.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Realms;
using System;
using System.Text;

namespace EndavaForms.ViewModels
{
    public class NuevoRegistroViewModel : ViewModelBase
    {
        #region Atributos

        private string _nombre;

        private string _apellido;

        private DateTime _fechaNacimiento;

        #endregion

        #region Propiedades

        public string Nombre
        {
            get => _nombre;
            set => SetProperty(ref _nombre, value);
        }

        public string Apellido
        {
            get => _apellido;
            set => SetProperty(ref _apellido, value);
        }

        public DateTime FechaNacimiento
        {
            get => _fechaNacimiento;
            set => SetProperty(ref _fechaNacimiento, value);
        }

        #endregion

        #region Commands

        public DelegateCommand GuardarCommand { get; set; }

        #endregion

        #region Contructor

        public NuevoRegistroViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            InstanciarObjetos();
        }

        #endregion

        #region Metodos Privados

        private void InstanciarObjetos()
        {
            Title = "Nuevo Registro";

            FechaNacimiento = DateTime.Today;

            GuardarCommand = new DelegateCommand(Guardar);
        }

        private async void Guardar()
        {
            string resultado = Validaciones();
            if (string.IsNullOrEmpty(resultado))
            {
                Realm realm = Realm.GetInstance();

                realm.Write(() =>
                {
                    realm.Add(new Estudiantes
                    {
                        Id = Guid.NewGuid().ToString(),
                        Nombre = Nombre,
                        Apellido = Apellido,
                        FechaNacimiento = new DateTimeOffset(FechaNacimiento)
                    });
                });

                await DialogService.DisplayAlertAsync("Guardar", "El registro se guardo de manera exitosa", "Ok");
                await NavigationService.GoBackAsync();
            }
            else
            {
                await DialogService.DisplayAlertAsync("Guardar", $"Se encontraron las siguientes validaciones:{Environment.NewLine}{resultado}", "Ok");
            }
        }

        private string Validaciones()
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(Nombre))
            {
                sb.AppendLine("Ingrese el nombre.");
            }
            if (string.IsNullOrEmpty(Apellido))
            {
                sb.AppendLine("Ingrese el apellido.");
            }
            if (FechaNacimiento.Date > DateTime.Today)
            {
                sb.AppendLine("La fecha de nacimiento no puede ser mayor al día actual.");
            }

            return sb.ToString();
        }

        #endregion

    }
}
