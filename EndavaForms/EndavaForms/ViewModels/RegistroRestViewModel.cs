using EndavaForms.DTO;
using Prism.Navigation;
using Prism.Services;

namespace EndavaForms.ViewModels
{
    public class RegistroRestViewModel : ViewModelBase
    {
        #region Atributos

        private string _itemTitle;

        private string _imageUrl;

        #endregion

        #region Propiedades

        public string ItemTitle
        {
            get => _itemTitle;
            set => SetProperty(ref _itemTitle, value);
        }

        public string ImageUrl
        {
            get => _imageUrl;
            set => SetProperty(ref _imageUrl, value);
        }

        #endregion

        #region Constructor

        public RegistroRestViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
        }

        #endregion

        #region Metodos Privados

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            FotosDto registro = parameters.GetValue<FotosDto>("RegistroSeleccionado");

            if (registro != null)
            {
                Title = $"Id= {registro.Id}";
                ItemTitle = registro.Title;
                ImageUrl = registro.Url;
            }
        }

        #endregion
    }
}
