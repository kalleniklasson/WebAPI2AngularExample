using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI2Angular.DAL;
using WebAPI2Angular.Models;

namespace WebAPI2Angular.Controllers
{
    public class PersonsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Person> _personsRepository;

        public PersonsController(IUnitOfWork unitOfWork, IRepository<Person> personsRepository)
        {
            _unitOfWork = unitOfWork;
            _personsRepository = personsRepository;
        }

        // GET: api/People
        public IHttpActionResult GetPersons()
        {
            return Ok(_personsRepository.Get());
        }

        // GET: api/People/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult GetPerson(int id)
        {
            var person = _personsRepository.Get(p => p.Id == id).FirstOrDefault();
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return BadRequest();
            }

            try
            {
                _personsRepository.Update(person);
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/People
        [ResponseType(typeof(Person))]
        public IHttpActionResult PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _personsRepository.Insert(person);
            _unitOfWork.Commit();

            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult DeletePerson(int id)
        {
            var person = _personsRepository.Get(p => p.Id == id).FirstOrDefault();
            if (person == null)
            {
                return NotFound();
            }

            _personsRepository.Delete(person);
            _unitOfWork.Commit();

            return Ok(person);
        }

        private bool PersonExists(int id)
        {
            return _personsRepository.Get().Count(e => e.Id == id) > 0;
        }
    }
}
