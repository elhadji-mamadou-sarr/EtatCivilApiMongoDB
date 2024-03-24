using EtatCivilApiMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace EtatCivilApiMongoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BirthController : Controller
    {
        private readonly IMongoCollection<Birth> _birthCollection;
        const string connectionUri = "mongodb+srv://elhadjimamadou47:Elhadjisarr_12@cluster0.pmrfrzp.mongodb.net/?retryWrites=true&w=majority";
        private static MongoClient _mongoClient = new MongoClient(connectionUri);
        
        public BirthController()
        {
            var mongoDataBase = _mongoClient.GetDatabase("cluster0");
           
            _birthCollection = mongoDataBase.GetCollection<Birth>("birth");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Birth birth)
        {
            await _birthCollection.InsertOneAsync(birth);

            return CreatedAtAction(nameof(Get), new { id = birth.Id }, birth);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Birth updatedBirth)
        {
            var birth = await _birthCollection.Find(b => b.Id == id).FirstOrDefaultAsync();

            if (birth is null)
            {
                return NotFound();
            }

            updatedBirth.Id = birth.Id;

            await _birthCollection.ReplaceOneAsync(b => b.Id == id, updatedBirth);

            return NoContent();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Birth>> Get(string id)
        {
            var birth = await _birthCollection.Find(b => b.Id == id).FirstOrDefaultAsync();

            if (birth is null)
            {
                return NotFound();
            }

            return birth;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Birth>>> Get()
        {
            var births = await _birthCollection.Find(_ => true).ToListAsync();

            return births;
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var birth = await _birthCollection.Find(b => b.Id == id).FirstOrDefaultAsync();

            if (birth is null)
            {
                return NotFound();
            }

            await _birthCollection.DeleteOneAsync(b => b.Id == id);

            return NoContent();
        }

    }
}
