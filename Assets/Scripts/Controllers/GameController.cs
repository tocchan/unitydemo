using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Making this serializable allows the property window to show it up;
[System.Serializable]
public struct AsteroidSpawns
{
   public int small;
   public int medium;
   public int large;
}

public class GameController : MonoBehaviour
{
   public List<AsteroidSpawns> Levels;
   public GameObject PlayerObject;
   public GameObject SmallAsteroid;
   public GameObject MediumAsteroid;
   public GameObject LargeAsteroid;

   [ReadOnly]
   public int Level = 0;

   [ReadOnly]
   public float EnemyCount = 0;

   [ReadOnly]
   public float PlayerCount = 0; 

   private static GameController m_instance = null;

   void Awake()
   {
      m_instance = this;
   }

   // Use this for initialization
   void Start()
   {
      
   }
   
   // Update is called once per frame
   void Update()
   {
      if (EnemyCount == 0) {
         SpawnNextWave();
      }

      if (PlayerCount == 0) {
         RespawnPlayer();
      }
   }

   void SpawnNextWave()
   {
      ++EnemyCount; // use this to prevent it from constantly starting this coroutine - just remember
                    // to correct for this when you're done;
      StartCoroutine( SpawnNextWaveWork() );
   }

   Vector3 GetSpawnPosition( Bounds b )
   {
      // Get the screen bounds, and go a little farther, we're going to start at one of these two points, and then spawn along 
      // either the horizontal or veritcle location from that point.
      Vector3 min = b.min - new Vector3( 4.0f, 4.0f ); 
      Vector3 max = b.max + new Vector3( 4.0f, 4.0f );
      float height = max.y - min.y;
      float width = max.x - min.x;

      Vector3 start_pos;
      Vector3 offset;

      
      if (MathUtil.CoinFlip()) {
         offset = new Vector3( width, 0.0f, 0.0f );
      } else {
         offset = new Vector3( 0.0f, height, 0.0f );
      }

      // scale it between max and 0
      offset *= Random.value;

      // get a start position, and flip the extents if we pick the top right.
      if (MathUtil.CoinFlip()) {
         start_pos = min;
      } else {
         start_pos = max;
         offset = -offset; 
      }

      Debug.Log( "Start: " + start_pos + ", Offset: " + offset );
      return start_pos + offset;
   }

   // Spawn all the enemies in the next wave;
   IEnumerator SpawnNextWaveWork()
   {
      if (Levels.Count == 0) {
         Debug.LogError( "No level information specified." );
         yield break;
      }

      int index = Mathf.Min( Level, Levels.Count - 1 );
      Level++;

      yield return new WaitForSeconds(4.0f);

      Bounds screen = ScreenUtil.GetVisibleBounds();

      AsteroidSpawns spawn = Levels[index];
      for (uint i = 0; i < spawn.small; ++i) {
         Vector3 pos = GetSpawnPosition( screen );
         Debug.Log( "Spawning at: " + pos.x + ", " + pos.y + ", " + pos.z );
         GameObject.Instantiate( SmallAsteroid, pos, Quaternion.identity, null );
      }

      for (uint i = 0; i < spawn.medium; ++i) {
         Vector3 pos = GetSpawnPosition( screen );
         GameObject.Instantiate( MediumAsteroid, pos, Quaternion.identity, null );
      }

      for (uint i = 0; i < spawn.large; ++i) {
         Vector3 pos = GetSpawnPosition( screen );
         GameObject.Instantiate( LargeAsteroid, pos, Quaternion.identity, null );
      }

      // "unlock" - so we can spawn next wave again [could have used a bool]
      --EnemyCount; 
   }

   void RespawnPlayer()
   {
      PlayerCount++; // prevent this from "double entering"
                     // could have also spawned this off a "death" event, but this works well enough
      StartCoroutine( SpawnPlayerWork() );
   }

   IEnumerator SpawnPlayerWork()
   {
      yield return new WaitForSeconds(2.0f);

      // wait until the space is clear;
      Collider2D[] objects = Physics2D.OverlapCircleAll( Vector2.zero, 2.0f );
      while (objects.Length > 0) {
         yield return null; // wait till next frame;
         objects = Physics2D.OverlapCircleAll( Vector2.zero, 2.0f );
      }

      GameObject.Instantiate( PlayerObject );
      PlayerCount--; // "unlock" the player spawning coroutine - could have also used a bool
   }

   void OnDestroy()
   {
      m_instance = null;
   }

   public static GameController GetInstance()
   {
      return m_instance;
   }
}

