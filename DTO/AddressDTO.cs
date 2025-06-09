namespace eBazzar.DTO
{
    public class AddressDTO
    {
        public int address_id { get; set; }
        public string? number { get; set; }
        public string? street { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? zipCode { get; set; }
        public string? landmark { get; set; }
        public string? country { get; set; }
        public string? isDefault { get; set; }
        //public string? username { get; set; }
        //public string? mobile { get; set; }
        public int? user_id { get; set; }

    }
}
