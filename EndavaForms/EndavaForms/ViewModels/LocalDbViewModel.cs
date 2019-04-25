using Prism.Navigation;
using Prism.Services;

namespace EndavaForms.ViewModels
{
    public class LocalDbViewModel : ViewModelBase
    {
        #region Constructor

        public LocalDbViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            Title = "Local DB";
        }

        #endregion

    }
}
