using BusinessCape.Services;
using DataCape.Items;
using Microsoft.AspNetCore.Mvc;

namespace ControllersCape
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<UserItem> GetUsers()
        {
            return _service.GetUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<UserItem> GetById(int id)
        {
            var item = _service.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public ActionResult<UserItem> Add(UserItem item)
        {
            _service.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _service.Update(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}