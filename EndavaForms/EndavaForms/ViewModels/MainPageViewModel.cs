using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace EndavaForms.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Commands

        public DelegateCommand<string> NavigateCommand { get; set; }

        #endregion

        #region Contructor

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            InstanciarObjetos();
        }

        #endregion

        #region Metodos Privados

        private void InstanciarObjetos()
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private async void Navigate(string pagina)
        {
            await NavigationService.NavigateAsync($@"NavigationPage\{pagina}");
        }

        #endregion

    }
}
