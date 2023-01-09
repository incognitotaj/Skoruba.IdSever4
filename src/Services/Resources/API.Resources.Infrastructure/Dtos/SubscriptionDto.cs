namespace API.Resources.Infrastructure.Dtos
{
    public class SubscriptionDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string Member { get; set; }
    }
}
