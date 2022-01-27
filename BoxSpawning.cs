using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawning : MonoBehaviour
{
    public GameObject Box;
    public GameObject[] spawnlists;
 
      void Start(){
        InvokeRepeating("SpawnObject", 0, 30f);
      }
 
      void SpawnObject(){
        int rand = Random.Range(0,spawnlists.Length);
        Instantiate(Box, spawnlists[rand].transform.position, Quaternion.identity);         
        }
}
