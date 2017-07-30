using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using XF_HW2.Models;
using XF_HW2.Repositories;

namespace XF_HW2.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ShoppingItem> ShoppingItemList { get; set; } = new ObservableCollection<ShoppingItem>();
        private readonly INavigationService _navigationService;

        public bool ShowBusyMark { get; set; }
        public int? TotalPrice { get; set; } = 0;
        public DelegateCommand TotalPriceCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            TotalPriceCommand = new DelegateCommand(async () => {
                ShowBusyMark = true;
                CalculateSum();
                await Task.Delay(2000);
                ShowBusyMark = false;
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            ShoppingRepository fooShoppingRepository = new ShoppingRepository();
            var fooShoppingItemList = fooShoppingRepository.GetShoppingItem();
            foreach (var item in fooShoppingItemList)
            {
                ShoppingItemList.Add(new ShoppingItem
                {
                    Name = item.Name,
                    Price = item.Price,
                    Qty = item.Qty,
                    UpdateSumCommand = new DelegateCommand(CalculateSum),
                });
            }
        }

        public void CalculateSum()
        {
            TotalPrice = 0;
            foreach (var item in ShoppingItemList)
            {
                var SubPrice = item.Price * item.Qty;
                if (SubPrice != null)
                {
                    TotalPrice += SubPrice;
                }
            }
        }
    }
}
