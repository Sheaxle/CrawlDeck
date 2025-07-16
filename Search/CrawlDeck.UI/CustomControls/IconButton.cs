using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;

namespace CrawlDeck.UI.CustomControls;

[PseudoClasses(":content-visible", ":content-hidden")]
public class IconButton : Button
{
    #region Styled Properties

    #region Icon

    public static readonly StyledProperty<string?> IconProperty =
        AvaloniaProperty.Register<IconButton, string?>(nameof(Icon));
    
    public string? Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    #endregion

    #region Is Content Visible

    public static readonly StyledProperty<bool> IsContentVisibleProperty =
        AvaloniaProperty.Register<IconButton, bool>(nameof(IsContentVisible), true);
    
    public bool IsContentVisible
    {
        get => GetValue(IsContentVisibleProperty);
        set => SetValue(IsContentVisibleProperty, value);
    }

    #endregion

    #endregion

    #region Core

    static IconButton()
    {
        IsContentVisibleProperty.Changed.AddClassHandler<IconButton>((x, e) => x.UpdatePseudoClasses());
    }

    #endregion

    #region Methods

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        UpdatePseudoClasses();
    }

    private void UpdatePseudoClasses()
    {
        PseudoClasses.Set(":content-visible", IsContentVisible);
        PseudoClasses.Set(":content-hidden", !IsContentVisible);
    }

    #endregion
}