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

    bool ate = false;
    //Snake body prefab
    public GameObject bodyPrefab;
    //Keep track of position of the body
    List<Transform> body = new List<Transform>();

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
            Vector2 prevPos = transform.position;
            rb.velocity = new Vector2(moveVal.x * speed, moveVal.y * speed);
            bodyMove(prevPos);
        }  
    }

    void OnMove(InputValue value){
        moveVal = value.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Prey"){
            ui.UpdateScore();
            ui.UpdateSpeed();
            speed += 0.1f;
            other.gameObject.transform.position = new Vector2(Random.Range(-xLimit,xLimit), Random.Range(-yLimit,yLimit));
            ate = true;
        }
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     ui.GameOver();
    // }

    private void bodyMove(Vector2 pos){
        if(ate){
            // Load Prefab into the world
            GameObject g =(GameObject)Instantiate(bodyPrefab, transform.position - transform.forward, Quaternion.identity);

            // Keep track of it in our tail list
            body.Insert(0, g.transform);
            ate = false;
        }
        // Do we have a Tail?
        else if (body.Count > 0) {
            // Move last Tail Element to where the Head was
            body.Last().position = transform.position - transform.forward;

            // Add to front of list, remove from the back
            body.Insert(0, body.Last());
            body.RemoveAt(body.Count-1);
        }
    }

}
