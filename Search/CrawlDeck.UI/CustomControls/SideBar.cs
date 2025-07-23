using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CrawlDeck.UI.CustomControls;

[TemplatePart("PART_Header", typeof(ContentControl))]
[TemplatePart("PART_ItemsPresenter", typeof(ItemsControl))]
[TemplatePart("PART_Footer", typeof(ContentControl))]
public class SideBar : TemplatedControl
{
    #region Style Proeprties

    #region Is Expanded

    public static readonly StyledProperty<bool> IsExpandedProperty =
        AvaloniaProperty.Register<SideBar, bool>(nameof(IsExpanded), true);

    public bool IsExpanded
    {
        get => GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }

    #endregion

    #region Collapsed Width

    public static readonly StyledProperty<double> CollapsedWidthProperty =
        AvaloniaProperty.Register<SideBar, double>(nameof(CollapsedWidth), 48);

    public double CollapsedWidth
    {
        get => GetValue(CollapsedWidthProperty);
        set => SetValue(CollapsedWidthProperty, value);
    }
    
    #endregion

    #region Expanded Width

    public static readonly StyledProperty<double> ExpandedWidthProperty =
        AvaloniaProperty.Register<SideBar, double>(nameof(ExpandedWidth), 250);

    public double ExpandedWidth
    {
        get => GetValue(ExpandedWidthProperty);
        set => SetValue(ExpandedWidthProperty, value);
    }
    
    #endregion

    #region Header

    public static readonly StyledProperty<object?> HeaderProperty =
        AvaloniaProperty.Register<SideBar, object?>(nameof(Header));
    
    public object? Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    #endregion

    #region Header Template

    public static readonly StyledProperty<IDataTemplate?> HeaderTemplateProperty =
        AvaloniaProperty.Register<SideBar, IDataTemplate?>(nameof(HeaderTemplate));
    
    public IDataTemplate? HeaderTemplate
    {
        get => GetValue(HeaderTemplateProperty);
        set => SetValue(HeaderTemplateProperty, value);
    }

    #endregion

    #region Footer

    public static readonly StyledProperty<object?> FooterProperty =
        AvaloniaProperty.Register<SideBar, object?>(nameof(Footer));
    
    public object? Footer
    {
        get => GetValue(FooterProperty);
        set => SetValue(FooterProperty, value);
    }

    #endregion

    #region Footer Template

    public static readonly StyledProperty<IDataTemplate?> FooterTemplateProperty =
        AvaloniaProperty.Register<SideBar, IDataTemplate?>(nameof(FooterTemplate));
    
    public IDataTemplate? FooterTemplate
    {
        get => GetValue(FooterTemplateProperty);
        set => SetValue(FooterTemplateProperty, value);
    }

    #endregion

    #region MyRegion

    

    #endregion

    #endregion

    public static readonly StyledProperty<ObservableCollection<object>?> ItemsProperty =
        AvaloniaProperty.Register<SideBar, ObservableCollection<object>?>(nameof(Items));

    public static readonly StyledProperty<IDataTemplate?> ItemTemplateProperty =
        AvaloniaProperty.Register<SideBar, IDataTemplate?>(nameof(ItemTemplate));

    public static readonly StyledProperty<ICommand?> ToggleCommandProperty =
        AvaloniaProperty.Register<SideBar, ICommand?>(nameof(ToggleCommand));

    static SideBar()
    {
        IsExpandedProperty.Changed.AddClassHandler<SideBar>((x, e) => x.OnIsExpandedChanged(e));
    }

    public SideBar()
    {
        Items = new ObservableCollection<object>();
        UpdatePseudoClasses();
    }

    [Content]
    public ObservableCollection<object>? Items
    {
        get => GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    public IDataTemplate? ItemTemplate
    {
        get => GetValue(ItemTemplateProperty);
        set => SetValue(ItemTemplateProperty, value);
    }

    public ICommand? ToggleCommand
    {
        get => GetValue(ToggleCommandProperty);
        set => SetValue(ToggleCommandProperty, value);
    }

    public void Toggle()
    {
        IsExpanded = !IsExpanded;
        ToggleCommand?.Execute(IsExpanded);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        UpdatePseudoClasses();
    }

    private void OnIsExpandedChanged(AvaloniaPropertyChangedEventArgs e)
    {
        UpdatePseudoClasses();
    }

    private void UpdatePseudoClasses()
    {
        PseudoClasses.Set(":expanded", IsExpanded);
        PseudoClasses.Set(":collapsed", !IsExpanded);
    }
}