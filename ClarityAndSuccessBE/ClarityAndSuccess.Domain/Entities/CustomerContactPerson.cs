using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClarityAndSuccess.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ClarityAndSuccess.Domain.Entities;

[Table("KundenAnsprechpartner")]
[Index("CustomerNumber", Name = "IX_KundenAnsprechpartner_KundenNr")]
public partial class CustomerContactPerson
{
    [Key]
    [Column("KundenAnsprechpartnerID")]
    public int CustomerContactPersonId { get; set; }

    [Column("KundenNr")]
    public long CustomerNumber { get; set; }

    [StringLength(25)]
    [Column("Vorname")]
    public string FirstName { get; set; } = "";

    [StringLength(40)]
    [Column("Nachname")]
    public string LastName { get; set; } = "";

    [StringLength(20)]
    [Column("Anrede")]
    public string Salutation { get; set; } = "";

    [StringLength(25)]
    [Column("Titel")]
    public string Title { get; set; } = "";

    [StringLength(50)]
    [Column("Position")]
    public string Position { get; set; } = "";

    [StringLength(60)]
    [Column("Telefon")]
    public string Phone { get; set; } = "";

    [StringLength(40)]
    [Column("Fax")]
    public string Fax { get; set; } = "";

    [StringLength(20)]
    [Column("MobilGeschaeftlich")]
    public string BusinessMobile { get; set; } = "";

    [StringLength(20)]
    [Column("MobilPrivat")]
    public string PrivateMobile { get; set; } = "";

    [Column("EMailGeschaeftlich")]
    [StringLength(100)]
    public string BusinessEmail { get; set; } = "";

    [Column("EMailPrivat")]
    [StringLength(100)]
    public string PrivateEmail { get; set; } = "";

    [StringLength(100)]
    [Column("SozialesNetzwerk1")]
    public string SocialNetwork1 { get; set; } = "";

    [StringLength(100)]
    [Column("SozialesNetzwerk2")]
    public string SocialNetwork2 { get; set; } = "";

    [StringLength(32)]
    [Column("Skype")]
    public string Skype { get; set; } = "";

    [Column("Geburtsdatum")]
    public DateTime? DateOfBirth { get; set; }

    [Column("Bevorzugt")]
    public bool IsPreferred { get; set; }

    [StringLength(255)]
    [Column("Bemerkung")]
    public string Comment { get; set; } = "";

    [Precision(0)]
    [Column("AngelegtD")]
    public DateTime? CreatedDate { get; set; }

    [StringLength(80)]
    [Column("AngelegtV")]
    public string? CreatedBy { get; set; } = "";

    [Column("AngelegtVNr")]
    public long CreatedByNumber { get; set; }

    [Precision(0)]
    [Column("GeaendertD")]
    public DateTime? ChangedDate { get; set; }

    [StringLength(80)]
    [Column("GeaendertV")]
    public string? ChangedBy { get; set; } = "";

    [Column("GeaendertVNr")]
    public long ChangedByNumber { get; set; }

    [StringLength(36)]
    [Column("KundenAnsprechpartnerGuid")]
    public string CustomerContactPersonGuid { get; set; } = "";

    [ForeignKey("KundenNr")]
    [InverseProperty("CustomerContactPeople")]
    public virtual Customer CustomerNavigation { get; set; } = null!;
}
