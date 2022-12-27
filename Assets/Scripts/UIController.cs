using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    GameObject game;
    public GameObject go;
    TextMeshProUGUI sc;
    TextMeshProUGUI sp;
    int score = 0;
    float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
            sc = GameObject.Find("UIOverlay/Score").GetComponent<TextMeshProUGUI>();
            sp = GameObject.Find("UIOverlay/Speed").GetComponent<TextMeshProUGUI>();
            game = GameObject.Find("Game"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    

    public void UpdateScore(){
        score++;
        sc.text = "Score: " + score;
    }

    public void UpdateLength(int l){
        sp.text = "Length " + l;
    }

    public void GameOver(){
        speed = 0;
        score = 0;
        game.SetActive(false);
        go.SetActive(true);
    }
}
