using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject screenParent; 
    public GameObject scoreParent; 
    public TMP_Text loseText; 
    public TMP_Text scoreText; 
    public Image[] stars;
    private Animator animator;

    void Start()
    {
        if (screenParent != null)
        {
            screenParent.SetActive(false);
            Debug.Log("Game over screen deactivated successfully.");
        }
        else
        {
            Debug.LogError("screenParent is null. Assign the GameObject in the Inspector!");
        }
    
        for (int i = 0; i < stars.Length; i++)
        {
            if (stars[i] != null)
                stars[i].enabled = false;
        }

        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.LogError("Animator component is missing on this GameObject.");
}


    public void ShowLose()
    {
        screenParent.SetActive(true);
        scoreParent.SetActive(false);
        loseText.enabled = true;

        if (animator)
        {
            animator.Play("GameOverShow");
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

        StartCoroutine(ShowWinCoroutine(starCount));
    }

        private IEnumerator ShowWinCoroutine(int starCount)
        {
            yield return new WaitForSeconds(0.5f);

            if(starCount < stars.Length)
            {
                for(int i = 0; i <= starCount; i++)
                {
                    stars[i].enabled = true;
                    if (i > 0) {
                        stars[i-1].enabled = false;
                    }
                    yield return new WaitForSeconds(0.5f);
                }
            }

            scoreText.enabled = true;
        }

        public void OnReplayClicked ()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void OnDoneClicked ()
        {
            SceneManager.LoadScene("LevelSelect");
        }
}
