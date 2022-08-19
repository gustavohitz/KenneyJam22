using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public Rigidbody2D rb2D;
    public float speed = 4f;
    public float jumpForce = 100f;
    public Medal medal;
    public string walkAnimation = "Walk";
    public Animator anim;
    private float _inputAxis;
    private float _inputVertical;

    void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update() {
        Move();
        Jump();
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
    void Jump() {
        if(Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Z)))  {
            rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            Debug.Log("Jump");
        }
    }
}
