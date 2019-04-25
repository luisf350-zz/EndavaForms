using Prism.Navigation;
using Prism.Services;

namespace EndavaForms.ViewModels
{
    public class ListaRestViewModel : ViewModelBase
    {
        #region Constructor

        public ListaRestViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            Title = "Lista Rest";
        }

        #endregion

    }
}
