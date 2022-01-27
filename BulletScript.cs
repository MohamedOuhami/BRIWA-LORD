using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    protected float bulletSpeed;
    public GameObject Botato;
    Vector3 bulletDir;

    public Rigidbody2D rb;
    private void Start() {
        // Getting the looking Direction
        Botato = GameObject.FindGameObjectWithTag("Botato");
        bulletDir = Botato.GetComponent<PlayerMovement>().joyDirection;
    }
    
    void Update()
    {
        if (bulletDir == Vector3.zero)
        {
            transform.position += new Vector3(1,0,0);
        }
        else { transform.position += bulletDir ; }
    }

}
