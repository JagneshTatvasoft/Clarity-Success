using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClarityAndSuccess.Domain.Entities;

[Table("ArtikelMasterData")]
[Index("Description", Name = "IX_ArtikelMasterData_Description")]
public partial class ArticleMasterData
{
    [Key]
    [Column("ArtikelMasterDataId")]
    public int ArticleMasterDataId { get; set; }

    [StringLength(30)]
    [Column("Bezeichnung")]
    public string Description { get; set; } = null!;

    [StringLength(50)]
    [Column("Daten1")]
    public string Data1 { get; set; } = null!;

    [StringLength(50)]
    [Column("Daten2")]
    public string Data2 { get; set; } = null!;

    [StringLength(10)]
    [Column("Daten3")]
    public string Data3 { get; set; } = null!;

    [StringLength(50)]
    [Column("Daten4")]
    public string Data4 { get; set; } = null!;
}