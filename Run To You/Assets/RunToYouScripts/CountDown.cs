using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class CountDown : MonoBehaviour {

    // Use this for initialization
    public float timeLeft = 300.0f;
    public bool stop = false;

    private float minutes;
    private float seconds;
    GameObject thePlayer;
    private CharControl control;
    Text text;
    public void Start()
    {
        text = GetComponent<Text>();
        thePlayer = GameObject.Find("BoyCharacter");
        control = thePlayer.GetComponent<CharControl>();
    }
    public void startTimer(float from)
    {
        stop = false;
        timeLeft = from;
        Update();
        StartCoroutine(updateCoroutine());
    }

    void Update()
    {
        //if (stop) return;
        if (!control.iWin)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            text.color = Color.green;
        }

        minutes = Mathf.Floor(timeLeft / 60);
        seconds = timeLeft % 60;
        if (seconds > 59) seconds = 59;
        if (minutes < 0)
        {
            //stop = true;
            minutes = 0;
            seconds = 0;
        }

        

        if (!control.iWin)
        {
            text.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        }
        else
        {
            text.text = string.Format("{0:0}:{1:00}", minutes, seconds) + " You Win!";
        }
        if (timeLeft <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        
        //        fraction = (timeLeft * 100) % 100;
    }

    private IEnumerator updateCoroutine()
    {
        while (!stop)
        {
            text.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
