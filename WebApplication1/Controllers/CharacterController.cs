using Microsoft.AspNetCore.Mvc;
using RPG_GAME.DTO.Character;
using RPG_GAME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services.CharacterServices;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _characterService.GetAllChracters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _characterService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDTO ch)
        {
            return Ok(await _characterService.AddNewChracter(ch));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDTO ch)
        {
            ServiceResponse<GetCharacterDTO> response = await _characterService.UpdateCharacter(ch);

            if(response.Success)
                return Ok(response);

            return NotFound(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDTO>> response = await _characterService.DeleteCharacter(id);

            if (response.Success)
                return Ok(response);

            return NotFound(response);
        }
    }
}
