using Home.CommandHelper;
using Home.NavigationHelper;

namespace Home.Main
{
    public sealed class MainViewModel
    {
        private readonly INavigationService _navigationService;

        public RelayCommand NavigateToEmployeesCommand { get; }
        public RelayCommand NavigateToProductsCommand { get; }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToEmployeesCommand = new RelayCommand(NavigateToEmployees);
            NavigateToProductsCommand = new RelayCommand(NavigateToProducts);
        }

        private void NavigateToEmployees()
        {
            _navigationService.NavigateTo("Employees");
        }

        private void NavigateToProducts()
        {
            _navigationService.NavigateTo("Products");
        }
    }
}
