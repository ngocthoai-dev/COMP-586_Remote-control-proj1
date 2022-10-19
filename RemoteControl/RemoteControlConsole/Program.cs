// See https://aka.ms/new-console-template for more information

using Core.Device;

namespace Core
{
    public enum MainMenuOption
    {
        On = 0,
        Off,
        Increase_Volume,
        Decrease_Volume,
        Increase_Channel,
        Decrease_Channel,
        Change_Channel,
        Mute,
        Setting,
        Smart_Menu,
        Change_TV,
        Exit
    }

    public class Program
    {
        private static readonly RemoteControl _remoteControl = new();

        private static void ChangeDevice()
        {
            Console.Clear();
            string[] options = Enum.GetNames<DeviceType>();
            Console.WriteLine("Select TV");
            for (int idx = 0; idx < options.Length; idx++)
                Console.WriteLine($"{idx + 1}. {options[idx]}");

            Console.WriteLine("=============================");

            var str = Console.ReadLine();
            int option;
            while (!int.TryParse(str, out option) || option - 1 < 0 || option - 1 >= options.Length)
            {
                Console.WriteLine("Invalid Option!");
                str = Console.ReadLine();
            }

            _remoteControl.ConnectDevice(BaseTVDevice.DeviceTypeMap[(DeviceType)(option - 1)]);
            OpenMainMenu();
        }

        public static void OpenMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Remote Control CLI");
            string[] options = Enum.GetNames<MainMenuOption>();
            for (int idx = 0; idx < options.Length; idx++)
                Console.WriteLine($"{idx + 1}. {string.Join(" ", options[idx].Split("_"))}");

            Console.WriteLine("=============================");

            var str = Console.ReadLine();
            int option;
            while (!int.TryParse(str, out option) || option - 1 < 0 || option - 1 >= options.Length)
            {
                Console.WriteLine("Invalid Option!");
                str = Console.ReadLine();
            }

            if (option == options.Length) return;

            if (option == options.Length - 1) ChangeDevice();
            else _remoteControl.PressButton(option - 1);
        }

        public static void Main(string[] args)
        {
            _remoteControl.ConnectDevice(new TV_43U7000());
            OpenMainMenu();
        }
    }
}