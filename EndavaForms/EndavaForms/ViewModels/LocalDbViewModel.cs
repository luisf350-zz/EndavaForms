using Prism.Navigation;

namespace EndavaForms.ViewModels
{
    public class LocalDbViewModel : ViewModelBase
    {
        #region Constructor

        public LocalDbViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Local DB";
        }

        #endregion

    }
}
