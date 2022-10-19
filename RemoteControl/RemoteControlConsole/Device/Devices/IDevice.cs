using Core.Utility;

namespace Core.Device
{
    public enum DeviceType
    {
        TV_43U7000 = 0,
        TV_50U7000,
        TV_55U7000,
        TV_58U7000,
        TV_65U7000,
        TV_70U7000,
        TV_75U7000
    }

    internal interface IDevice
    {
        void On();
        void Off();

        void IncreaseVolume();
        void DecreaseVolume();

        void IncreaseChannel();
        void DecreaseChannel();
        void ChangeChannel();

        void Mute();

        void OpenSetting();
        void OpenSmartMenu();
    }

    internal class BaseTVDevice : IDevice
    {
        protected readonly int _minVolume = 0;
        protected readonly int _maxVolume = 100;
        protected readonly int _minChannel = 0;
        protected readonly int _maxChannel = 100;

        protected string _deviceID = "";

        protected bool _isOn = false;
        protected bool _isMute = false;
        protected int _beforeMuteVolume = 50;
        protected int _volume = 50;
        protected int _channel = 1;

        protected bool _isOpenSetting = false;
        protected bool _isOpemSmartMenu = false;

        public static Dictionary<DeviceType, IDevice> DeviceTypeMap = new(){
            { DeviceType.TV_43U7000, new TV_43U7000() },
            { DeviceType.TV_50U7000, new TV_50U7000() },
            { DeviceType.TV_55U7000, new TV_55U7000() },
            { DeviceType.TV_58U7000, new TV_58U7000() },
            { DeviceType.TV_65U7000, new TV_65U7000() },
            { DeviceType.TV_70U7000, new TV_70U7000() },
            { DeviceType.TV_75U7000, new TV_75U7000() }
        };

        protected TU7000_Spec[] _TV_U7000s = Array.Empty<TU7000_Spec>();

        private async void AsyncConstructor()
        {
            _deviceID = GetType().Name;
            _TV_U7000s = await FileReaderUtil.Read<TU7000_Spec[]>(ConfigFileName.GetFileName<TU7000_Spec>());
        }

        public BaseTVDevice()
        {
            AsyncConstructor();
        }

        protected static void LogReturn()
        {
            Console.WriteLine("Press Enter To Return");
            Console.ReadLine();
            Program.OpenMainMenu();
        }

        public virtual void On()
        {
            _isOn = true;
            Console.Clear();
            Console.WriteLine($"TV on: {_isOn}");
            LogReturn();
        }

        public virtual void Off()
        {
            _isOn = false;
            Console.Clear();
            Console.WriteLine($"TV on: {_isOn}");
            LogReturn();
        }

        public virtual void IncreaseVolume()
        {
            if (!_isOn) { Program.OpenMainMenu(); return; }
            if (_isMute) _beforeMuteVolume = Math.Min(_beforeMuteVolume + 1, _maxVolume);
            else _volume = Math.Min(_volume + 1, _maxVolume);
            Console.Clear();
            Console.WriteLine($"TV volume: {(_isMute ? _beforeMuteVolume : _volume)}");
            LogReturn();
        }

        public virtual void DecreaseVolume()
        {
            if (!_isOn) { Program.OpenMainMenu(); return; }
            if (_isMute) _beforeMuteVolume = Math.Max(_beforeMuteVolume - 1, _minVolume);
            else _volume = Math.Max(_volume - 1, _minVolume);
            Console.Clear();
            Console.WriteLine($"TV volume: {(_isMute ? _beforeMuteVolume : _volume)}");
            LogReturn();
        }

        public virtual void IncreaseChannel()
        {
            if (!_isOn) { Program.OpenMainMenu(); return; }
            _channel = Math.Min(_channel + 1, _maxChannel);
            Console.Clear();
            Console.WriteLine($"TV channel: {_channel}");
            LogReturn();
        }

        public virtual void DecreaseChannel()
        {
            if (!_isOn) { Program.OpenMainMenu(); return; }
            _channel = Math.Max(_channel - 1, _minChannel);
            Console.Clear();
            Console.WriteLine($"TV channel: {_channel}");
            LogReturn();
        }

        public virtual void ChangeChannel()
        {
            if (!_isOn) { Program.OpenMainMenu(); return; }
            Console.Clear();
            Console.WriteLine("Enter New Channel:");
            var str = Console.ReadLine();
            int value;
            while (!int.TryParse(str, out value) || value < _minChannel || value > _maxChannel)
            {
                Console.WriteLine("Invalid Channel!");
                str = Console.ReadLine();
            }

            _channel = Math.Min(Math.Max(value, _minChannel), _maxChannel);
            Console.WriteLine($"TV channel: {_channel}");
            LogReturn();
        }

        public virtual void Mute()
        {
            if (!_isOn) { Program.OpenMainMenu(); return; }
            _isMute = !_isMute;
            if (_isMute) _beforeMuteVolume = _volume;
            _volume = _isMute ? 0 : _beforeMuteVolume;
            Console.Clear();
            Console.WriteLine($"TV is mute: {_isMute}, TV volume: {_volume}");
            LogReturn();
        }

        public virtual void OpenSetting()
        {
            if (!_isOn) { Program.OpenMainMenu(); return; }
            _isOpenSetting = true;
            Console.Clear();
            Console.WriteLine($"TV Setting Opened: {_isOpenSetting}");
            Console.WriteLine($"TV Specs:\n{_TV_U7000s.Where(spec => spec.Id == _deviceID).First()}\n");
            LogReturn();
            _isOpenSetting = false;
        }

        public virtual void OpenSmartMenu()
        {
            if (!_isOn) { Program.OpenMainMenu(); return; }
            _isOpemSmartMenu = true;
            Console.Clear();
            Console.WriteLine($"TV Smart Menu Opened: {_isOpemSmartMenu}");
            LogReturn();
            _isOpemSmartMenu = false;
        }
    }
}