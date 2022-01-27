using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_randomization : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] box_objects;
    protected GameObject instantiatedObj;
    protected PlayerMovement playerscr;
    protected GameObject Botato;
    private void Start() {
        Botato = GameObject.FindGameObjectWithTag("Botato");
    }

     IEnumerator giveRandomItem()
    {
        int rand = Random.Range(0,2);
        instantiatedObj = (GameObject) Instantiate(box_objects[rand], transform.position,Quaternion.identity);
        Debug.Log(rand);
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Botato"))
        {
            playerscr = Botato.GetComponent<PlayerMovement>();
            if(playerscr.isDashing == true)
            {
                StartCoroutine(giveRandomItem());
            }
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(giveRandomItem());
            Destroy(other.gameObject);
        }
    }
}
