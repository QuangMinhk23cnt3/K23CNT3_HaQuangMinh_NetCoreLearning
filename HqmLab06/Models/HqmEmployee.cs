namespace HqmLab06.Models
{
    public class HqmEmployee
    {
        public int HqmId { get; set; }
        public string HqmName { get; set; }
        public DateTime HqmBirthDay { get; set; }
        public string HqmEmail { get; set; }
        public string HqmPhone { get; set; }
        public decimal HqmSalary { get; set; }
        public bool HqmStatus { get; set; }
    }
}
