using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunScript : MonoBehaviour
{
    public Transform Gun;
    public AudioSource audioscr2;
    public AudioClip gunSound;

    [SerializeField]
    protected Transform gunSpot;
    public int Ammo = 0;
    public GameObject Bullet;
    public float bulletLifeSpan;
    private GameObject instantiatedbullet;
    public GameObject ShootButton;

    private void Start() {
        Gun = gameObject.transform.GetChild(0);
        Gun.gameObject.SetActive(false);
    }

    private void Update() {

        if (Ammo > 0)
        {
            ShootButton.SetActive(true);
            Gun.gameObject.SetActive(true);
        } else
        {
            ShootButton.SetActive(false);
            Gun.gameObject.SetActive(false);
        }

        bulletLifeSpan -= Time.deltaTime;
        if( bulletLifeSpan <= 0)
        {
            Destroy(instantiatedbullet);
        }
    }
    public void Shoot()
    {
        if(Ammo > 0)
        {
            bulletLifeSpan = 0.1f;
            instantiatedbullet = (GameObject) Instantiate(Bullet,gunSpot.position,transform.rotation);
            Ammo --;
            audioscr2.clip = gunSound;
            audioscr2.Play();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Recharge"))
        {
            Ammo += 5;
            Destroy(other.gameObject);
        }
    }
}
