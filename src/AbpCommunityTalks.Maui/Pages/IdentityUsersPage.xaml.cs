using AbpCommunityTalks.Maui.ViewModels;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace AbpCommunityTalks.Maui.Pages;

public partial class IdentityUsersPage : ContentPage, ITransientDependency
{
    public IdentityUsersPageViewModel ViewModel { get; set; }
    public IdentityUsersPage(IdentityUsersPageViewModel viewModel)
    {
        ViewModel = viewModel;
        InitializeComponent();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (!await DisplayAlert("Deleting User", "Are you sure to delete this user?", "Yes", "Cancel"))
        {
            return;
        }

        if (sender is MenuItem menuItem)
        {
            await ViewModel.DeleteUserAsync(menuItem.CommandParameter as IdentityUserDto);
        }
    }
}