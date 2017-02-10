using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace RunehackValley.Character
{
    public class Movement
    {
        private readonly Distance _distance;
        private readonly HorizontalDirection _hDir;
        private readonly VerticalDirection _vDir;

        public Movement(Distance distance, HorizontalDirection hDir, VerticalDirection vDir)
        {
            _distance = distance;
            _hDir = hDir;
            _vDir = vDir;
        }

        public Vector2 GetDelta()
        {
            var dist = _distance.Get();
            return new Vector2(GetXDirection() * dist, GetYDirection() * dist);
        }

        private float GetXDirection()
        {
            switch (_hDir)
            {
                case HorizontalDirection.Left:
                    return -1.0f;
                case HorizontalDirection.Right:
                    return 1.0f;
                default:
                    return 0;
            }
        }

        private float GetYDirection()
        {
            switch (_vDir)
            {
                case VerticalDirection.Down:
                    return 1.0f;
                case VerticalDirection.Up:
                    return -1.0f;
                default:
                    return 0;
            }
        }
    }
}
