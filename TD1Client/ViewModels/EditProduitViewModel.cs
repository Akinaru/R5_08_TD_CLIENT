using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TD1Client.Models;
using TD1Client.Services;

namespace TD1Client.ViewModels
{
    internal partial class EditProduitViewModel : ObservableObject
    {
        private readonly IService<Produit> _produitService;

        public EditProduitViewModel(IService<Produit> produitService)
        {
            _produitService = produitService;
        }

        [ObservableProperty]
        private string? _searchTerm;

        [ObservableProperty]
        private List<Produit> _produits = new List<Produit>();

        [ObservableProperty]
        private Produit? _selectedProduitForEdit;

        // Propriété pour stocker les résultats de la recherche
        [ObservableProperty]
        private List<Produit> _searchResults = new List<Produit>();

        // Propriété pour indiquer l'état de chargement
        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private string? _successMessage; // Message de succès

        public async Task LoadProduitsAsync()
        {
            IsLoading = true; // Indique que le chargement a commencé
            Produits = await _produitService.GetAllAsync();
            IsLoading = false; // Indique que le chargement est terminé
        }

        public async Task SearchProduit()
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
            {
                SearchResults = new List<Produit>(); // Réinitialiser si la recherche est vide
                SelectedProduitForEdit = null; // Réinitialiser la sélection
            }
            else
            {
                IsLoading = true; // Indique que le chargement a commencé

                // Appel à la méthode GetAllByNameAsync pour rechercher les produits via le service
                SearchResults = await _produitService.GetAllByNameAsync(SearchTerm);

                IsLoading = false; // Indique que le chargement est terminé

                // Si un seul produit correspond, le sélectionner automatiquement
                SelectedProduitForEdit = SearchResults.Count == 1 ? SearchResults.First() : null;
            }
        }

        public async Task UpdateProduitAsync()
        {
            if (SelectedProduitForEdit != null)
            {
                await _produitService.PutAsync(SelectedProduitForEdit.IdProduit, SelectedProduitForEdit);
            }
        }
    }
}
