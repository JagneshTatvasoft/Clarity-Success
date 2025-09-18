using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClarityAndSuccess.Domain.Entities;

[Table("TerminEreignisse")]
[Index("Reference", Name = "IX_TerminEreignisse_Bezug")]
public partial class AppointmentEvent
{
    [Key]
    [Column("TerminEreignisID")]
    public int AppointmentEventId { get; set; }

    [Column("Bezug")]
    public byte Reference { get; set; }

    [Column("IsAktiv")]
    public bool IsActive { get; set; }

    [Column("IsSerie")]
    public bool IsSeries { get; set; }

    [Column("IsErinnern")]
    public bool IsReminder { get; set; }

    [Column("IsLoeschen")]
    public bool IsDelete { get; set; }

    [StringLength(30)]
    [Column("Ereignis")]
    public string Event { get; set; } = null!;

    [Column("ErinnernNach")]
    public double RemindAfter { get; set; }

    [Column("VKWert")]
    public double SalesValue { get; set; }

    [Column("VKTermin")]
    public double SalesAppointment { get; set; }

    [Column("ErinnernVor")]
    public double RemindBefore { get; set; }

    [Column("PersonalNrBearbeiter")]
    public long HandlerStaffNumber { get; set; }

    [Column("LabelID")]
    public int LabelId { get; set; }

    [Column("TextvorlageID")]
    public int TextTemplateId { get; set; }

    [Column("GutscheinvorlageID")]
    public int VoucherTemplateId { get; set; }

    [Column("AnhangID")]
    public int AttachmentId { get; set; }

    [Column("FilterID")]
    public int FilterId { get; set; }

    [Column("IsStandardtermineEreignis")]
    public bool IsStandardAppointmentEvent { get; set; }

    [StringLength(36)]
    [Column("TerminEreignisseGuid")]
    public string AppointmentEventGuid { get; set; } = null!;

    [InverseProperty("AppointmentEvent")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}