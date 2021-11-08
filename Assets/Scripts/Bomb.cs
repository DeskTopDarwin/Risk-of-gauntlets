using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


enum BombState
{
    INACTIVE,
    COUNTDOWN,
    EXPLOSION
}

public class Bomb : MonoBehaviour
{

    public UnityEvent<Bomb> explosion;
    public BombInventory bombInventory;
    public float timerLenght = 3;
    public float timerEnd;
    
    Collider2D collid;
    BombState bombState;
    
    
    // Start is called before the first frame update
    void Start()
    {
        explosion.AddListener(bombInventory.returnBombToInventory);
        collid = GetComponent<BoxCollider2D>();
        bombState = BombState.INACTIVE;
    }

    void StartTimer()
    {
        timerEnd = Time.time + timerLenght;
    }

    // Update is called once per frame
    void Update()
    {
        switch (bombState)
        {
            case BombState.INACTIVE:
                if (gameObject.activeSelf)
                {
                    StartTimer();
                    bombState = BombState.COUNTDOWN;
                }

                    break;
            case BombState.COUNTDOWN:
                if (Time.time >= timerEnd)
                {
                    timerEnd = float.MaxValue;
                    bombState = BombState.EXPLOSION;
                }

                break;
            case BombState.EXPLOSION:

                collid.isTrigger = true;
                explosion?.Invoke(this);
                bombState = BombState.INACTIVE;


                break;
            default:
                break;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        collid.isTrigger = false;
    }
}
