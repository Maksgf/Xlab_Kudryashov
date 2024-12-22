using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZ
{
    

    public class PlayerController : MonoBehaviour
    {
        public Spawner spawner;
        public CloudController cloudController;
        public List<Refresh> villagers;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X)) 
            {
                Debug.Log("Key down x");
               spawner.Spawn();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Key down z");
                cloudController.Action();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Key down Space");
                foreach (var villager in villagers)
                {
                    villager.ChangeTool();
                }
            }
        }
    }
}