using CommunityToolkit.Mvvm.ComponentModel;
using TD1Client.Models;
using TD1Client.Models.DTO;
using TD1Client.Services;

namespace TD1Client.ViewModels;

internal partial class ProduitViewModel : ObservableObject
{
    private readonly IService<ProduitDto> _produitService;

    public ProduitViewModel(IService<ProduitDto> produitService)
    {
        _produitService = produitService;
    }

    [ObservableProperty] private bool _isLoading;
    [ObservableProperty] private List<ProduitDto> _produits = new List<ProduitDto>(); 

    public async Task LoadDataAsync()
    {
        IsLoading = true;
        try
        {
            Produits = await _produitService.GetAllAsync();
        }
        finally
        {
            IsLoading = false;
        }
    }
}
