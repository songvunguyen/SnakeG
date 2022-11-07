using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    float speed = 2f;
    Vector2 moveVal;
    Rigidbody2D rb;

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
            rb.velocity = new Vector2(moveVal.x * speed, moveVal.y * speed);
        }
        
    }

    void OnMove(InputValue value){
        moveVal = value.Get<Vector2>();
    }
}
