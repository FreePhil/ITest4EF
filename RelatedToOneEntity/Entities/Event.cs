using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RelatedToOneEntity.Entities;

[Table("events")]
public class Event
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] [Column("id")] public long Id { get; set; }

    [Column("name")]public string Name { get; set; } = string.Empty;
    [Column("created")]public DateTime Created { get; set; } = DateTime.Now;
    
    public virtual ICollection<Many1> Many1s { get; set; } = new List<Many1>();
    public virtual ICollection<Many2> Many2s { get; set; } = new List<Many2>();
}