using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveSystem : MonoBehaviour
{
   // Script controlling the player's lives
   // Upon getting hitted by an enemy, the player loses 1 heart
   // When hitted, the player becomes invincible for 3 seconds
   // The player is pushed away from the enemy

   public int livesRemaining = 5;
   protected float TempInvincibility = 3f;
   public Animator animator;
   protected bool isInvincible;
   protected bool DamageActivated = true;
   private void Start() {

       isInvincible = false;

   }

   public IEnumerator getDamage()
   {
       Debug.Log("Starting routine");
       livesRemaining--;
       isInvincible = true;
       animator.SetBool("Damaged", true);
       yield return new WaitForSeconds(3f);
       isInvincible = false;
       animator.SetBool("Damaged", false);
       Debug.Log("Finished routine");
   }

}
