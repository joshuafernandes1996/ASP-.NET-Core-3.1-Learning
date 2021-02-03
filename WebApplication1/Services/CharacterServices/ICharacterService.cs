using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services.CharacterServices
{
    public interface ICharacterService
    {
        List<Character> GetAllChracters();
        Character GetById(int Id);
        List<Character> AddNewChracter(Character ch);
    }
}
