namespace API.Resources.Core.Entities
{
    public enum Gender
    {
        Male = 1, 
        Female = 2
    }

    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public Gender Gender { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<ServiceRecord> ServiceRecords { get; set; }

        public Employee()
        {
            Subscriptions = new HashSet<Subscription>();
            ServiceRecords = new HashSet<ServiceRecord>();
        }
    }
}
