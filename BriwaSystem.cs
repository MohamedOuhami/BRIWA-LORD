using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriwaSystem : MonoBehaviour
{
    
    // Briwas are the game's coinbase

    public int briwacount = 0;

    private void Update() {
        
        Debug.Log(briwacount);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Botato"))
        {
            briwacount += 1;
            Destroy(gameObject);
            
        }
    }
}
