using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace wavPlayer.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<NavigationItem> NavigationItems { get; }

    [ObservableProperty]
    private NavigationItem? _selectedNavigationItem;

    [ObservableProperty]
    private ObservableObject? _currentPage;

    public MainViewModel()
    {
        NavigationItems = new()
        {
            new NavigationItem("主页", "Home", "Home", new HomeViewModel()),
        };

        // 默认选中第一项
        _selectedNavigationItem = NavigationItems[0];
        _currentPage = _selectedNavigationItem.PageViewModel;
    }

    partial void OnSelectedNavigationItemChanged(NavigationItem? value)
    {
        if (value is not null)
            CurrentPage = value.PageViewModel;
    }
}

public record NavigationItem(string Title, string Tag, string Icon, ObservableObject PageViewModel);