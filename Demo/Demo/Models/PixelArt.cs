using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using System.Diagnostics;

namespace Demo.Controls;
public class PixelArt : SKCanvasView
{
    public static readonly BindableProperty ImageNameProperty =
        BindableProperty.Create(
            nameof(ImageName),
            typeof(string),
            typeof(PixelArt),
            default(string),
            propertyChanged: OnImageNameChanged);
    private SKBitmap? bitmap;
    public string? ImageName
    {
        get => (string?)GetValue(ImageNameProperty);
        set => SetValue(ImageNameProperty, value);
    }
    public PixelArt()
    {
        PaintSurface += OnPaintSurface;
    }
    private static async void OnImageNameChanged(
        BindableObject bindable,
        object oldValue,
        object newValue)
    {
        var view = (PixelArt)bindable;
        await view.LoadImageAsync(newValue as string);
    }
    private async Task LoadImageAsync(string? imageName)
    {
        var oldBitmap = bitmap;
        bitmap = null;
        oldBitmap?.Dispose();
        InvalidateSurface();

        if (string.IsNullOrWhiteSpace(imageName))
            return;

        try
        {
            await using var stream =
                await FileSystem.OpenAppPackageFileAsync(imageName);

            var loadedBitmap = SKBitmap.Decode(stream);

            if (ImageName != imageName)
            {
                loadedBitmap?.Dispose();
                return;
            }

            bitmap = loadedBitmap;
            InvalidateSurface();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Pixel art loading failed: {ex.Message}");
        }
    }

    private void OnPaintSurface(
        object? sender,
        SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;
        canvas.Clear(SKColors.Transparent);

        if (bitmap is null)
            return;

        canvas.DrawBitmap(
            bitmap,
            new SKRect(0, 0, e.Info.Width, e.Info.Height),
            new SKSamplingOptions(
                SKFilterMode.Nearest,
                SKMipmapMode.None));
    }

    protected override void OnHandlerChanging(
        HandlerChangingEventArgs args)
    {
        if (args.NewHandler is null)
        {
            bitmap?.Dispose();
            bitmap = null;
        }

        base.OnHandlerChanging(args);
    }
}
