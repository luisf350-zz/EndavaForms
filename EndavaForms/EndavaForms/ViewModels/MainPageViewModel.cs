using Prism.Commands;
using Prism.Navigation;

namespace EndavaForms.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Commands

        public DelegateCommand<string> NavigateCommand { get; set; }

        #endregion

        #region Contructor

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
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
