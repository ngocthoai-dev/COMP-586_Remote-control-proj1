using Core.Command;

namespace Core.Device
{
    internal class RemoteControl
    {
        public delegate void CommandDelegate(IDevice? device);

        private IDevice? _connectedDevice;

        private event CommandDelegate OnButton = OnCommand.Execute;
        private event CommandDelegate OffButton = OffCommand.Execute;
        private event CommandDelegate IncreseVolumeButton = IncreaseVolumeCommand.Execute;
        private event CommandDelegate DecreseVolumeButton = DecreaseVolumeCommand.Execute;
        private event CommandDelegate IncreseChannelButton = IncreaseChannelCommand.Execute;
        private event CommandDelegate DecreseChannelButton = DecreaseChannelCommand.Execute;
        private event CommandDelegate ChangeChannelButton = ChangeChannelCommand.Execute;
        private event CommandDelegate MuteButton = MuteCommand.Execute;
        private event CommandDelegate SettingButton = OpenSettingCommand.Execute;
        private event CommandDelegate SmartMenuButton = OpenSmartMenuCommand.Execute;

        private readonly CommandDelegate[] _commands;

        public RemoteControl()
        {
            _commands = new CommandDelegate[] { OnButton, OffButton, IncreseVolumeButton, DecreseVolumeButton, IncreseChannelButton, DecreseChannelButton,
            ChangeChannelButton, MuteButton, SettingButton, SmartMenuButton};
        }

        public void ConnectDevice(IDevice? device)
        {
            _connectedDevice = device;
        }

        public void PressButton(int cmdIndex)
        {
            _commands[cmdIndex].Invoke(_connectedDevice);
        }
    }
}