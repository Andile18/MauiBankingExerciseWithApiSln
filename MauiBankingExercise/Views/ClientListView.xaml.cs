using MauiBankingExercise.ViewModels;

namespace MauiBankingExercise.Views;

public partial class ClientListView : ContentPage
{
    public ClientListView()
    {
        InitializeComponent();
        BindingContext = new ClientListViewModel();
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();

    }
}