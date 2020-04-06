using System.Collections.Generic;

namespace PokeTactics.Pokemons.Scripts
{
    public class Attributes
    {
        public Attribute Attack;
        public Attribute SpecialAttack;
        public Attribute Defense;
        public Attribute SpecialDefense;
        public Attribute Speed;

        public Attributes()
        {
            Attack = new Attribute("Attack");
            SpecialAttack = new Attribute("Sp. Attack");
            Defense = new Attribute("Defense");
            SpecialDefense = new Attribute("Sp. Defense");
            Speed = new Attribute("Speed");  
        }
    }

    public class Attribute
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Modifier { get; set; }

        public Attribute()
        {
            Value = 1;
            Modifier = 0;
        }

        public Attribute(string name) : this()
        {
            Name = name;
        }
    }
}