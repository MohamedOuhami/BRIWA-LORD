using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    // Script controlling the different UI elements

    // Lives system
    public GameObject Botato;
    public int minutes,seconds;
    public float timer;
    public TextMeshProUGUI livestext;
    public TextMeshProUGUI ammotext;
    public TextMeshProUGUI briwatext;
    public TextMeshProUGUI timertext;
    public GameObject gameUI,DeathUI;
    public AudioSource audiosrc;
    public AudioClip[] BotatoMusic;

    LiveSystem livesscr ;
    GunScript gunscr;
    PlayerMovement playerscr;

    private void Start() {
        livesscr = Botato.GetComponent<LiveSystem>();
        gunscr = Botato.GetComponent<GunScript>();
        playerscr = Botato.GetComponent<PlayerMovement>();
        PlayMusic();
    }
    

    private void Update() {

        livestext.text = " X" + livesscr.livesRemaining.ToString();
        ammotext.text = " X" + gunscr.Ammo.ToString();
        briwatext.text = " X" + playerscr.briwaCount.ToString();
        // Timer :
        timer += Time.deltaTime;
        minutes = Mathf.FloorToInt(timer/60);
        seconds = Mathf.FloorToInt(timer%60);
        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (livesscr.livesRemaining == 0)
        {
            Time.timeScale = 0;
            gameUI.SetActive(false);
            DeathUI.SetActive(true);
        } else {
            Time.timeScale = 1;
            gameUI.SetActive(true);
            DeathUI.SetActive(false);
        }
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayMusic()
    {
        int rand = Random.Range(0,BotatoMusic.Length);
        audiosrc.clip = BotatoMusic[rand];
        audiosrc.Play();
    }
}
