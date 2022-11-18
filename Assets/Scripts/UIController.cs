using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    GameObject play;
    GameObject about;
    GameObject ins;
    GameObject back;
    GameObject game;
    GameObject go;
    TextMeshProUGUI sc;
    TextMeshProUGUI sp;
    int score = 0;
    float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Game"){
            sc = GameObject.Find("UIOverlay/Score").GetComponent<TextMeshProUGUI>();
            sp = GameObject.Find("UIOverlay/Speed").GetComponent<TextMeshProUGUI>();
            go = GameObject.Find("UIOverlay/GameOver");
            game = GameObject.Find("Game");
        }else if(SceneManager.GetActiveScene().name == "MainMenu"){
            play = GameObject.Find("Menu/PlayButton");
            about = GameObject.Find("Menu/About");
            ins = GameObject.Find("Menu/HowTo");
            back = GameObject.Find("Menu/Back");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        SceneManager.LoadScene("Game");
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
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

    public void GameOver(){
        speed = 0;
        score = 0;
        game.SetActive(false);
        go.SetActive(true);
    }
}
