using Microsoft.AspNetCore.Mvc;
using LibraryManager.Models.Services.Contracts;
using LibraryManager.Models.ViewModels.LibraryItem.Digital;
using LibraryManager.Models.ViewModels.LibraryItem.Physical;
using LibraryManager.Models.ViewModels;
using LibraryManager.Models.ViewModels.LibraryItem;

namespace LibraryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryItemController : ControllerBase
    {
        private ILibraryItemService LibraryItemService { get; }

        public LibraryItemController(ILibraryItemService libraryItemService)
        {
            LibraryItemService = libraryItemService;
        }

        [HttpGet]
        public ActionResult<Pagination<PaginateLibraryItem>> List([FromQuery] PaginatorLibraryItem entry)
        {
            if (entry.PageSize == 0)
            {
                entry.PageSize = 10;
            }

            if (entry.PageIndex == 0)
            {
                entry.PageIndex = 1;
            }

            Pagination<PaginateLibraryItem> pagination = LibraryItemService
                .Paginate<PaginateLibraryItem>(entry);

            return Ok(pagination);
        }

        [HttpPost("[action]")]
        public ActionResult<DigitalDetailsLibraryItem> Audio([FromBody] CreateAudioLibraryItem entry)
        {
            return Ok(LibraryItemService.Create<DigitalDetailsLibraryItem>(entry));
        }

        [HttpGet("[action]/{id:int}")]
        public ActionResult<DigitalDetailsLibraryItem> Audio([FromRoute] int id)
        {
            DigitalDetailsLibraryItem details = LibraryItemService.Details<DigitalDetailsLibraryItem>(id);

            if(details == null)
            {
                return NotFound();
            }

            if(!details.Type.Equals(nameof(Audio)))
            {
                return BadRequest();
            }

            return Ok(details);
        }

        [HttpPut("[action]/{id:int}")]
        public ActionResult<DigitalDetailsLibraryItem> Audio(
            [FromRoute] int id, 
            [FromBody] CreateAudioLibraryItem entry
            )
        {
            DigitalDetailsLibraryItem details = LibraryItemService.Update<DigitalDetailsLibraryItem>(id, entry);

            if (details == null)
            {
                return BadRequest();
            }

            return Ok(details);
        }

        [HttpPost("[action]")]
        public ActionResult<DigitalDetailsLibraryItem> DVD([FromBody] CreateDVDLibraryItem entry)
        {
            return Ok(LibraryItemService.Create<DigitalDetailsLibraryItem>(entry));
        }

        [HttpGet("[action]/{id:int}")]
        public ActionResult<DigitalDetailsLibraryItem> DVD([FromRoute] int id)
        {
            DigitalDetailsLibraryItem details = LibraryItemService.Details<DigitalDetailsLibraryItem>(id);

            if (details == null)
            {
                return NotFound();
            }

            if (!details.Type.Equals(nameof(DVD)))
            {
                return BadRequest();
            }

            return Ok(details);
        }

        [HttpPut("[action]/{id:int}")]
        public ActionResult<DigitalDetailsLibraryItem> DVD(
            [FromRoute] int id, 
            [FromBody] CreateDVDLibraryItem entry
            )
        {
            DigitalDetailsLibraryItem details = LibraryItemService.Update<DigitalDetailsLibraryItem>(id, entry);

            if (details == null)
            {
                return BadRequest();
            }

            return Ok(details);
        }

        [HttpPost("[action]")]
        public ActionResult<PhysicalDetailsLibraryItem> Book([FromBody] CreateBookLibraryItem entry)
        {
            return Ok(LibraryItemService.Create<PhysicalDetailsLibraryItem>(entry));
        }

        [HttpGet("[action]/{id:int}")]
        public ActionResult<PhysicalDetailsLibraryItem> Book([FromRoute] int id)
        {
            PhysicalDetailsLibraryItem details = LibraryItemService.Details<PhysicalDetailsLibraryItem>(id);

            if (details == null)
            {
                return NotFound();
            }

            if (!details.Type.Equals(nameof(Book)))
            {
                return BadRequest();
            }

            return Ok(details);
        }

        [HttpPut("[action]/{id:int}")]
        public ActionResult<PhysicalDetailsLibraryItem> Book(
            [FromRoute] int id, 
            [FromBody] CreateBookLibraryItem entry
            )
        {
            PhysicalDetailsLibraryItem details = LibraryItemService.Update<PhysicalDetailsLibraryItem>(id, entry);

            if (details == null)
            {
                return BadRequest();
            }

            return Ok(details);
        }

        [HttpPost("[action]")]
        public ActionResult<PhysicalDetailsLibraryItem> Reference([FromBody] CreateReferenceLibraryItem entry)
        {
            return Ok(LibraryItemService.Create<PhysicalDetailsLibraryItem>(entry));
        }

        [HttpGet("[action]/{id:int}")]
        public ActionResult<PhysicalDetailsLibraryItem> Reference([FromRoute] int id)
        {
            PhysicalDetailsLibraryItem details = LibraryItemService.Details<PhysicalDetailsLibraryItem>(id);

            if (details == null)
            {
                return NotFound();
            }

            if (!details.Type.Equals(nameof(Reference)))
            {
                return BadRequest();
            }

            return Ok(details);
        }

        [HttpPut("[action]/{id:int}")]
        public ActionResult<PhysicalDetailsLibraryItem> Reference(
            [FromRoute] int id, 
            [FromBody] CreateReferenceLibraryItem entry
            )
        {
            PhysicalDetailsLibraryItem details = LibraryItemService.Update<PhysicalDetailsLibraryItem>(id, entry);

            if(details == null)
            {
                return BadRequest();
            }

            return Ok(details);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {
            bool result = LibraryItemService.Remove(id);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
