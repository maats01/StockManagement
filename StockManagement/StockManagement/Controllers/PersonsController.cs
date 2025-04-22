using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System.Runtime.CompilerServices;

namespace StockManagement.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonsService _personsService;

        public PersonsController(IPersonsService personsService)
        {
            _personsService = personsService;
        }

        [Route("[controller]")]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            List<PersonDTO> persons = await _personsService.GetPersons();

            return View(persons);
        }

        [Route("[controller]/[action]")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Create(PersonCreateDTO personCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(personCreateDTO);
            }

            PersonDTO person = await _personsService.AddPerson(personCreateDTO);

            return RedirectToAction("Index");
        }

        [Route("[controller]/[action]/{ID}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int ID)
        {
            PersonDTO? person = await _personsService.GetPersonByID(ID);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            return View(person.ToPersonUpdateDTO());
        }

        [Route("[controller]/[action]/{ID}")]
        [HttpPost]
        public async Task<IActionResult> Edit(PersonUpdateDTO personUpdateDTO)
        {
            PersonDTO? person = await _personsService.GetPersonByID(personUpdateDTO.ID);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                return View(personUpdateDTO);
            }

            await _personsService.UpdatePerson(personUpdateDTO);

            return RedirectToAction("Index");
        }

        [Route("[controller]/[action]/{ID}")]
        [HttpPost]
        public async Task<IActionResult> Delete(int ID)
        {
            bool isRemoved = await _personsService.RemovePerson(ID);

            return RedirectToAction("Index");
        }

        [Route("[controller]/[action]/{ID}")]
        [HttpGet]
        public async Task<IActionResult> Details(int ID)
        {
            PersonDTO? person = await _personsService.GetPersonByID(ID);

            if (person == null)
            {
                return RedirectToAction("Index");
            }

            return View(person);
        }

        [Route("/api/[controller]/searchByName")]
        [HttpGet]
        public async Task<IActionResult> GetPersonsBySubstring(string searchString)
        {
            if (searchString == null)
            {
                searchString = string.Empty;
            }

            List<PersonDTO> persons = await _personsService.GetFilteredPersons(nameof(PersonDTO.Name), searchString);
            IEnumerable<object> result = persons.Select(p => new { p.ID, p.Name });

            return Ok(result);
        }
    }
}
