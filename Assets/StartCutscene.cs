using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public Animator animator;
    public static bool playedCutscene1 = false;
    public static bool isCutsceneOn = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<PlayerController>();
        if (player == null)
            return;
        
        isCutsceneOn = true;

        if (!playedCutscene1)
        {
            playedCutscene1 = true;
            animator.SetBool("cutscene1", true);
            Invoke(nameof(StopCutscene1), 3f);
        }
    }

    private void StopCutscene1()
    {
        isCutsceneOn = false;
        animator.SetBool("cutscene1", false);
    }  
}
