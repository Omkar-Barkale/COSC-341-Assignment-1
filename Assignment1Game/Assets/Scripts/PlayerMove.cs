using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{   
    public int score;

    public TMP_Text txt;

    public TMP_Text ui;

    public float moveSpeed = 2f;
    public float jumpForce = 10f;
    private bool grounded;
    public LayerMask ground;
    public GameObject feet;

    public GameManager gm;

    public Rigidbody rb;

    bool gameover;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(grounded);

        if(Input.GetKeyDown(KeyCode.Space) && grounded){
            rb.AddForce(new Vector3(0,1,0)*jumpForce, ForceMode.Impulse);
        }

        if(rb.velocity.y < 0 || !Input.GetKey(KeyCode.Space))
            rb.velocity += Vector3.up*Physics.gravity.y *(2.5f-1) * Time.deltaTime;

        rb.velocity = new Vector3(moveSpeed*Input.GetAxisRaw("Horizontal"), rb.velocity.y, 0);
    }

    public  void FixedUpdate() {
        grounded = checkGround();
    }

    public bool checkGround(){
        return Physics.CheckSphere(feet.transform.position, 1, ground);
    }

    void OnCollisionEnter(Collision other) {
        

        if(other.gameObject.CompareTag("Coin")){
            score ++;
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Mob")){
            score--;
            Destroy(other.gameObject);
            if(score< 0 && !gameover){
                gameover = true;
                gm.gameOver();
                Destroy(this.gameObject); 
            }
        }
        if(other.gameObject.CompareTag("Goal") && !gameover){
            gameover = true;
            gm.gameOver();
            Destroy(this.gameObject);
        }
        txt.text = score + "";
        ui.text = "Score: " + score;
    }
     

    public void die(){
        score = 0;
            gameover = true;
            gm.gameOver();
            Destroy(this.gameObject);
            txt.text = score + "";
    }

}
