using System.ComponentModel.DataAnnotations;

namespace Chat.DataAccess.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }

    }
}
