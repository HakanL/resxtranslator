using ResxTranslator.Tools;

namespace ResxTranslator.Properties
{
    internal sealed partial class Settings
    {
        static Settings()
        {
            Binder = new SettingBinder<Settings>(Default);
        }

        public static SettingBinder<Settings> Binder { get; }
    }
}
