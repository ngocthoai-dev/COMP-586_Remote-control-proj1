using Core.Device;

namespace Core.Command
{
    internal class OnCommand
    {
        public static void Execute(IDevice? device)
        {
            device?.On();
        }
    }

    internal class OffCommand
    {
        public static void Execute(IDevice? device)
        {
            device?.Off();
        }
    }
}