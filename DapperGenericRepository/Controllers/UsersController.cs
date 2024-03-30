using AutoMapper;
using DapperGenericRepository.Model.Dtos.User;
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
        private readonly IMapper _mapper;

        public UsersController(IGenericRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
        public async Task<IActionResult> Create(UserRequestModel model)
        {
            var mappingModel = _mapper.Map<User>(model);

            var insertedId = await _repository.InsertAsync(mappingModel);

            if (insertedId != 0)
            {
                mappingModel.Id = insertedId;
                return CreatedAtAction(nameof(Get), new { id = insertedId }, mappingModel);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserRequestModel model)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user is null)
                return NotFound();

            var mappingModel = _mapper.Map<User>(model);
            mappingModel.Id = id;

            var result = await _repository.UpdateAsync(mappingModel);

            return result ? Ok(mappingModel) : StatusCode(StatusCodes.Status500InternalServerError);
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