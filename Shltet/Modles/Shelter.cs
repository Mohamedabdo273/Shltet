namespace Shltet.Modles
{
    public class Shelter
    {
        public int Id { get; set; }
        public string? ShelterName { get; set; }
        public string? Location { get; set; }
        public string? ContactEmail { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
        public ShelterStatus? Status { get; set; }
        //public ICollection<ApplicationUser>? StaffMembers { get; set; }
        //public ICollection<Pet>? Pets { get; set; }
    }
    public enum ShelterStatus
    {
        Pending,
        Approved,
        Rejected
    }

}
