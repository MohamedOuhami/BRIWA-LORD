using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Script controls the player's movement
    /*
    1- The joystick controls the rotation of the player
    2- The player can only moves directly in the view direction 
    */
    public AudioSource audioscr2;
    public AudioClip dashSound,BriwaSound;

    public Joystick joystick;
    public bool isDashing;
    public GameObject Enemy;
    public EnemyScript enemyscr;
    public LiveSystem livescr;

    public Vector2 joyDirection;
    public Rigidbody2D rb;
    [SerializeField]
    public float moveSpeed;
    public int briwaCount = 0;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        
    }


    private void Update() {
        // Movement
        joyDirection = new Vector2(joystick.Horizontal,joystick.Vertical);

        rb.velocity = joyDirection * moveSpeed;

        // Rotation
        float angle = Mathf.Atan2(joyDirection.y,joyDirection.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(transform.forward * angle);
        if(Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(Dash());
            audioscr2.clip = dashSound;
            audioscr2.Play();
        }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Briwa"))
        {
            briwaCount++;
            Destroy(other.gameObject);
            audioscr2.clip = BriwaSound;
            audioscr2.Play();
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(isDashing == false)
            {
                Enemy = other.gameObject;
                enemyscr = Enemy.GetComponent<EnemyScript>();
                enemyscr.destroyenemy();
                livescr = this.GetComponent<LiveSystem>();
                StartCoroutine(livescr.getDamage());    
            }
            
        }
    }
    IEnumerator Dash()
    {
        moveSpeed *= 3;
        isDashing = true;
        yield return new WaitForSeconds(0.5f);
        moveSpeed /= 3;
        isDashing = false;
        yield return new WaitForSeconds(1f);
    }
    public void Dashing()
    {
        StartCoroutine(Dash());
    }

}
