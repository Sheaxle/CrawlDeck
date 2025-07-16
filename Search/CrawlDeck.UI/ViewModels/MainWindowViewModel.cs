using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace CrawlDeck.UI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private bool _isContentVisible;
    public bool IsContentVisible
    {
        get => _isContentVisible;
        set => SetProperty(ref _isContentVisible, value);
    }
    public ICommand ChangeVisibleCommand { get; set; }

    public MainWindowViewModel()
    {
        ChangeVisibleCommand = new RelayCommand(ChangeVisible);
    }

    private void ChangeVisible() => IsContentVisible = !IsContentVisible;
    
}