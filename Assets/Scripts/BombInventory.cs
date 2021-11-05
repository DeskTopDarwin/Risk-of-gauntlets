using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInventory : MonoBehaviour
{
    public GameObject bombPrefabResource;
    public List<Bomb> bombsInInventory = new List<Bomb>();
    public List<Bomb> bombsPlaced;
    public int maxAmmo;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxAmmo; i++)
        {
            AddMaxAmmo();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMaxAmmo()
    {
        GameObject newBomb = Instantiate(bombPrefabResource);
        Bomb bomb = newBomb.GetComponent<Bomb>();
        bomb.gameObject.SetActive(false);
        bombsInInventory.Add(bomb);
    }

    public void DropBomb(bool dropBomb)
    {
        if (dropBomb && bombsInInventory.Count > 0)
        {
            Debug.Log("drop bomb");

            bombsInInventory[bombsInInventory.Count - 1].gameObject.transform.position = transform.position;
            bombsInInventory[bombsInInventory.Count - 1].gameObject.SetActive(true);
            bombsPlaced.Add(bombsInInventory[bombsInInventory.Count - 1]);
            bombsInInventory.Remove(bombsInInventory[bombsInInventory.Count - 1]);
        }
    }

    public void addBomb(bool addBomb)
    {
        if (addBomb)
        {
            bombsPlaced[(bombsPlaced.Count - 1) - (bombsPlaced.Count - 1)].gameObject.SetActive(false);
            bombsInInventory.Add(bombsPlaced[(bombsPlaced.Count - 1) - (bombsPlaced.Count - 1)]);
            bombsPlaced.Remove(bombsPlaced[(bombsPlaced.Count - 1) - (bombsPlaced.Count - 1)]);
        }
    }
}
