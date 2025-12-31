using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Product:IIDEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public short UnitsInStock { get; set; }
        public float UnitPrice { get; set; }
    }
}