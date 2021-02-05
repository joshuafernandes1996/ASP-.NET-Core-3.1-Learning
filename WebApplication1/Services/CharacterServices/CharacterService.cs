using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG_GAME.Data;
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
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddNewChracter(AddCharacterDTO ch)
        {
            ServiceResponse<List<GetCharacterDTO>> response = new ServiceResponse<List<GetCharacterDTO>>();
            Character character = _mapper.Map<Character>(ch);
            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
            response.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllChracters(int id)
        {
            ServiceResponse<List<GetCharacterDTO>> response = new ServiceResponse<List<GetCharacterDTO>>();
            List<Character> dbCharacters = await _context.Characters.Where(c => c.User.ID == id).ToListAsync();
            response.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetById(int Id)
        {
            ServiceResponse<GetCharacterDTO> response = new ServiceResponse<GetCharacterDTO>();
            Character ch = await _context.Characters.FirstOrDefaultAsync(c => c.ID == Id);
            response.Data = _mapper.Map<GetCharacterDTO>(ch);
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updateCharacterDTO)
        {
            ServiceResponse<GetCharacterDTO> response = new ServiceResponse<GetCharacterDTO>();

            try
            {
                Character ch = await _context.Characters.FirstOrDefaultAsync(c => c.ID == updateCharacterDTO.ID);
                ch.Name = updateCharacterDTO.Name;
                ch.Strength = updateCharacterDTO.Strength;
                ch.Intelligence = updateCharacterDTO.Intelligence;
                ch.HitPoint = updateCharacterDTO.HitPoint;
                ch.Defense = updateCharacterDTO.Defense;
                ch.Class = updateCharacterDTO.Class;

                _context.Characters.Update(ch);
                await _context.SaveChangesAsync();

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
                Character ch = await _context.Characters.FirstAsync(c => c.ID == id);

                _context.Characters.Remove(ch);
                await _context.SaveChangesAsync();

                response.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
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
