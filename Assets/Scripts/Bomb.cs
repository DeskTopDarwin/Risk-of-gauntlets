using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


enum BombState
{
    Waiting,
    Exploding
}

public class Bomb : MonoBehaviour
{

    public UnityEvent<Bomb> explosion;
    public BombInventory bombInventory;
    
    Collider2D collid;
    //BombState bombState;
    float countDown = 3;
    
    
    // Start is called before the first frame update
    void Start()
    {
        explosion.AddListener(bombInventory.returnBombToInventory);
        collid = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //switch (bombState)
        //{
        //    case BombState.Waiting:
        //        
        //        break;
        //    case BombState.Exploding:
        //
        //        break;
        //    default:
        //        break;
        //}


        if(gameObject.activeSelf)
        {
            countDown -= Time.deltaTime;
            if(countDown <= 0)
            {
                explosion?.Invoke(this);
                collid.isTrigger = true;
                countDown = 3;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        collid.isTrigger = false;
    }
}
