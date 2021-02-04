using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace RPG_GAME.DTO.Character
{
    public class GetCharacterDTO
    {
        public int ID { get; set; } = 10;
        public string Name { get; set; } = "Frodo";
        public int HitPoint { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RPGClass Class { get; set; } = RPGClass.Knight;
    }
}
