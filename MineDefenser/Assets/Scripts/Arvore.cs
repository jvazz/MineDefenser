using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arvore : MonoBehaviour
{
    int vida = 5;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(player.GetComponent<Player>().inventario == "machado")
        {
            vida--;
            if(vida == 0)
            {
                vida = 5;
                player.GetComponent<Player>().madeira += 3;
                gameObject.SetActive(false);
                transform.parent.GetComponent<Floresta>().arvoresDesativadas.Add(gameObject);
            }
        }
    }
}
