namespace ToDo_tr.Models
{
	public class Filters
	{
		public Filters(string filterstring) { 
		Filterstring= filterstring??"all-all-all";
			string[] filters=Filterstring.Split('-');
			Categoryid = filters[0];
			Due = filters[1];
			StatusId= filters[2];

		}

		public string Filterstring { get; }
		public string Categoryid { get; }
		public string Due { get; }
		public string StatusId { get; }

		public bool HasCategory => Categoryid.ToLower() != "all";
		public bool HasDue => Due.ToLower() != "all";
		public bool HasStatus => StatusId.ToLower() != "all";

		public static Dictionary<string, string> DueFilterValues =>
			new Dictionary<string, string> {
			{"future","Future"},
		    {"past","Past" },
			{"today","Today" }

			};

		public bool isPast => Due.ToLower() == "past";
		public bool isFuture => Due.ToLower() == "future";
		public bool isToday => Due.ToLower() == "today";

	}
}
