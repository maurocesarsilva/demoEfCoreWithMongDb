using crudMongo.DataBase;
using crudMongo.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace crudMongo.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MovieController(Repository repository) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await repository.Get<Movie>());
		}

		[HttpGet("{name}")]
		public async Task<IActionResult> Get([FromRoute] string name)
		{
			return Ok(await repository.Get<Movie>(x => x.Title == name));
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Movie movie)
		{
			movie.Id = Guid.NewGuid();
			var result = await repository.Save(movie);
			return Created("", result);
		}

		[HttpPut]
		public async Task<IActionResult> Put([FromBody] Movie movie)
		{
			await repository.Update(movie);

			return NoContent();
		}
		[HttpDelete("{id}:guid")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			var entity = await repository.GetFirst<Movie>(x => x.Id == id);
			await repository.Delete(entity);

			return NoContent();
		}
	}
}
