using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("FilialenKundenNr")]
public partial class BranchCustomerNumber
{
    [Key]
    [Column("FilialNr")]
    public short BranchNumber { get; set; }

    [Column("KundenNrVon")]
    public long CustomerNumberFrom { get; set; }

    [Column("KundenNrBis")]
    public long CustomerNumberTo { get; set; }

    [Column("IsAktiv")]
    public bool IsActive { get; set; } = true;

    [ForeignKey("BranchNumber")]
    [InverseProperty("BranchCustomerNumber")]
    public virtual Branch BranchNumberNavigation { get; set; } = null!;
}