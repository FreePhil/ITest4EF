using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RelatedToOneEntity.Entities;

[Table("many1s")]
public class Many1
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] [Column("id")] public long Id { get; set; }

    [Column("updated")] public DateTime Updated { get; set; }
    [Column("created")] public DateTime Created { get; set; } = DateTime.Now;

    [Column("event_id")] public long EventId { get; set; }

    [ForeignKey(nameof(EventId))] public virtual Event ErrorEvent { get; set; } = new Event();

    [Column("one_id")] public long OneId { get; set; }
    [ForeignKey(nameof(OneId))] public virtual One Message { get; set; }= new One();
}