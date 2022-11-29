using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class Player : MonoBehaviour
{
    float speed = 2f;
    float xLimit = 9.5f;
    float yLimit = 3.5f;
    Vector2 moveVal;
    Rigidbody2D rb;
    public UIController ui;

    // bool ate = false;
    //Snake body prefab
    // public GameObject bodyPrefab;
    // //Keep track of position of the body
    // List<GameObject> body = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(moveVal != Vector2.zero){
            // bodyMove(rb.velocity);
            rb.velocity = new Vector2(moveVal.x * speed, moveVal.y * speed); 
        }  
    }

    void OnMove(InputValue value){
        moveVal = value.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Prey"){
            ui.UpdateScore();
            ui.UpdateSpeed();
            speed += 0.5f;
            other.gameObject.transform.position = new Vector2(Random.Range(-xLimit,xLimit), Random.Range(-yLimit,yLimit));
            // ate = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        ui.GameOver();
    }

    // private void bodyMove(Vector2 pos){
    //     if(ate){
    //         GameObject g;
    //         if(body.Count == 0){
    //             g =(GameObject)Instantiate(bodyPrefab, transform.position, Quaternion.identity);
    //         }else{
    //             GameObject bodyLast = body.Last();
    //             // Load Prefab into the world
    //             g =(GameObject)Instantiate(bodyPrefab, bodyLast.transform.position - bodyLast.transform.forward, Quaternion.identity);
    //         }
    
    //         // Keep track of it in our tail list
    //         body.Insert(0, g);
    //         ate = false;
    //     }
    //     // Do we have a Tail?
    //     else if (body.Count > 0) {
    //         Vector2 v;
    //         foreach (GameObject g in body)
    //         {
    //             v = g.GetComponent<Rigidbody2D>().velocity;
    //             g.GetComponent<Rigidbody2D>().velocity = pos;
    //             pos = v;
    //         }
    //         // Move last Tail Element to where the Head was
            
    //     }
    // }

}
