using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using XF_HW2.Models;
using XF_HW2.Repositories;

namespace XF_HW2.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ShoppingItem> ShoppingItemList { get; set; } = new ObservableCollection<ShoppingItem>();
        //public ShoppingItem ShppingItemSelected { get; set; }
        //public readonly IPageDialogService _dialogService;
        public string TotalPrice { get; set; } = "總共金額:";
        public DelegateCommand ShoppingItemSelectedCommand { get; set; }
        public DelegateCommand TotalPriceCommand { get; set; }

        public MainPageViewModel()//IPageDialogService dialogService)
        {
            //_dialogService = dialogService;
            //ShoppingItemSelectedCommand = new DelegateCommand(async () =>
            //{
            //    await _dialogService.DisplayAlertAsync("Info", $"你選取的是 {ShppingItemSelected.Name}", "OK");
            //});
            TotalPriceCommand = new DelegateCommand(() => {
                decimal? iTotalPrice = 0;
                foreach (var item in ShoppingItemList)
                {
                    iTotalPrice += item.Price * item.Qty;
                }
                //iTotalPrice = 100;
                TotalPrice = $"總共金額: {iTotalPrice}";
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
                });
            }
        }
    }
}
