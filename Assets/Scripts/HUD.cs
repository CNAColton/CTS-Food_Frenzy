using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public Level level;

    public TextMeshProUGUI remainingText;
    public TextMeshProUGUI remainingSubtext;
    public TextMeshProUGUI targetText;
    public TextMeshProUGUI targetSubtext;
    public TextMeshProUGUI scoreText;

    public Image[] stars;

    private int starIndex;
    private bool isGameOver;
    
    private void Start()
    {
        UpdateStars();
    }

    public void UpdateStars()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i == starIndex)
            {
                stars[i].enabled = true;
            }
            else
            {
                stars[i].enabled = false;
            }
        }
    
    }
        


}
