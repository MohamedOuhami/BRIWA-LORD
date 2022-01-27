using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemies : MonoBehaviour
{
    // prefabs to instantiate
      public GameObject Enemy;
      public GameObject[] spawnlists;
 
      void Start(){
        InvokeRepeating("SpawnObject", 0, 1f);
      }
 
      void SpawnObject(){
            int rand = Random.Range(0,spawnlists.Length);
            Instantiate(Enemy, spawnlists[rand].transform.position, Quaternion.identity);         
            }
} 
