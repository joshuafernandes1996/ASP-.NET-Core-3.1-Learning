﻿using RPG_GAME.DTO.Character;
using RPG_GAME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services.CharacterServices
{
    public interface ICharacterService
    {
       Task<ServiceResponse<List<GetCharacterDTO>>> GetAllChracters(int id);
       Task<ServiceResponse<GetCharacterDTO>> GetById(int Id);
       Task<ServiceResponse<List<GetCharacterDTO>>> AddNewChracter(AddCharacterDTO ch);
       Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO ch);
       Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int id);
    }
}
