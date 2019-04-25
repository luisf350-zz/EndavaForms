using EndavaForms.DTO;
using EndavaForms.Service;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EndavaForms.ViewModels
{
    public class ListaRestViewModel : ViewModelBase
    {
        #region Atributos

        private ObservableCollection<FotosDto> _registros;

        #endregion

        #region Propiedades

        public ObservableCollection<FotosDto> Registros
        {
            get => _registros;
            set => SetProperty(ref _registros, value);
        }

        #endregion

        #region Commands

        #endregion

        #region Constructor

        public ListaRestViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            InstanciarObjetos();
        }

        #endregion

        #region Metodos Privados

        private void InstanciarObjetos()
        {
            Title = "Lista Rest";

            ConsumirServicio();
        }

        private async void ConsumirServicio()
        {
            Registros = new ObservableCollection<FotosDto>();
            IsBusy = true;
            try
            {
                List<FotosDto> result = await ObtenerRegistros();

                foreach (FotosDto lo in result)
                {
                    Registros.Add(lo);
                }
                
            }
            catch (Exception ex)
            {
                await DialogService.DisplayAlertAsync("Error", ex.Message, "OK");
            }
            IsBusy = false;
        }

        private async Task<List<FotosDto>> ObtenerRegistros()
        {
            WSClient client = new WSClient();
            return await client.Get<List<FotosDto>>("http://jsonplaceholder.typicode.com/photos");
        }

        #endregion

    }
}
