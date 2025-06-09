namespace eBazzar.HelperService
{
    public class ServiceResponse<G>
    {
        public G data { get; set; }
        public string message { get; set; }
        public bool status { get; set; }
    }
}
