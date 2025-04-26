using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenParcial_Jean.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(15, 50)]
        public int Age { get; set; }

        [Required]
        public string Position { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }

    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }

    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
        public int TeamId { get; set; }

        public Player Player { get; set; }
        public Team Team { get; set; }

    }
}
