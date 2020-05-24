using Code.Model.Abstract;
using Core.Model;
using EmployeePortfolio;
using Home.Employees;
using Home.Main;
using Home.NavigationHelper;
using Home.Products;
using Microsoft.Extensions.DependencyInjection;
using SqlDbContext;
using System;

namespace Home.ContainerHelper
{
    public sealed class ViewModelLocator
    {
        private readonly static ServiceProvider serviceProvider;

        static ViewModelLocator()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<INavigationService, FrameNavigationService>();
            collection.AddScoped<MainViewModel>();
            SetupEmployee(collection);
            collection.AddScoped<ProductsViewModel>();

            serviceProvider = collection.BuildServiceProvider();
            SetupNavigation();
        }

        private static void SetupNavigation()
        {
            var navigationService = serviceProvider.GetService<INavigationService>();
            navigationService.Configure("Employees", new Uri("../Employees/EmployeesPage.xaml", UriKind.Relative));
            navigationService.Configure("EditEmployee", new Uri("../Employees/EditEmployeePage.xaml", UriKind.Relative));
            navigationService.Configure("Products", new Uri("../Products/ProductsPage.xaml", UriKind.Relative));
        }

        private static void SetupEmployee(IServiceCollection collection)
        {
            collection.AddScoped<IEmployeeFactory, EmployeeFactory>();
            collection.AddScoped<ISqlData, SqlData>();

            collection.AddScoped<IEmployeePortfolio, EmployeePortfolio.EmployeePortfolio>();
            collection.AddScoped<EmployeesViewModel>();
        }

        public MainViewModel Main => serviceProvider.GetService<MainViewModel>();
        public EmployeesViewModel EmployeesViewModel => serviceProvider.GetService<EmployeesViewModel>();
        public ProductsViewModel ProductsViewModel => serviceProvider.GetService<ProductsViewModel>();
    }
}
