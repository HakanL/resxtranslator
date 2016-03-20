using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace ResxTranslator.Tools
{
    /// <summary>
    ///     Binding helper used for binding controls, variables and typed event handlers to custom Settings classes.
    ///     It is realized using generics and does not require any boxing or string literals.
    /// </summary>
    /// <typeparam name="TSettingClass">Type of your custom Settings class, it must inherit from ApplicationSettingsBase</typeparam>
    public class SettingBinder<TSettingClass>
        where TSettingClass : ApplicationSettingsBase
    {
        public delegate void SettingChangedEventHandler<TProperty>(
            object sender, SettingChangedEventArgs<TProperty> args);

        private readonly List<KeyValuePair<string, ISettingChangedHandlerEntry>> _eventEntries;

        /// <summary>
        ///     Create a new SettingBinder and hook into the specified class
        /// </summary>
        /// <param name="settingSet">Custom Settings class this binder is hooked into</param>
        public SettingBinder(TSettingClass settingSet)
        {
            if (settingSet == null)
                throw new ArgumentNullException(nameof(settingSet));

            _eventEntries = new List<KeyValuePair<string, ISettingChangedHandlerEntry>>();
            Settings = settingSet;
            Settings.PropertyChanged += PropertyChangedCallback;
        }

        /// <summary>
        ///     Custom Settings class this manager is hooked into
        /// </summary>
        public TSettingClass Settings { get; }

        /// <summary>
        ///     Control will update any changes to the settings store and receive updates to change accordingly.
        ///     Best to tag using the parent form.
        ///     Clicking the ToolStripMenuItem will automatically change it's Checked property.
        /// </summary>
        /// <param name="sourceControl">Control to bind the setting to</param>
        /// <param name="targetSetting">Lambda of style 'x => x.Property' or 'x => class.Property'</param>
        /// <param name="tag">Tag used for grouping</param>
        /// <exception cref="ArgumentException">Invalid lambda format</exception>
        public void BindControl(ToolStripMenuItem sourceControl, Expression<Func<TSettingClass, bool>> targetSetting,
            object tag)
        {
            Bind(x => sourceControl.Checked = x, () => sourceControl.Checked,
                eh => sourceControl.CheckedChanged += eh, eh => sourceControl.CheckedChanged -= eh,
                targetSetting, tag);

            sourceControl.Click += (x, y) => sourceControl.Checked = !sourceControl.Checked;
        }

        /// <summary>
        ///     Control will update any changes to the settings store and receive updates to change accordingly.
        ///     Best to tag using the parent form.
        /// </summary>
        /// <param name="sourceControl">Control to bind the setting to</param>
        /// <param name="targetSetting">Lambda of style 'x => x.Property' or 'x => class.Property'</param>
        /// <param name="tag">Tag used for grouping</param>
        /// <exception cref="ArgumentException">Invalid lambda format</exception>
        public void BindControl(TextBox sourceControl, Expression<Func<TSettingClass, string>> targetSetting, object tag)
        {
            Bind(x => sourceControl.Text = x, () => sourceControl.Text,
                eh => sourceControl.TextChanged += eh, eh => sourceControl.TextChanged -= eh,
                targetSetting, tag);
        }

        /// <summary>
        ///     Control will update any changes to the settings store and receive updates to change accordingly.
        ///     Best to tag using the parent form.
        /// </summary>
        /// <param name="sourceControl">Control to bind the setting to</param>
        /// <param name="targetSetting">Lambda of style 'x => x.Property' or 'x => class.Property'</param>
        /// <param name="tag">Tag used for grouping</param>
        /// <exception cref="ArgumentException">Invalid lambda format</exception>
        public void BindControl(CheckBox sourceControl, Expression<Func<TSettingClass, bool>> targetSetting, object tag)
        {
            Bind(x => sourceControl.Checked = x, () => sourceControl.Checked,
                eh => sourceControl.CheckedChanged += eh, eh => sourceControl.CheckedChanged -= eh,
                targetSetting, tag);
        }

        /// <summary>
        ///     Register event handler for the chosen property and tag it.
        /// </summary>
        /// <typeparam name="TProperty">Type of the property</typeparam>
        /// <param name="handler">Handler to register</param>
        /// <param name="targetProperty">Lambda of style 'x => x.Property' or 'x => class.Property'</param>
        /// <param name="tag">Tag used for grouping</param>
        public void Subscribe<TProperty>(SettingChangedEventHandler<TProperty> handler,
            Expression<Func<TSettingClass, TProperty>> targetProperty, object tag)
        {
            var name = Extensions.GetPropertyName(targetProperty);
            _eventEntries.Add(new KeyValuePair<string, ISettingChangedHandlerEntry>(name,
                new SettingChangedHandlerEntry<TProperty>(handler, tag)));
        }

        /// <summary>
        ///     Remove all handlers with the specified tag
        /// </summary>
        /// <param name="groupTag">Tag used by group to remove</param>
        public void RemoveHandlers(object groupTag)
        {
            _eventEntries.RemoveAll(pair => pair.Value.Tag.Equals(groupTag));
        }

        /// <summary>
        ///     Send property changed events to all registered handlers
        ///     Warning: Do not rely on this firing xyzChanged events as controls will fire them if their value doesn't actually
        ///     change.
        /// </summary>
        public void SendUpdates()
        {
            foreach (var entry in _eventEntries)
            {
                entry.Value.SendEvent(Settings[entry.Key]);
            }
        }

        /// <summary>
        ///     Send property changed events to the whole group.
        ///     Warning: Do not rely on this firing xyzChanged events as controls will fire them if their value doesn't actually
        ///     change.
        /// </summary>
        /// <param name="groupTag">Tag used by group to update</param>
        public void SendUpdates(object groupTag)
        {
            foreach (var entry in _eventEntries)
            {
                if (entry.Value.Tag != null && entry.Value.Tag.Equals(groupTag))
                {
                    entry.Value.SendEvent(Settings[entry.Key]);
                }
            }
        }

        /// <summary>
        ///     Manually bind to a setting
        /// </summary>
        /// <typeparam name="T">Bound value type</typeparam>
        /// <param name="setter">Delegate used to set value of the external property</param>
        /// <param name="getter">Delegate used to get value of the external property</param>
        /// <param name="registerEvent">Delegate used to register to the notifying event of the external property</param>
        /// <param name="unregisterEvent">Delegate used to unregister from the notifying event of the external property</param>
        /// <param name="targetSetting">Lambda of style 'x => x.Property' or 'x => class.Property'</param>
        /// <param name="tag">Tag used for grouping</param>
        public void Bind<T>(Action<T> setter, Func<T> getter,
            Action<EventHandler> registerEvent, Action<EventHandler> unregisterEvent,
            Expression<Func<TSettingClass, T>> targetSetting, object tag)
        {
            var memberSelectorExpression = targetSetting.Body as MemberExpression;
            if (memberSelectorExpression == null)
                throw new ArgumentException("Invalid lambda format", nameof(targetSetting));

            var property = memberSelectorExpression.Member as PropertyInfo;
            if (property == null)
                throw new ArgumentException("Invalid lambda format", nameof(targetSetting));

            EventHandler checkedChanged = (x, y) => { property.SetValue(Settings, getter(), null); };

            registerEvent(checkedChanged);

            SettingChangedEventHandler<T> settingChanged = (x, y) =>
            {
                var remoteValue = getter();
                if ((remoteValue != null && !remoteValue.Equals(y.NewValue))
                    || (remoteValue == null && y.NewValue != null))
                {
                    unregisterEvent(checkedChanged);
                    setter(y.NewValue);
                    registerEvent(checkedChanged);
                }
            };

            Subscribe(settingChanged, targetSetting, tag);
        }

        /// <summary>
        ///     Event handler registered to the custom Settings class
        /// </summary>
        private void PropertyChangedCallback(object sender, PropertyChangedEventArgs e)
        {
            foreach (var entry in _eventEntries)
            {
                if (entry.Key.Equals(e.PropertyName))
                {
                    entry.Value.SendEvent(Settings[e.PropertyName]);
                }
            }
        }

        private interface ISettingChangedHandlerEntry
        {
            object Tag { get; set; }
            void SendEvent(object value);
        }

        /// <summary>
        ///     This class contains the information required to send the event back to the subscriber
        /// </summary>
        private sealed class SettingChangedHandlerEntry<T> : ISettingChangedHandlerEntry
        {
            internal SettingChangedHandlerEntry(SettingChangedEventHandler<T> handler, object tag)
            {
                if (handler == null)
                    throw new ArgumentNullException(nameof(handler));
                if (tag == null)
                    throw new ArgumentNullException(nameof(tag));

                Handler = handler;
                Tag = tag;
            }

            private SettingChangedEventHandler<T> Handler { get; }
            public object Tag { get; set; }

            /// <summary>
            ///     Implemented explicitly to hide it from outside access
            /// </summary>
            void ISettingChangedHandlerEntry.SendEvent(object value)
            {
                Handler(this, new SettingChangedEventArgs<T>((T) value));
            }
        }
    }
}