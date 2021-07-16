using App10.Common;
using App10.Interfaces;
using App10.Models;
using App10.Services;
using App10.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace App10.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        readonly IDataService<UsersResponse> _UserDataService;

        public ObservableCollection<Users> Users { get; }
        public Command LoadItemsCommand { get; }

        public ItemsViewModel()
        {
            _UserDataService = new DataService<UsersResponse>();
            Title = "Users";
            Users = new ObservableCollection<Users>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Users.Clear();
                var items = await _UserDataService.GetDataAsync(Settings.BaseUrl + Settings.Users_Endpoint);
                foreach (var item in items.data)
                {
                    Users.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}