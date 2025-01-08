using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using static Generic;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public SpawnerStone spawner;
        public float delayMax = 2F;
        public float delayMin = 0.5F;
        public float delayStep = 0.1F;

        public float m_delay = 0.5F;

        public int score = 0;
        public int highscore = 0;


        private float m_lastSpawnedTime = 0;

        private List<GameObject> m_stone = new List<GameObject>(16);
     
           
        private void Start()
        {
            m_lastSpawnedTime = Time.time;
            Stone.onCollisionStone += GameOver;
        }
        private void OnStickHit()
        {
            score++;
            highscore = Mathf.Max(highscore, score);
            Debug.Log($"score: {score} - highscore: {highscore}");
        }


        private void OnEnable()
        {
            GameEvents.onCollisionStone += GameOver;
           score = 0;
        }

        private void OnDisable()
        {
            GameEvents.onCollisionStone -= GameOver;
            
        }

        
        private void GameOver() 
        {
            Debug.Log("GameOver!!");
            enabled = false;
        }

        public void ClearStones()
        {

            foreach (var stone in m_stone) 
            {
                Destroy(stone);
            }
            m_stone.Clear();
        }

        public void RefreshDelay()
        {
            m_delay = UnityEngine.Random.Range(delayMin, delayMax);
            delayMax = Mathf.Max(delayMin, delayMax - delayStep);
        }


        private void Update()
        {
            if (Time.time >= m_lastSpawnedTime + m_delay)
            {
                var stone = spawner.Spawn();
                m_stone.Add(stone);
                m_lastSpawnedTime = Time.time;
                RefreshDelay();
            }
            
        }   
    }
}
