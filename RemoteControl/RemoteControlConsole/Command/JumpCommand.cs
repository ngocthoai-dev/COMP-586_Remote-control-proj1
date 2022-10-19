using Core.Device;

namespace Core.Command
{
    internal class ChangeChannelCommand
    {
        public static void Execute(IDevice? device)
        {
            device?.ChangeChannel();
        }
    }
}