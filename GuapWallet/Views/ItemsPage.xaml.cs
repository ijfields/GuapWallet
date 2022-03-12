using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GuapWallet.Models;
using GuapWallet.Views;
using GuapWallet.ViewModels;

namespace GuapWallet.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
       // ItemsViewModel viewModel;

      /*  public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }*/

        public Transaction Transaction { get; set; }

        public ItemsPage()
        {
            InitializeComponent();
            Transaction = new Transaction
            {
                PrivateKey = "",
                Sender = "",
            };
            BindingContext = this;
        }
        // was task changed to void
        async void  Save_Clicked(object sender, EventArgs e)
        {
            Credentials.PublicKey = Transaction.Sender;
            Credentials.Privatekey = Transaction.PrivateKey;

            await DisplayAlert("Credentials", "Key Updated", "OK");
        }

        async void CreateSign_Clicked(object sender, EventArgs e)

        {
                await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
            }
        //{
        //    InitializeComponent()
        //}

       /* async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }*/
    }
}