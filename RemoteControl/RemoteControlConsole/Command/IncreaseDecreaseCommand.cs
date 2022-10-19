using Core.Device;

namespace Core.Command
{
    internal class IncreaseVolumeCommand
    {
        public static void Execute(IDevice? device)
        {
            device?.IncreaseVolume();
        }
    }

    internal class DecreaseVolumeCommand
    {
        public static void Execute(IDevice? device)
        {
            device?.DecreaseVolume();
        }
    }

    internal class IncreaseChannelCommand
    {
        public static void Execute(IDevice? device)
        {
            device?.IncreaseChannel();
        }
    }

    internal class DecreaseChannelCommand
    {
        public static void Execute(IDevice? device)
        {
            device?.DecreaseChannel();
        }
    }
}