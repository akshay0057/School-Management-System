namespace BlazorServerUIApp.Models.ResponseModels.Master
{
    public class MasterDataRes : CommonRes
    {
        public MasterData? Data { get; set; }
    }

    public class MasterData
    {
        public List<DropdownResponseData>? Classes { get; set; }
        public List<DropdownResponseData>? Sections { get; set; }
        public List<DropdownResponseData>? Roles { get; set; }
        public List<DropdownResponseData>? Salutations { get; set; }
    }
}
