using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF_HW2.AttachedProperties
{
    public class CheckNullAttProperty
    {
        #region CheckNull 附加屬性 Attached Property，若設定為 True，則會檢查 Entry 的 Text 屬性是否為空白，若為空白，則會自動設定 Text 的值為 0
        public static readonly BindableProperty CheckNullProperty =
           BindableProperty.CreateAttached(
               propertyName: "CheckNull",   // 屬性名稱 
               returnType: typeof(bool), // 回傳類型 
               declaringType: typeof(CheckNullAttProperty), // 宣告類型 
               defaultValue: false, // 預設值 
               propertyChanged: OnCheckNullChanged  // 屬性值異動時，要執行的事件委派方法
           );

        public static void SetCheckNull(BindableObject bindable, bool entryType)
        {
            bindable.SetValue(CheckNullProperty, entryType);
        }
        public static bool GetCheckNull(BindableObject bindable)
        {
            return (bool)bindable.GetValue(CheckNullProperty);
        }

        private static void OnCheckNullChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var fooEntry = bindable as Entry;
            if (fooEntry == null)
            {
                return;
            }

            var fooValue = (bool)newValue;

            if (fooValue == true)
            {
                //若該 Entry 有加入此附加屬性，必且設定為 True，則綁定這個 Entry 的 TextChanged 的事件
                fooEntry.TextChanged += EntryTextChangedEvent;
            }
            else
            {
                fooEntry.TextChanged -= EntryTextChangedEvent;
            }
        }

        private static void EntryTextChangedEvent(object sender, TextChangedEventArgs e)
        {
            var fooEntry = sender as Entry;
            if (string.IsNullOrEmpty(fooEntry.Text))
            {
                //當 Text 內容有異動時候，這個事件會被呼叫，且當 Text 值為空白的時候，強制設定其值為 0
                fooEntry.Text = "0";
            }
        }
        #endregion
    }
}
