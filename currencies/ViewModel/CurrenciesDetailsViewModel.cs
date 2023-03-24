using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using currencies.ViewModel;
using currencies.Model;

namespace currencies.ViewModel;

[QueryProperty("Cur", "cur")]

public partial class CurrenciesDetailsViewModel : BaseViewModel
{
    public CurrenciesDetailsViewModel()
    {

    }

    [ObservableProperty]
    Cur cur;

    [RelayCommand]
    async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
}