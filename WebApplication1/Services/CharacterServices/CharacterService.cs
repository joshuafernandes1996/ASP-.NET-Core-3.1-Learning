using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character { Name = "Sam"}
        };
        public async Task<List<Character>> AddNewChracter(Character ch)
        {
            characters.Add(ch);
            return characters;
        }

        public async Task<List<Character>> GetAllChracters()
        {
            return characters;
        }

        public async Task<Character> GetById(int Id)
        {
            return characters.FirstOrDefault(c => c.ID == Id);
        }
    }
}
