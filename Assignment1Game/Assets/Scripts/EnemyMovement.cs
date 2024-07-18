using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0; 
    public float distanceCap;

    public Rigidbody rb;

    Vector3 direction;
    Vector3 pastPos;

    float distanceTravelled;
    // Start is called before the first frame update
    void Start()
    {
        pastPos = transform.position;
        distanceTravelled = 0;
        direction = new Vector3(1,0,0);
    }

    // Update is called once per frame
    void Update()
    {   
        updateDistance();

        if(Mathf.Abs(distanceTravelled) > distanceCap && (distanceTravelled/Mathf.Abs(distanceTravelled)) == direction.x){
            distanceTravelled = distanceCap * direction.x; 
            direction *= -1;
               
        }

        rb.velocity = new Vector3(direction.x * speed, rb.velocity.y,0);
    }

    public void updateDistance(){
        distanceTravelled = (this.transform.position - pastPos).x;
    }
}
