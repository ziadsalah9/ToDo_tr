using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ToDo_tr.Models
{
	public class ToDO
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="Please enter a Description.")]
		public string Description { get; set; }
		[Required(ErrorMessage = "Please enter a Discrption.")]

		public DateTime? Duedate { get; set; }

		[Required (ErrorMessage ="Please select a Category.")]
		public string Categoryid { get; set; } = string.Empty;

		[ValidateNever]
		public Category Category { get; set; } = null!;

		[Required (ErrorMessage ="Please select a Status.")]
		public string StatusId { get; set; } = string.Empty;

		[ValidateNever]
		public Status Status { get; set; } = null!;

		public bool Overdue => StatusId == "open" && Duedate <DateTime.Today;

	}
}
