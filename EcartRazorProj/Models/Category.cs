using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EcartRazorProj.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(30)]
		[DisplayName("Calegory Name")]
		public string? Name { get; set; }
		[DisplayName("Display Name")]
		[Range(0, 100)]
		public int DisplayOrder { get; set; }

	}
}
