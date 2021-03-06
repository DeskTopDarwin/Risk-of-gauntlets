using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombInventory : MonoBehaviour
{
    public UnityEvent returnBomb;

    public GameObject bombPrefabResource;
    public List<Bomb> bombsInInventory = new List<Bomb>();
    public List<Bomb> bombsPlaced;
    public int maxAmmo;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxAmmo; i++)
        {
            AddAmmo();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMaxAmmo()
    {
        maxAmmo++;
        AddAmmo();
    }

    private void AddAmmo()
    {
        GameObject newBomb = Instantiate(bombPrefabResource);
        Bomb bomb = newBomb.GetComponent<Bomb>();
        bomb.gameObject.SetActive(false);
        bombsInInventory.Add(bomb);
        bomb.bombInventory = this;
    }

    public void DropBomb(bool dropBomb)
    {
        if (dropBomb && bombsInInventory.Count > 0)
        {
            bombsInInventory[bombsInInventory.Count - 1].gameObject.transform.position = transform.position;
            bombsInInventory[bombsInInventory.Count - 1].gameObject.SetActive(true);
            bombsPlaced.Add(bombsInInventory[bombsInInventory.Count - 1]);
            bombsInInventory.Remove(bombsInInventory[bombsInInventory.Count - 1]);
        }
    }

    public void returnBombToInventory(Bomb bomb)
    {
        //if (addBomb)
        //{
        //    bombsPlaced[(bombsPlaced.Count - 1) - (bombsPlaced.Count - 1)].gameObject.SetActive(false);
        //    bombsInInventory.Add(bombsPlaced[(bombsPlaced.Count - 1) - (bombsPlaced.Count - 1)]);
        //    bombsPlaced.Remove(bombsPlaced[(bombsPlaced.Count - 1) - (bombsPlaced.Count - 1)]);
        //}
        int index = bombsPlaced.IndexOf(bomb);
        bomb.gameObject.SetActive(false);
        bombsInInventory.Add(bombsPlaced[index]);
        bombsPlaced.Remove(bomb);
        
    }
}
