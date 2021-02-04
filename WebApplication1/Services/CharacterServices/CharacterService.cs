using AutoMapper;
using RPG_GAME.DTO.Character;
using RPG_GAME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character { Name = "Sam"}
        };


        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddNewChracter(AddCharacterDTO ch)
        {
            ServiceResponse<List<GetCharacterDTO>> response = new ServiceResponse<List<GetCharacterDTO>>();
            Character character = _mapper.Map<Character>(ch);
            character.ID = characters.Max(c => c.ID) + 1;
            characters.Add(character);
            response.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllChracters()
        {
            ServiceResponse<List<GetCharacterDTO>> response = new ServiceResponse<List<GetCharacterDTO>>();
            response.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetById(int Id)
        {
            ServiceResponse<GetCharacterDTO> response = new ServiceResponse<GetCharacterDTO>();
            response.Data = _mapper.Map<GetCharacterDTO>(characters.FirstOrDefault(c => c.ID == Id));
            return response;
        }
    }
}
