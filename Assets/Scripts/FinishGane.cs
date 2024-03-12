using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishGane : MonoBehaviour
{
    public float balls;
    public float score;
    [SerializeField] private TMP_Text winscoretext;
    [SerializeField] private TMP_Text healthtext;
    [SerializeField] private TMP_Text finishtext;
    [SerializeField] private GameObject timescreen;
    [SerializeField] private GameObject healthscreen;
    [SerializeField] private GameObject winscorescreen;
    [SerializeField] private GameObject finishscreen;


    private void Update()
    {
        if (balls < 2)
        {
            finishtext.SetText("OYUN BÝTTÝ");
            winscoretext.SetText("SKORUNUZ :" + score);
            loseclosescreens();
        }
    }

    public void decreaseball()
    {
            balls--;
            healthtext.SetText("Can :" + balls);
    }

    public void increasescore()
    {
            score++;
    }

    public void loseclosescreens()
    {
            timescreen.SetActive(false);
            healthscreen.SetActive(false); 
            winscorescreen.SetActive(true);
            finishscreen.SetActive(true);
    }
}
