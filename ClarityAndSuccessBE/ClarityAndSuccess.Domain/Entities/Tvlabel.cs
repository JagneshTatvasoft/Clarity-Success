using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClarityAndSuccess.Domain.Entities;

[Table("TVLabels")]
public partial class Tvlabel
{
    [Key]
    [Column("LabelID")]
    public int LabelId { get; set; }

    [Column("GUID")]
    [StringLength(50)]
    public string Guid { get; set; } = null!;

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string Color { get; set; } = null!;

    [Column("IsAktiv")]
    public bool IsActive { get; set; }
}