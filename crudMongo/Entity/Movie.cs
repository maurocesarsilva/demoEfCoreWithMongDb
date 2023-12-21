using MongoDB.Bson;

namespace crudMongo.Entity
{
	public class Movie
	{
		public Movie(string title)
		{
			Title = title;
		}

		public Guid Id { get; set; }
		public string Title { get; set; }
	}
}
