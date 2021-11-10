using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   //public void movement(KeyCode keyCode)
   //{
   //    //UpDown
   //    if (keyCode == KeyCode.W)
   //    {
   //        rb.velocity = new Vector2(0, speed);
   //    }
   //    else if (keyCode == KeyCode.S)
   //    {
   //        rb.velocity = new Vector2(0, -speed);
   //    }
   //    //LeftRigth
   //    if(keyCode == KeyCode.A)
   //    {
   //        rb.velocity = new Vector2(-speed, 0);
   //    }
   //    else if(keyCode == KeyCode.D)
   //    {
   //        rb.velocity = new Vector2(speed, 0);
   //    }
   //    
   //}

    public void movement(Vector2 direction)
    { 
        rb.velocity = new Vector2(0, 0);
        //UpDown
        if (direction.y > 0.01f)
        {
            rb.velocity = new Vector2(0, direction.y * speed);
        }
        else if (direction.y < -0.01f) 
        {
            rb.velocity = new Vector2(0, direction.y * speed);
        }
        //LeftRight
        if (direction.x < -0.01f) 
        {
            rb.velocity = new Vector2(direction.x *speed, 0);
        }
        else if (direction.x > 0.01f) 
        {
            rb.velocity = new Vector2(direction.x * speed, 0);
        }
    }
}
