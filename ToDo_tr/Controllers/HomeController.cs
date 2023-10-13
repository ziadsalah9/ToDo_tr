using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ToDo_tr.Models;

namespace ToDo_tr.Controllers
{
	public class HomeController : Controller
	{

		private ToDocontext context;
		public HomeController(ToDocontext ctx) => context = ctx;
		public IActionResult Index( string id)
		{
			var filters = new Filters(id);
			ViewBag.Filters = filters;
			ViewBag.Categories = context.categories.ToList();
			ViewBag.Statuses = context.statuss.ToList();
			ViewBag.DueFilters = Filters.DueFilterValues;

			IQueryable<ToDO> query = context.ToDos
				.Include(t => t.Category)
				.Include(t => t.Status);

			if (filters.HasCategory) 
			{
			   query = query.Where(t=>t.Categoryid == filters.Categoryid);
			}
			if (filters.HasStatus)
			{
				query = query.Where(t => t.StatusId == filters.StatusId);
			}
			if (filters.HasDue)
			{
				var today = DateTime.Today;
				if (filters.isPast)
				{
					query = query.Where(t=>t.Duedate < today);
				}
				else if (filters.isFuture) 
				{
				  query = query.Where(t=>t.Duedate> today);
				}
				else if (filters.isToday)
				{
					query = query.Where(t => t.Duedate == today);
				}
			}

			var  tasks = query.OrderBy(t=>t.Duedate).ToList();

			return View(tasks);
		}
		[HttpGet]
		public IActionResult Add()
		{   // may be c capital
			ViewBag.Categories = context.categories.ToList();
			ViewBag.Statuss = context.statuss.ToList();
			var task = new ToDO { StatusId = "open" };
			return View(task);
		}

		[HttpPost]
		public IActionResult Add(ToDO task)
		{  
			if(ModelState.IsValid) 
			{
			
				context.ToDos.Add(task);
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.Categories=context.categories.ToList();
				ViewBag.Statuss=context.statuss.ToList();
				return View(task);
			}
		}

		[HttpPost]
		public IActionResult Filter(string[] filter)
		{
			string id = string.Join("-", filter);

			return RedirectToAction("Index",new {ID = id});
		}

		[HttpPost]

		public IActionResult MarkComplete([FromRoute] string id,ToDO selected)
		{
		
			selected = context.ToDos.Find(selected.Id)!;

			if (selected != null)
			{
				selected.StatusId = "closed";
				context.SaveChanges();
			}
			return RedirectToAction("Index",new {ID= id});
		}
		[HttpPost]

		public IActionResult DeleteComplete(string id) 
		{
			var toDelete = context.ToDos.Where(t => t.StatusId == "closed").ToList();
			foreach(var task in toDelete)
			{
				context.ToDos.Remove(task);

			}
			context.SaveChanges();
			return RedirectToAction("Index",new {ID= id});
		
		}

	}
}