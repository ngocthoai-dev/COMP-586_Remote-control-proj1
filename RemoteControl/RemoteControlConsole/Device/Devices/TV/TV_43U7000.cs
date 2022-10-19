namespace Core.Device
{
    internal class TV_43U7000 : BaseTVDevice
    {
        public override void OpenSmartMenu()
        {
            if (!_isOn) return;
            _isOpemSmartMenu = true;
            Console.Clear();
            Console.WriteLine($"This Model {_deviceID} is Not Supported Smart Menu");
            LogReturn();
            _isOpemSmartMenu = false;
        }
    }
}