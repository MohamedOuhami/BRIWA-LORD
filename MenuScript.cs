using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour

{
    public Animator animator;
    public void StartGame()
    {
        StartCoroutine(StartGameRoutine());
    }
    IEnumerator StartGameRoutine()
    {
        animator.SetBool("Transition",true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
