using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using currencies.Services;
using System.Diagnostics;

namespace currencies.ViewModel;

public partial class CurrenciesViewsModel : BaseViewModel
{
    CurService curService;
    public ObservableCollection<Currency> Cur { get; } = new();

    IConnectivity connectivity;

    [ObservableProperty]
    bool isRefreshing;


    public CurrenciesViewsModel(CurService curService, IConnectivity connectivity)
    {
        Title = "Currencies";
        this.curService = curService;
        this.connectivity = connectivity;
    }

    [RelayCommand]
    async Task GotoDetailsASync(Currency cur)
    {
        if (cur is null) return;

        await Shell.Current.GoToAsync($"{nameof(View.DetailsPage)}", true,
            new Dictionary<string, object>
            {
                {"Cur", cur }
            });
    }

    [RelayCommand]
    async Task GetEplAsync()
    {
        if (IsBusy) return;

        try
        {
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Internet Issue", $"Check Your Internet and Try Again", "OK");
                return;
            }
            IsBusy = true;
            var curs = await curService.GetCur();

            if (Cur.Count != 0)
                Cur.Clear();

            foreach (var cur in curs)
            {
                Cur.Add(cur);
            }


        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!", $"Unable to get Teams: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
            isRefreshing = false;
        }
    }

}