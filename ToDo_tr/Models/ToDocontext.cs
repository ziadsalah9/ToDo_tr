using Microsoft.EntityFrameworkCore;

namespace ToDo_tr.Models
{
	public class ToDocontext :DbContext 
	{
		public ToDocontext(DbContextOptions<ToDocontext> options) : base (options) { }
		public DbSet<ToDO> ToDos { get; set; } = null!;
		public DbSet<Category> categories { get; set; } = null!;
		public DbSet<Status> statuss { get; set; } = null!;

		protected override void OnModelCreating (ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(
				new Category { Categoryid = "work" , Name = "Work"},
				new Category { Categoryid = "home", Name = "Home" },
				new Category { Categoryid = "ex", Name = "Exercise" },
				new Category { Categoryid = "shop", Name = "Shopping" },
				new Category { Categoryid = "call", Name = "Contact" }




				);

			modelBuilder.Entity<Status>().HasData(
				
				new Status { StatusId = "open" , Name = "Open"},
				new Status { StatusId ="closed", Name = "Completed"}
				
				);

		}


	}
}
