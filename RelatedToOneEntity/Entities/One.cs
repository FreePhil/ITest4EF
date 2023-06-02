using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RelatedToOneEntity.Entities;

[Table("ones")]
public class One
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] [Column("id")] public long Id { get; set; }
    [Column("message")] public string Message { get; set; } = string.Empty;
}