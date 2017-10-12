using PosRi.DataAccess.Model;
using System.ComponentModel.DataAnnotations;

namespace PosRi.BusinessLogic.Dtos
{
    public class BrandDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public BrandDto()
        {
            
        }

        public BrandDto(Brand brand)
        {
            Id = brand.Id;
            Name = brand.Name;
        }

    }
}
