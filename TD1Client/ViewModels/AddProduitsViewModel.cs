using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TD1Client.Models;
using TD1Client.Services;

namespace TD1Client.ViewModels
{
    internal partial class AddProduitsViewModel : ObservableObject
    {
        private readonly IService<Produit> _produitService;

        public AddProduitsViewModel(IService<Produit> produitService)
        {
            _produitService = produitService;
            NewProduit = new Produit(); // Initialiser le produit à ajouter
        }

        [ObservableProperty]
        private Produit newProduit;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private string? successMessage;

        [ObservableProperty]
        private string? errorMessage;

        // Commande pour soumettre le produit
        [RelayCommand]
        public async Task SubmitProduitAsync()
        {
            IsLoading = true;
            try
            {
                await _produitService.PostAsync(NewProduit);
                SuccessMessage = "Produit ajouté avec succès !";
                ErrorMessage = null;
                NewProduit = new Produit(); // Réinitialiser le produit après l'ajout
            }
            catch (Exception ex)
            {
                ErrorMessage = "Erreur lors de l'ajout du produit : " + ex.Message;
                SuccessMessage = null;
            }
            finally
            {
                IsLoading = false;
            }
        }

    }
}
