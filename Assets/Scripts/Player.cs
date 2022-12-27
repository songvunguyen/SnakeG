using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class Player : MonoBehaviour
{
    int length = 1;
    float xLimit = 9.5f;
    float yLimit = 3.5f;
    Vector2 moveVal;
    Vector2 moveCoor = new Vector2(0, 0);
    Rigidbody2D rb;

    public GameObject bodyPrefab;
    public GameObject game;
    bool ate = false;
    List<Transform> body = new List<Transform>();

    public UIController ui;
    AudioSource eat;
    AudioSource go;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Moving", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() { 
        //Check to make sure that object is moving and not backtrack
        if(moveVal != Vector2.zero && moveCoor != -moveVal && (moveVal.x == 0 || moveVal.y == 0)){
            moveCoor = moveVal;
        }
    }

    void OnMove(InputValue value){
        moveVal = value.Get<Vector2>();
    }


    //Code reference from https://noobtuts.com/unity/2d-snake-game
    void Moving(){
        Vector2 pos = transform.position;
        transform.position += new Vector3(moveCoor.x, moveCoor.y, transform.position.z);

        // Ate something? Then insert new Element into gap
        if (ate) {
            // Load Prefab into the world
            GameObject g =(GameObject)Instantiate(bodyPrefab, pos, Quaternion.identity, game.transform);

            // Keep track of it in our tail list
            body.Insert(0, g.transform);

            // Reset the flag
            ate = false;
        }
        // Do we have a Tail?
        else if (body.Count > 0) {
            // Move last Tail Element to where the Head was
            body.Last().position = pos;

            // Add to front of list, remove from the back
            body.Insert(0, body.Last());
            body.RemoveAt(body.Count-1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Prey"){
            ate = true;
            ui.UpdateScore();
            ui.UpdateLength(++length);
            other.gameObject.GetComponent<AudioSource>().Play();
            other.gameObject.transform.position = new Vector2(Random.Range(-xLimit,xLimit), Random.Range(-yLimit,yLimit));
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        ui.GetComponent<AudioSource>().Play();
        ui.GameOver();
    }

}
