using DapperGenericRepository.Model.Entities;
using DapperGenericRepository.Model.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DapperGenericRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepository<User> _repository;

        public UsersController(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _repository.GetAllAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User model)
        {
            var result = await _repository.InsertAsync(model);

            return result ? CreatedAtAction(nameof(Get), new { id = model.Id }, model)
                          : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User model)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user is null)
                return NotFound();

            var result = await _repository.UpdateAsync(model);

            return result ? Ok(model) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user is null)
                return NotFound();

            var result = await _repository.DeleteAsync(id);

            return result ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);

        }
    }
}