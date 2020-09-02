using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFPlatform = Xamarin.Forms.Platform.Android.Platform;

namespace PrismPages.Droid.Extensions
{
    internal static class PlatformExtension
    {
        public static IVisualElementRenderer GetOrCreateRenderer(this VisualElement bindable, Android.Content.Context context)
        {
            var renderer = XFPlatform.GetRenderer(bindable);
            if (renderer == null)
            {
                renderer = XFPlatform.CreateRendererWithContext(bindable, context);
                XFPlatform.SetRenderer(bindable, renderer);
            }
            return renderer;
        }
    }
}