using Core.Device;

namespace Core.Command
{
    internal class MuteCommand
    {
        public static void Execute(IDevice? device)
        {
            device?.Mute();
        }
    }

    internal class OpenSettingCommand
    {
        public static void Execute(IDevice? device)
        {
            device?.OpenSetting();
        }
    }

    internal class OpenSmartMenuCommand
    {
        public static void Execute(IDevice? device)
        {
            device?.OpenSmartMenu();
        }
    }
}