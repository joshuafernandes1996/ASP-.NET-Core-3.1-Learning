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

        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updateCharacterDTO)
        {
            ServiceResponse<GetCharacterDTO> response = new ServiceResponse<GetCharacterDTO>();

            try
            {
                Character ch = characters.FirstOrDefault(c => c.ID == updateCharacterDTO.ID);
                ch.Name = updateCharacterDTO.Name;
                ch.Strength = updateCharacterDTO.Strength;
                ch.Intelligence = updateCharacterDTO.Intelligence;
                ch.HitPoint = updateCharacterDTO.HitPoint;
                ch.Defense = updateCharacterDTO.Defense;
                ch.Class = updateCharacterDTO.Class;

                response.Data = _mapper.Map<GetCharacterDTO>(ch);
            }
            catch (Exception e) {
                response.Message = "Not Found Character with ID: " + updateCharacterDTO.ID;
                response.Success = false;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDTO>> response = new ServiceResponse<List<GetCharacterDTO>>();

            try
            {
                Character ch = characters.First(c => c.ID == id);

                characters.Remove(ch);

                response.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            }
            catch (Exception e)
            {
                response.Message = "Not Found Character with ID: " + id;
                response.Success = false;
            }

            return response;
        }
    }
}
