using Prism.Navigation;

namespace EndavaForms.ViewModels
{
    public class CalculadoraViewModel : ViewModelBase
    {
        #region Constructor

        public CalculadoraViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Calculadora";
        }

        #endregion

    }
}
