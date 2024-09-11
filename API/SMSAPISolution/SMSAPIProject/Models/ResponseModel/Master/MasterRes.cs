namespace SMSAPIProject.Models.ResponseModel.Master
{
    public class MasterRes : CommonRes
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
