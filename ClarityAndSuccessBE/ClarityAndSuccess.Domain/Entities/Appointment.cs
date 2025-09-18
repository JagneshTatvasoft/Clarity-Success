using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClarityAndSuccess.Domain.Entities;

[Table("Termine")]
[Index("CustomerNumber", Name = "IX_Termine_KennNr")]
[Index("SupplierArticleNumber", Name = "IX_Termine_LiefArtNr")]
[Index("HandlerStaffNumber", Name = "IX_Termine_PersonalNrBearbeiter")]
[Index("AppointmentEventId", Name = "IX_Termine_TerminEreignisNr")]
public partial class Appointment
{
    [Key]
    [Column("TerminID")]
    public int AppointmentId { get; set; }

    [Column("TerminEreignisID")]
    public int AppointmentEventId { get; set; }

    public bool IsCompleted { get; set; }

    [Precision(0)]
    public DateTime? Date { get; set; }

    public bool IsSeries { get; set; }

    [StringLength(50)]
    [Column("Betreff")]
    public string Subject { get; set; } = string.Empty;

    [StringLength(255)]
    [Column("Bemerkung")]
    public string Remark { get; set; } = string.Empty;

    [Column("EMail")]
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;

    [StringLength(30)]
    [Column("Mobil")]
    public string Mobile { get; set; } = string.Empty;

    [Column("KennTyp")]
    public byte IdType { get; set; }

    [Column("KennNr")]
    public long IdNumber { get; set; }

    [StringLength(30)]
    [Column("LiefArtNr")]
    public string SupplierArticleNumber { get; set; } = string.Empty;

    [Column("KassePosID")]
    public long CashRegisterPositionId { get; set; }

    [Column("PersonalNrBearbeiter")]
    public long HandlerStaffNumber { get; set; }

    public bool IsReminded { get; set; }

    [Precision(0)]
    [Column("AktionWord")]
    public DateTime? ActionWord { get; set; }

    [Precision(0)]
    [Column("AktionMail")]
    public DateTime? ActionMail { get; set; }

    [Precision(0)]
    [Column("AktionSMS")]
    public DateTime? ActionSms { get; set; }

    public bool IsExportedToOutlook { get; set; }

    [Column("IsLoeschen")]
    public bool IsDelete { get; set; } = false;

    [Column("AngelegtVNr")]
    public long CreatedByNumber { get; set; }

    [Precision(0)]
    [Column("AngelegtD")]
    public DateTime? CreatedDate { get; set; }

    [Column("GeaendertVNr")]
    public long? ModifiedByNumber { get; set; }

    [Precision(0)]
    [Column("GeaendertD")]
    public DateTime? ModifiedDate { get; set; }

    [Column("IsGeloescht")]
    public bool IsDeleted { get; set; }

    [Column("AVPosID")]
    public long? OrderPositionId { get; set; }

    [Column("FilialNr")]
    public short? BranchNumber { get; set; }

    [StringLength(36)]
    [Column("TermineGuid")]
    public string AppointmentGuid { get; set; } = string.Empty;

    public bool IsExist { get; set; } = true;

    [ForeignKey("AppointmentEventId")]
    [InverseProperty("Appointments")]
    public virtual AppointmentEvent AppointmentEventNavigation { get; set; } = null!;
}