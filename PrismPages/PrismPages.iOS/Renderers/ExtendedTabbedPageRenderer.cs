using CoreGraphics;
using PrismPages.iOS.Renderers;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(ExtendedTabbedPageRenderer))]
namespace PrismPages.iOS.Renderers
{
    public class ExtendedTabbedPageRenderer : TabbedRenderer
    {
        UIButton _playButton;
        UIView _playerBar;
        Page Page => Element as Page;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                SetupUserInterface();
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine($"\t\t\tERROR: {exception.Message}");
            }
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            if (Element == null)
                return;

            if (Element.Parent is BaseShellItem)
                Element.Layout(View.Bounds.ToRectangle());

            if (!Element.Bounds.IsEmpty)
            {
                View.Frame = new System.Drawing.RectangleF((float)Element.X, (float)Element.Y, (float)Element.Width, (float)Element.Height);
            }

            var frame = View.Frame;
            var playerFrame = _playerBar.Frame;
            var tabBarFrame = TabBar.Frame;
            Page.ContainerArea = new Rectangle(0, 0, frame.Width, frame.Height - playerFrame.Height - tabBarFrame.Height);
            
        }

        private void SetupUserInterface()
        {
            var frame = View.Frame;
            var tabBarFrame = TabBar.Frame;
            
            var topButtonY = View.Bounds.Bottom -50;
            var topLeftX = View.Bounds.X + 25;
            


            _playerBar = new UIView()
            {
                Frame = new CGRect(frame.Left, 0, frame.Width, 50)
            };

            _playButton = new UIButton()
            {
                Frame = new CGRect(topLeftX, topButtonY, 37, 37)
            };
            _playButton.SetBackgroundImage(UIImage.FromFile("NoFlashButton.png"), UIControlState.Normal);

            _playerBar.Add(_playButton);
            View.Add(_playerBar);
        }
    }
}