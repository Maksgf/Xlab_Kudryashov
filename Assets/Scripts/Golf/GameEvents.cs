using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public static class GameEvents 
    {
        public static System.Action onCollisionStone;
        public static System.Action OnStickHit;

        public static void CollisionStonesInvoke(Collision collision)
        {
            onCollisionStone?.Invoke();
        }

        public static void StickHit()
        {
            OnStickHit?.Invoke();

        }
    }
}
