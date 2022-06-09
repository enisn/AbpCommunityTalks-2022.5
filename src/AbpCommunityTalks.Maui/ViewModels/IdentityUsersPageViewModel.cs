using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace AbpCommunityTalks.Maui.ViewModels;
public class IdentityUsersPageViewModel : BindableObject, ITransientDependency
{
    protected IIdentityUserAppService IdentityUserAppService { get; }

    public GetIdentityUsersInput Input { get; } = new();

    public ObservableCollection<IdentityUserDto> Items { get; } = new();

    public Command RefreshCommand { get; }

    private bool isBusy;
    public bool IsBusy { get => isBusy; set => SetProperty(ref isBusy, value); }

    public IdentityUsersPageViewModel(IIdentityUserAppService identityUserAppService)
    {
        IdentityUserAppService = identityUserAppService;
        GetUsersAsync();
        RefreshCommand = new Command(GetUsersAsync);
    }

    protected async void GetUsersAsync()
    {
        if (IsBusy)
        {
            return; // For preventing parallel request while searching.
        }

        IsBusy = true;

        Items.Clear();

        var result = await IdentityUserAppService.GetListAsync(Input);
        foreach (var user in result.Items)
        {
            Items.Add(user);
        }

        IsBusy = false;
    }

    internal async Task DeleteUserAsync(IdentityUserDto user)
    {
        await IdentityUserAppService.DeleteAsync(user.Id);
        Items.Remove(user);
    }

    protected void SetProperty<T>(ref T backField, T value, [CallerMemberName] string propertyName = null)
    {
        backField = value;
        OnPropertyChanged(propertyName);
    }
}

