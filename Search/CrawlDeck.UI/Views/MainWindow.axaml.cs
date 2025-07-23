using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CrawlDeck.UI.CustomControls;

namespace CrawlDeck.UI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void ToggleSidebar_Click(object? sender, RoutedEventArgs e)
    {
        var sidebar = this.FindControl<SideBar>("MainSideBar");
        sidebar?.Toggle();
    }
}