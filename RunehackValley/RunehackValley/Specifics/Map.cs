using System;
using Microsoft.Xna.Framework;
using RunehackValley.Character;

namespace RunehackValley.Specifics
{
    public class Map : CharSpace
    {
        private readonly byte[,] openSpaces = new byte[,]
        {
            { 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,  1 },

            { 1,  0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0,  1 },
            { 1,  1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0,  1 },
            { 1,  0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0,  1 },
            { 1,  0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0,  1 },
            { 1,  1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0,  1 },
            { 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0,  1 },
            { 1,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  1 },
            { 1,  0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  1 },
            { 1,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0,  1 },
            { 1,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0,  1 },
            { 1,  0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0,  1 },
            { 1,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0,  1 },
            { 1,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0,  1 },
            { 1,  0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0,  1 },
            { 1,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0,  1 },
            { 1,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0,  1 },
            { 1,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0,  1 },
            { 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0,  1 },

            { 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,  1 },
        };

        private Vector2 previousPosition;

        public Map(Vector2 startingPosition)
        {
            previousPosition = startingPosition;
        }

        public Vector2 GetOffsetAfterMove(Vector2 moveBy)
        {
            int startX = GetXCoordinate(previousPosition);
            int startY = GetYCoordinate(previousPosition);
            if (moveBy == Vector2.Zero)
                return previousPosition;

            while (Math.Abs(moveBy.X) > 0.99 || Math.Abs(moveBy.Y) > 0.99)
            {
                var xSign = Math.Sign(moveBy.X);
                if (Math.Abs(moveBy.X) > 0.99)
                {
                    moveBy.X -= xSign;
                    previousPosition.X += xSign;
                    if (!IsValid(previousPosition))
                    {
                        moveBy.X = 0;
                        previousPosition.X -= xSign;
                    }
                }

                var ySign = Math.Sign(moveBy.Y);
                if (Math.Abs(moveBy.Y) > 0.99)
                {
                    moveBy.Y -= ySign;
                    previousPosition.Y += ySign;
                    if (!IsValid(previousPosition))
                    {
                        moveBy.Y = 0;
                        previousPosition.Y -= ySign;
                    }
                }
            }
            int endX = GetXCoordinate(previousPosition);
            int endY = GetYCoordinate(previousPosition);
            return previousPosition;
        }

        private bool IsValid(Vector2 loc)
        {
            return openSpaces[GetXCoordinate(loc), GetYCoordinate(loc)] == 0;
        }

        private int GetXCoordinate(Vector2 loc)
        {
            return (int) (Math.Ceiling(loc.X/64) + 1);
        }

        private int GetYCoordinate(Vector2 loc)
        {
            return (int)(Math.Ceiling(loc.Y / 64) + 1);
        }
    }
}
