using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
   GameController m_game; 

   // Use this for initialization
   void Start()
   {
      m_game = GameController.GetInstance();
      if (m_game != null) {
         m_game.EnemyCount++;
      }
   }

   void OnDestroy()
   {
      if (m_game != null) {
         m_game.EnemyCount--;
      }
   }
}

