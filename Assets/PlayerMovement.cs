using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float fowardForce = 2000f;
    public float sidewaysForce = 500f;

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0,0, fowardForce * Time.deltaTime);

        if (Input.GetKey("d")){
            rb.AddForce(sidewaysForce * Time.deltaTime, 0,0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a")){
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0,0, ForceMode.VelocityChange); 
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "Obstacle")
        {
            sidewaysForce = 0f;
            fowardForce = 0f;
            FindObjectOfType<GameManager>().EndGame();
        }


        if (coll.collider.tag == "End")
        {
            Debug.Log("LEVEL COMPLETE");
            FindObjectOfType<GameManager>().LevelDone();           
        }
    }
}
