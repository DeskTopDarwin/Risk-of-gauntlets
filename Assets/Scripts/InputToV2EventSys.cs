using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputToV2EventSys : MonoBehaviour
{
    public UnityEvent<Vector2> dirPressed;
    public UnityEvent dropBombPressed;


    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode space = KeyCode.Space;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //movement
        Vector2 toSend = new Vector2();
        if (Input.GetKey(up))
            toSend.y = 1;
        else if (Input.GetKey(down))
            toSend.y = -1;

        if (Input.GetKey(left))
            toSend.x = -1;
        else if (Input.GetKey(right))
            toSend.x = 1;

        dirPressed.Invoke(toSend);

        //bombs
        
        if (Input.GetKeyDown(space))
        {
            dropBombPressed.Invoke();
        }

    }
}
