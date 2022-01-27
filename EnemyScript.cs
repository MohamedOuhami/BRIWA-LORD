using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // This script controls the enemy's behavior
     /*
     1- Enemy follows the player
     2- As soon as he gets close, the enemy starts shooting
     */

     // Enemy movement

    public GameObject player;
    [SerializeField]
    protected float EnemyMovSpeed;    
    public PlayerMovement pscr;
    public LiveSystem livescr;
    public ParticleSystem enemyps;
    private void Start() {
        enemyps.Stop();
        player = GameObject.FindGameObjectWithTag("Botato");
        pscr = player.GetComponent<PlayerMovement>();
        livescr = player.GetComponent<LiveSystem>();
    }
     private void Update() {

        Vector3 playerDirection = player.transform.position - transform.position;
        float angle = Mathf.Atan2(playerDirection.y,playerDirection.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle,transform.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation,q,EnemyMovSpeed);
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position,EnemyMovSpeed * Time.deltaTime);

     }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Bullet"))
        {
            destroyenemy();
        }
        if(other.gameObject.CompareTag("Botato"))
        {
            if (pscr.isDashing == true)
            {
                destroyenemy();
            } 

        }

    }
    public void destroyenemy()
    {
        GameObject go = Instantiate(enemyps.gameObject);
        go.transform.position = this.transform.position;
        Destroy(go,2f);
        Destroy(gameObject);
    }

}
