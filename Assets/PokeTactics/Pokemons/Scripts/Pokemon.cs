using TbsFramework.Units;
using UnityEngine;

namespace PokeTactics.Pokemons.Scripts
{
    public class Pokemon : Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Attributes Attributes { get; set; }

        //TODO: Create constructor receiving a Pokemon ID
        public Pokemon()
        {
            Id = 1;
            Name = "Teste";
            Attributes = new Attributes()
            {
                Health = {MaxValue = 10, Value = 10},
                AttackPoints = {MaxValue = 5, Value = 5},
                MovementPoints = {MaxValue = 3, Value = 3},
            };
        }
        
        public override void Initialize()
        {
            base.Initialize();
            transform.localPosition += new Vector3(0, 0, -0.1f);
        }

        public override void MarkAsDefending(Unit aggressor)
        {
            SetHighlighterColor(Color.blue);
        }

        public override void MarkAsAttacking(Unit target)
        {
            SetHighlighterColor(Color.yellow);
        }

        public override void MarkAsDestroyed()
        {
            SetHighlighterColor(Color.grey);
        }

        public override void MarkAsFriendly()
        {
            SetHighlighterColor(new Color(0.75f, 0.75f, 0.75f, 0.5f));
        }
        public override void MarkAsReachableEnemy()
        {
            SetHighlighterColor(new Color(1, 0, 0, 0.5f));
        }
        public override void MarkAsSelected()
        {
            SetHighlighterColor(new Color(0, 1, 0, 0.5f));
        }
        public override void MarkAsFinished()
        {
            SetColor(Color.gray);
            SetHighlighterColor(new Color(0.75f, 0.75f, 0.75f, 0.5f));
        }
        public override void UnMark()
        {
            SetHighlighterColor(Color.clear);
            SetColor(Color.white);
        }

        private void SetColor(Color color)
        {
            var _renderer = GetComponent<SpriteRenderer>();
            if (_renderer != null)
            {
                _renderer.color = color;
            }
        }
        private void SetHighlighterColor(Color color)
        {
            var highlighter = transform.Find("WhiteTile").GetComponent<SpriteRenderer>();
            if (highlighter != null)
            {
                highlighter.color = color;
            }
        }
    }
}
