using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Filialen")]
public partial class Branch
{
    [Key]
    [Column("FilialNr")]
    public short BranchNumber { get; set; }

    [Column("KundenNrCS")]
    public long CustomerNumberCs { get; set; }

    [Column("Eigene")]
    public bool IsOwn { get; set; }

    [Column("Hauptfiliale")]
    public bool IsHeadquarters { get; set; }

    [Column("Grosshandel")]
    public bool IsWholesale { get; set; }

    [StringLength(40)]
    [Column("Filialleiter")]
    public string BranchManager { get; set; } = "";

    [Column("WEEERegNr")]
    [StringLength(30)]
    public string WeeeregNumber { get; set; } = "";

    [Column("Flaeche")]
    public double Area { get; set; }

    [Column("Fixkosten")]
    public double FixedCosts { get; set; }

    [Column("FilElLiefVKTyp")]
    public byte BranchElDeliverySalesType { get; set; } = 1;

    [Column("FilElLiefFaktor")]
    public double BranchElDeliveryFactor { get; set; } = 1.0;

    [StringLength(50)]
    [Column("Kennwort")]
    public string Password { get; set; } = "";

    [StringLength(50)]
    [Column("FiBuMandantenNr")]
    public string? FiBuClientNumber { get; set; } = "";

    [StringLength(50)]
    [Column("FiBuBeraterNr")]
    public string? FiBuAdvisorNumber { get; set; } = "";

    [InverseProperty("BranchNumberNavigation")]
    public virtual BranchCustomerNumber? BranchCustomerNumber { get; set; }
}
