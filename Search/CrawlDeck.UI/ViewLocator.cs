using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using CrawlDeck.UI.ViewModels;

namespace CrawlDeck.UI;

internal sealed class ViewLocator : IDataTemplate
{
    #region Public Methods

    public Control? Build(object? data)
    {
        if (data is null) 
            return null;

        var name = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
        var type = Type.GetType(name);

        if (type != null) 
            return (Control)Activator.CreateInstance(type)!;
        
        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object? data) => data is ViewModelBase;

    #endregion
}