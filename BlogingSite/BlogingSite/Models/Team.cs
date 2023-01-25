using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogingSite.Models
{
    public class Team
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 40)]
        public string FullName { get; set; }

        public string Image { get; set; }
        [StringLength(maximumLength: 40)]
        public string Job { get; set; }

        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string FacebookUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }


    }
}
