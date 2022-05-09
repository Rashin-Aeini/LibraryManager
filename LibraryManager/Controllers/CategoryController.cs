using LibraryManager.Models.Services.Contracts;
using LibraryManager.Models.ViewModels;
using LibraryManager.Models.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService Service { get; }

        public CategoryController(ICategoryService service)
        {
            Service = service;
        }

        [HttpGet]
        public ActionResult<Pagination<DetailsCategory>> List(
            [FromQuery] Paginator entry
            )
        {
            if (entry.PageSize == 0)
            {
                entry.PageSize = 10;
            }

            if (entry.PageIndex == 0)
            {
                entry.PageIndex = 1;
            }

            Pagination<DetailsCategory> result = Service.Paginate(entry);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<DetailsCategory> Create(
            [FromBody] CreateCategory entry
            )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                DetailsCategory item = Service.Create(entry);

                return Ok(item);
            }
            catch (Exception e)
            {
                if (e is DbUpdateException)
                {
                    SqlException exception = e.InnerException as SqlException;

                    if (exception.Number == 2601)
                    {
                        return BadRequest(string.Format(
                            "The duplicate value, {0} saved before",
                            entry.Name
                            ));
                    }
                }

                return BadRequest("Something wrong happend, Please try later");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<DetailsCategory> Details(
                [FromRoute] int id
                )
        {
            if (!Service.Exist(id))
            {
                return NotFound();
            }

            DetailsCategory item = Service.Details(id);

            return Ok(item);
        }

        [HttpPost("{id:int}")]
        public ActionResult<DetailsCategory> Update(
            [FromRoute] int id,
            [FromBody] CreateCategory entry
            )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                DetailsCategory result = Service.Update(id, entry);

                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                if (e is DbUpdateException)
                {
                    SqlException exception = e.InnerException as SqlException;

                    if (exception.Number == 2601)
                    {
                        return BadRequest(string.Format(
                            "The duplicate value, {0} saved before",
                            entry.Name
                            ));
                    }
                }
            }

            return BadRequest("Something wrong happend, Please try later");
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(
            [FromRoute] int id
            )
        {
            if (!Service.Exist(id))
            {
                return NotFound();
            }

            bool result = Service.Remove(id);

            if (result)
            {
                return Ok();
            }

            return BadRequest("Something wrong happend, Please try later");
        }
    }
}
