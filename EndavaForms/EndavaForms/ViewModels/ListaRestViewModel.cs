using Prism.Navigation;

namespace EndavaForms.ViewModels
{
    public class ListaRestViewModel : ViewModelBase
    {
        #region Constructor

        public ListaRestViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Lista Rest";
        }

        #endregion

    }
}
