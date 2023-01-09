namespace API.Resources.Infrastructure.Dtos
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Gender { get; set; }

        public List<SubscriptionDto> Subscriptions { get; set; }
        public List<ServiceRecordDto> ServiceRecords { get; set; }

        public EmployeeDto()
        {
            Subscriptions = new List<SubscriptionDto>();
            ServiceRecords = new List<ServiceRecordDto>();
        }
    }
}
