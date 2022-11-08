using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject play;
    public GameObject about;
    public GameObject ins;
    public GameObject back;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
