using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject play;
    public GameObject about;
    public GameObject ins;
    public GameObject back;
    TextMeshProUGUI sc;
    TextMeshProUGUI sp;
    int score = 0;
    float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        sc = GameObject.Find("UIOverlay/Score").GetComponent<TextMeshProUGUI>();
        sp = GameObject.Find("UIOverlay/Speed").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        SceneManager.LoadScene("Game");
    }

    public void About(){
        play.SetActive(false);
        about.SetActive(false);
        ins.SetActive(true);
        back.SetActive(true);
    }

    public void Back(){
        play.SetActive(true);
        about.SetActive(true);
        ins.SetActive(false);
        back.SetActive(false);
    }

    public void UpdateScroe(){
        score++;
        sc.text = "Score: " + score;
    }

    public void UpdateSpeed(){
        speed += 0.1f;
        sp.text = "Speed: +" + Math.Round(speed,1);
    }
}
