using App10.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace App10.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}