using EndavaForms.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Realms;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EndavaForms.ViewModels
{
    public class LocalDbViewModel : ViewModelBase
    {
        #region Atributos

        private ObservableCollection<Estudiantes> _registros;

        #endregion

        #region Propiedades

        public ObservableCollection<Estudiantes> Registros
        {
            get => _registros;
            set => SetProperty(ref _registros, value);
        }

        #endregion

        #region Commands

        public DelegateCommand NuevoRegistroCommand { get; set; }

        #endregion

        #region Constructor

        public LocalDbViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            InstanciarObjetos();
        }

        #endregion

        #region Metodos Privados

        private void InstanciarObjetos()
        {
            Title = "Local DB";

            NuevoRegistroCommand = new DelegateCommand(NuevoRegistro);

            CargarRegistros();
        }

        private void CargarRegistros()
        {
            Registros = new ObservableCollection<Estudiantes>();

            Realm realm = Realm.GetInstance();

            IEnumerable<Estudiantes> listaEstudiantes = realm.All<Estudiantes>();

            foreach (Estudiantes lo in listaEstudiantes)
            {
                Registros.Add(lo);
            }
        }

        private async void NuevoRegistro()
        {
            await DialogService.DisplayAlertAsync("Nuevo Registro", "No se tiene implementación", "Ok");
        }

        #endregion

    }
}
