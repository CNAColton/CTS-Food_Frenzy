using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagment;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject screenParent; 
    public GameObject scoreParent; 
    public Text loseText; 
    public Text scoreText; 
    public Image[] stars;
    private Animator animator;

    private void start()
    {
        screenParent.SetActive(false);
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = false;
        }

        animator = GetComponent<Animator>();
    }

    public void ShowLose()
    {
        screenParent.SetActive(true);
        scoreParent.SetActive(true);
        LoseText.enabled = true;

        if (animator)
        {
            animator.Play("GameOverDisplay");
        }
    }

    public void ShowWin(int score, int starCount)
    {
        screenParent.SetActive(true);
        scoreParent.SetActive(true); 
        loseText.enabled = false; 
        scoreText.text = score.ToString(); 
        scoreText.enabled = false; 
     if (animator) 
     { 
         animator.Play("GameOverShow"); 
    
    }
    }
}
