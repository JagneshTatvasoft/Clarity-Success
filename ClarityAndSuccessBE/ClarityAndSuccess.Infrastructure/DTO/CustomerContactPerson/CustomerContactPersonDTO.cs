namespace ClarityAndSuccess.Infrastructure.DTO.CustomerContactPerson;

public class CustomerContactPersonDTO
{
    public int CustomerContactPersonId { get; set; } = 0;
    public long CustomerNumber { get; set; } = 0;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Salutation { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Fax { get; set; } = string.Empty;
    public string BusinessMobile { get; set; } = string.Empty;
    public string PrivateMobile { get; set; } = string.Empty;
    public string BusinessEmail { get; set; } = string.Empty;
    public string PrivateEmail { get; set; } = string.Empty;
    public string SocialNetwork1 { get; set; } = string.Empty;
    public string SocialNetwork2 { get; set; } = string.Empty;
    public string Skype { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; } = null;
    public bool IsPreferred { get; set; } = false;
    public string Comment { get; set; } = string.Empty;
    public DateTime? CreatedDate { get; set; } = null;
    public string? CreatedBy { get; set; } = string.Empty;
    public long CreatedByNumber { get; set; } = 0;
    public DateTime? ChangedDate { get; set; } = null;
    public string? ChangedBy { get; set; } = string.Empty;
    public long ChangedByNumber { get; set; } = 0;
    public string CustomerContactPersonGuid { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
    public bool IsUpdated { get; set; } = false;
}
