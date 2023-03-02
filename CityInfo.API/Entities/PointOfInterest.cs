using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.API.Entities {
    public class PointOfInterest {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string? Description { get; set; }

        [Required]
        [ForeignKey("cityId")]
        public City? city { get; set; }
        public int cityId { get; set; }

        public int MyProperty {
            get { return cityId; }
            set { cityId = value; }
        }


        public PointOfInterest( string name) {
            Name = name;
        }

    }
}
