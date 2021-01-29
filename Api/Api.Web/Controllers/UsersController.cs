using Api.Domain;
using Api.Web.Helpers;
using Api.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <response code="200">Returns all users</response>
        /// <response code="404">user not found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Users>> GetAsync()
        {
            var users = await usersService.GetAllAsync();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">user id</param>
        /// <response code="200">Returns user</response>
        /// <response code="404">user not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Users>> GetByIdAsync([FromRoute] Guid id)
        {
            var user = await usersService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        /// <summary>
        /// Create one user
        /// </summary>
        /// <param name="createModel">User</param>
        /// <response code="201">User successfully created</response>
        /// <response code="400">Validation failed</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateAsync([FromBody] UserCreateViewModel createModel)
        {
            var (result, id) = await usersService.CreateAsync(createModel.Name, createModel.Active);

            if (result.Successed)
            {
                return Created(Url.Action("GetById", new { id }), await usersService.GetByIdAsync(id));
            }

            return BadRequest(result.ToProblemDetails());
        }

        /// <summary>
        /// Update on user
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="updateModel">Updated user</param>
        /// <response code="204">user not found</response>
        /// <response code="200">updated</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Users>> UpdateAsync([FromRoute] Guid id, [FromBody] UserUpdateViewModel updateModel)
        {
            var result = await usersService.UpdateAsync(id, updateModel.Active);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete one user
        /// </summary>
        /// <param name="id">user id</param>
        /// <response code="204">User successfully deleted</response>
        /// <response code="404">User not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if (await usersService.GetByIdAsync(id) == null)
            {
                return NotFound();
            }

            await usersService.DeleteAsync(id);

            return NoContent();
        }
    }
}
