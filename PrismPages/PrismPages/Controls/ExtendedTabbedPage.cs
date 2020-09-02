using Xamarin.Forms;

namespace PrismPages.Controls
{
    public class ExtendedTabbedPage : Xamarin.Forms.TabbedPage
    {
        public static readonly BindableProperty TabHeaderContentProperty
            = BindableProperty.Create(nameof(TabHeaderContent), typeof(View), typeof(ExtendedTabbedPage), null, propertyChanged: OnContentChanged);

        public View TabHeaderContent
        {
            get { return (View)GetValue(TabHeaderContentProperty); }
            set { SetValue(TabHeaderContentProperty, value); }
        }

        private static void OnContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var self = (ExtendedTabbedPage)bindable;
            var newElement = (Element)newValue;
            //if (self.ControlTemplate == null)
            //{
            //    while (self.InternalChildren.Count > 0)
            //    {
            //        self.InternalChildren.RemoveAt(self.InternalChildren.Count - 1);
            //    }

            //    if (newValue != null)
            //        self.InternalChildren.Add(newElement);
            //}
            //else
            //{
            //    if (newElement != null)
            //    {
            //        BindableObject.SetInheritedBindingContext(newElement, bindable.BindingContext);
            //    }

            //}

        }
    }
}
