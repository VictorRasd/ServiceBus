namespace ServiceBusContracts
{
    public class CreateCustomerRequest
    {
        public object Id { get; set; }
        public object FullName { get; set; }
        public object DateOfBirth { get; set; }
    }
}