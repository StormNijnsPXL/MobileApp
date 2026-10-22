namespace Demo.Models.SkiaSharp;
public class OutlinedLabel : Grid
{
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(OutlinedLabel),
            string.Empty,
            propertyChanged: OnPropertyChanged);

    public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(
            nameof(TextColor),
            typeof(Color),
            typeof(OutlinedLabel),
            Colors.White,
            propertyChanged: OnPropertyChanged);

    public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create(
            nameof(FontSize),
            typeof(double),
            typeof(OutlinedLabel),
            28.0,
            propertyChanged: OnPropertyChanged);

    public static readonly BindableProperty FontFamilyProperty =
        BindableProperty.Create(
            nameof(FontFamily),
            typeof(string),
            typeof(OutlinedLabel),
            null,
            propertyChanged: OnPropertyChanged);

    public static readonly BindableProperty OutlineWidthProperty =
        BindableProperty.Create(
            nameof(OutlineWidth),
            typeof(double),
            typeof(OutlinedLabel),
            1.0,
            propertyChanged: OnPropertyChanged);

    public static readonly BindableProperty FontAttributesProperty =
        BindableProperty.Create(
            nameof(FontAttributes),
            typeof(FontAttributes),
            typeof(OutlinedLabel),
            FontAttributes.None,
            propertyChanged: OnPropertyChanged);
    public static readonly BindableProperty FontAutoScalingEnabledProperty =
    BindableProperty.Create(
        nameof(FontAutoScalingEnabled),
        typeof(bool),
        typeof(OutlinedLabel),
        true,
        propertyChanged: OnPropertyChanged);

    public static readonly BindableProperty HorizontalTextAlignmentProperty =
        BindableProperty.Create(
            nameof(HorizontalTextAlignment),
            typeof(TextAlignment),
            typeof(OutlinedLabel),
            TextAlignment.Start,
            propertyChanged: OnPropertyChanged);

    public static readonly BindableProperty VerticalTextAlignmentProperty =
        BindableProperty.Create(
            nameof(VerticalTextAlignment),
            typeof(TextAlignment),
            typeof(OutlinedLabel),
            TextAlignment.Center,
            propertyChanged: OnPropertyChanged);

    public static readonly BindableProperty LineBreakModeProperty =
        BindableProperty.Create(
            nameof(LineBreakMode),
            typeof(LineBreakMode),
            typeof(OutlinedLabel),
            LineBreakMode.WordWrap,
            propertyChanged: OnPropertyChanged);
    public static readonly BindableProperty OutlineColorProperty =
    BindableProperty.Create(
        nameof(OutlineColor),
        typeof(Color),
        typeof(OutlinedLabel),
        Colors.Black,
        propertyChanged: OnPropertyChanged);
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public double FontSize
    {
        get => (double)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public string? FontFamily
    {
        get => (string?)GetValue(FontFamilyProperty);
        set => SetValue(FontFamilyProperty, value);
    }

    public double OutlineWidth
    {
        get => (double)GetValue(OutlineWidthProperty);
        set => SetValue(OutlineWidthProperty, value);
    }

    public FontAttributes FontAttributes
    {
        get => (FontAttributes)GetValue(FontAttributesProperty);
        set => SetValue(FontAttributesProperty, value);
    }
    public bool FontAutoScalingEnabled
    {
        get => (bool)GetValue(FontAutoScalingEnabledProperty);
        set => SetValue(FontAutoScalingEnabledProperty, value);
    }

    public TextAlignment HorizontalTextAlignment
    {
        get => (TextAlignment)GetValue(HorizontalTextAlignmentProperty);
        set => SetValue(HorizontalTextAlignmentProperty, value);
    }

    public TextAlignment VerticalTextAlignment
    {
        get => (TextAlignment)GetValue(VerticalTextAlignmentProperty);
        set => SetValue(VerticalTextAlignmentProperty, value);
    }

    public LineBreakMode LineBreakMode
    {
        get => (LineBreakMode)GetValue(LineBreakModeProperty);
        set => SetValue(LineBreakModeProperty, value);
    }
    public Color OutlineColor
    {
        get => (Color)GetValue(OutlineColorProperty);
        set => SetValue(OutlineColorProperty, value);
    }
    public OutlinedLabel()
    {
        UpdateLabels();
    }

    private static void OnPropertyChanged(
        BindableObject bindable,
        object oldValue,
        object newValue)
    {
        ((OutlinedLabel)bindable).UpdateLabels();
    }

    private void UpdateLabels()
    {
        Children.Clear();

        void AddLabel(Color color, double x, double y)
        {
            var label = new Label
            {
                Text = Text,
                TextColor = color,
                FontSize = FontSize,
                FontFamily = FontFamily ?? "Pixelon",
                FontAttributes = FontAttributes,

                FontAutoScalingEnabled = FontAutoScalingEnabled,
                HorizontalTextAlignment = HorizontalTextAlignment,
                VerticalTextAlignment = VerticalTextAlignment,
                LineBreakMode = LineBreakMode,

                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TranslationX = x * OutlineWidth,
                TranslationY = y * OutlineWidth
            };

            Children.Add(label);
        }

        AddLabel(OutlineColor, -1, 0);
        AddLabel(OutlineColor, 1, 0);
        AddLabel(OutlineColor, 0, -1);
        AddLabel(OutlineColor, 0, 1);

        AddLabel(TextColor, 0, 0);
    }
}
