using Demo.Models.SkiaSharp;
using System.Diagnostics;

namespace Demo.Pages;

public partial class GameView : ContentView
{
    private static Border[] targets;
    private Border? highlightedTarget;
    public GameView()
    {
        InitializeComponent();
        targets = [Slot1, Slot2, Slot3, Slot4];
    }

    private void SetTargetImage(Border target, string image)
    {
        if (target.Content is PixelArt pixelArt)
        {
            pixelArt.ImageName = image;
        }
    }
    private async void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        if (sender is not View card)
            return;

        switch (e.StatusType)
        {
            case GestureStatus.Started:
                Debug.WriteLine("started dragging");
                break;

            case GestureStatus.Running:
                card.TranslationX = e.TotalX;
                card.TranslationY = e.TotalY;

                UpdateHover(card);
                break;

            case GestureStatus.Completed:

                View? result = CheckDropTarget(card);

                if (result == null)
                {
                    // Place card
                }
                await ReturnCard(card);

                if (highlightedTarget != null)
                {
                    SetTargetImage(highlightedTarget, "UI/cardRed.png");
                    highlightedTarget = null;
                }

                break;
            case GestureStatus.Canceled:
                card.TranslationX = 0;
                card.TranslationY = 0;
                break;
        }
    }
    private async Task ReturnCard(View card)
    {
        await Task.WhenAll(card.TranslateToAsync(0, 0, 200, Easing.CubicOut));
    }
    private void UpdateHover(View card)
    {
        Border? currentTarget = CheckDropTarget(card) as Border;
        if (currentTarget == highlightedTarget)
            return;

        if (highlightedTarget != null)
            SetTargetImage(highlightedTarget, "UI/cardRed.png");
        
        highlightedTarget = currentTarget;

        if (highlightedTarget != null)
            SetTargetImage(highlightedTarget, "UI/cardSpecial.png");
        
    }
    private Point GetPositionRelativeToRoot(VisualElement element)
    {
        double x = 0;
        double y = 0;

        Element? current = element;

        while (current is VisualElement view && current != this)
        {
            x += view.X + view.TranslationX;
            y += view.Y + view.TranslationY;

            current = view.Parent;
        }

        return new Point(x, y);
    }
    private bool IsOverlapping(VisualElement a, VisualElement b)
    {
        Point posA = GetPositionRelativeToRoot(a);
        Point posB = GetPositionRelativeToRoot(b);

        Rect rectA = new Rect(
            posA.X,
            posA.Y,
            a.Width,
            a.Height
        );

        Rect rectB = new Rect(
            posB.X,
            posB.Y,
            b.Width,
            b.Height
        );

        return rectA.IntersectsWith(rectB);
    }
    private View? CheckDropTarget(View card)
    {
        foreach (var target in targets)
        {
            if (IsOverlapping(card, target))
                return target;
        }

        return null;
    }
}