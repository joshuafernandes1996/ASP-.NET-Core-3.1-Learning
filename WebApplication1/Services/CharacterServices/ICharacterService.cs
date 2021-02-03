using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services.CharacterServices
{
    public interface ICharacterService
    {
       Task<List<Character>> GetAllChracters();
       Task<Character> GetById(int Id);
       Task<List<Character>> AddNewChracter(Character ch);
    }
}
