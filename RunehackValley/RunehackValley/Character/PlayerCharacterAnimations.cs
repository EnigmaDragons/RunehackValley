using System.Collections.Generic;
using RunehackValley.Graphics;

namespace RunehackValley.Character
{
    public sealed class PlayerCharacterAnimations : Animations
    {
        public PlayerCharacterAnimations() 
            : base(Get(), "Down-False") { }

        private static Dictionary<string, Animation> Get()
        {
            var downFalse = new Animation(180, "Sprites/Character/nami-d1");
            var downTrue = new Animation(180,
                "Sprites/Character/nami-d1",
                "Sprites/Character/nami-d2",
                "Sprites/Character/nami-d3",
                "Sprites/Character/nami-d4");

            var leftFalse = new Animation(180, "Sprites/Character/nami-l1");
            var leftTrue = new Animation(180,
                "Sprites/Character/nami-l1",
                "Sprites/Character/nami-l2",
                "Sprites/Character/nami-l3",
                "Sprites/Character/nami-l4");

            var rightFalse = new Animation(180, "Sprites/Character/nami-r1");
            var rightTrue = new Animation(180,
                "Sprites/Character/nami-r1",
                "Sprites/Character/nami-r2",
                "Sprites/Character/nami-r3",
                "Sprites/Character/nami-r4");

            var upFalse = new Animation(180, "Sprites/Character/nami-u1");
            var upTrue = new Animation(180,
                "Sprites/Character/nami-u1",
                "Sprites/Character/nami-u2",
                "Sprites/Character/nami-u3",
                "Sprites/Character/nami-u4");
            var animStates = new Dictionary<string, Animation>
            {
                { "Down-False", downFalse },
                { "Down-True", downTrue },
                { "Left-False", leftFalse },
                { "Left-True", leftTrue },
                { "Right-False", rightFalse },
                { "Right-True", rightTrue },
                { "Up-False", upFalse },
                { "Up-True", upTrue },
            };

            return animStates;
        }
    }
}
