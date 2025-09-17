using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("Stammdaten")]
[Index("Description", Name = "idxBezeichnung")]
[Index("Data1", Name = "idxDaten1")]
public partial class MasterData
{
    [StringLength(50)]
    [Column("Bezeichnung")]
    public string? Description { get; set; } = "";

    [StringLength(50)]
    [Column("Daten1")]
    public string? Data1 { get; set; } = "";

    [StringLength(50)]
    [Column("Daten2")]
    public string? Data2 { get; set; } = "";

    [StringLength(255)]
    [Column("Daten3")]
    public string? Data3 { get; set; } = "";

    [StringLength(255)]
    [Column("Daten4")]
    public string? Data4 { get; set; } = "";

    [Key]
    [Column("ID")]
    public int Id { get; set; }
}