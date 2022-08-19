using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public Rigidbody2D rb2D;
    public float speed = 4f;
    public string walkAnimation = "Walk";
    public Animator anim;
    private float _inputAxis;
    private float _inputVertical;

    void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update() {
        Move();
    }

    void FixedUpdate() {
        rb2D.velocity = new Vector2(_inputAxis * speed, _inputVertical * speed);
    }

    void Move() {
        _inputAxis = Input.GetAxis("Horizontal");
        _inputVertical = Input.GetAxis("Vertical");
        if(_inputAxis > 0) {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        
        if(_inputAxis < 0) {
            transform.eulerAngles = new Vector2(0f, 180f);
        }

        if(Input.GetAxis("Horizontal") != 0) {
            anim.SetBool(walkAnimation, true);
        }
        else {
            anim.SetBool(walkAnimation, false);
        }
    }

}
