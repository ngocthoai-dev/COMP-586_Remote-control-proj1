namespace Core.Device
{
    internal struct NameValueData
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    internal struct DimesionData
    {
        public string Name { get; set; }
        public float W { get; set; }
        public float H { get; set; }
        public float D { get; set; }
    }

    internal struct WeightData
    {
        public string Name { get; set; }
        public float Weight { get; set; }
    }

    internal struct DescriptionWithDataList<TData>
    {
        public string Description { get; set; }
        public TData[] Datas { get; set; }
    }

    [Serializable]
    internal class TVSettingData
    {
        public string Id { get; set; } = "";
        public string Model { get; set; } = "";
        public string OrderCode { get; set; } = "";
        public float ScreenSizeClass { get; set; }
        public float ScreenDiagonalMesurement { get; set; }
        public string UPCCode { get; set; } = "";
        public string CountryOfOrigin { get; set; } = "";
        public DescriptionWithDataList<DimesionData> Dimensions { get; set; }
        public DescriptionWithDataList<WeightData> Weights { get; set; }
        public string VESASupport { get; set; } = "";
        public NameValueData[] AccessoriesIncludedInBox { get; set; } = Array.Empty<NameValueData>();
    }

    [Serializable]
    internal class TU7000_Spec : TVSettingData
    {
        public override string ToString()
        {
            return $"\tMODEL: {Model}\n" +
                $"\tORDER CODE: {OrderCode}\n" +
                $"\tSCREEN SIZE CLASS: {ScreenSizeClass}\"\n" +
                $"\tSCREEN DIAGONAL MEASUREMENT: {ScreenDiagonalMesurement}\"\n" +
                $"\tUPC CODE: {UPCCode}\n" +
                $"\tCOUNTRY OF ORIGIN: {CountryOfOrigin}\n" +
                $"\tDIMENSIONS {Dimensions.Description}:\n" +
                    string.Join("\n", Dimensions.Datas.Select(data =>
                        $"\t\t{data.Name}: {data.W} x {data.H} x {data.D}")) +
                $"\tWEIGHT {Weights.Description}\n" +
                    string.Join("\n", Weights.Datas.Select(data =>
                        $"\t\t{data.Name}: {data.Weight}")) +
                $"\tVESA SUPPORT: {VESASupport}\n" +
                $"\tACCESSORIES INCLUDED IN BOX: {Model}\n" +
                    string.Join("\n", AccessoriesIncludedInBox.Select(data =>
                        $"\t{data.Name}: {data.Value}"));
        }
    }
}