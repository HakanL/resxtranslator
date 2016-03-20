﻿using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace ResxTranslator
{
    public static class Extensions
    {
        public static void InvokeIfRequired<T>(this T c, Action<T> action) where T : Control
        {
            if (c.InvokeRequired)
                c.BeginInvoke(new Action(() => action(c)));
            else
                action(c);
        }

        /// <summary>
        ///     Get the name of a static or instance property from a property access lambda.
        /// </summary>
        /// <typeparam name="TProperty">Type of the property</typeparam>
        /// <typeparam name="TClass">Type of a class that contains the property</typeparam>
        /// <param name="memberLamda">You must pass a lambda formed like this 'x => x.Property' or this 'x => class.Property'</param>
        /// <returns>The name of the property</returns>
        public static string GetPropertyName<TProperty, TClass>(Expression<Func<TClass, TProperty>> memberLamda)
        {
            if (memberLamda == null)
                throw new ArgumentNullException(nameof(memberLamda));

            var memberSelectorExpression = memberLamda.Body as MemberExpression;

            if (memberSelectorExpression == null)
                throw new ArgumentException(
                    "You must pass a lambda of the form: 'x => x.Property' or 'x => class.Property'");

            return memberSelectorExpression.Member.Name;
        }
    }
}