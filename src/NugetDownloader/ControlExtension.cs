using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace NugetDownloader
{
    public static class ControlExtension
    {
        private delegate void SetPropertyValueHandler<T, TResult>(T souce, Expression<Func<T, TResult>> selector, TResult value) where T : Control;

        public static void SetPropertyValue<T, TResult>(this T source, Expression<Func<T, TResult>> selector, TResult value) where T : Control
        {
            if (source.InvokeRequired)
            {
                var del = new SetPropertyValueHandler<T, TResult>(SetPropertyValue);
                source.Invoke(del, source, selector, value);
            }
            else
            {
                var propInfo = ((MemberExpression)selector.Body).Member as PropertyInfo;
                propInfo?.SetValue(source, value, null);
            }
        }
    }
}
