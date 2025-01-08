using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

namespace Golf
{
    public class Stone : MonoBehaviour
    {
        public bool isAffect = false;
        public static System.Action onCollisionStone;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out Stone other))
            {
                if (!other.isAffect)
                {
                    GameEvents.CollisionStonesInvoke(collision);
                }

            }     
        }
    }  
}