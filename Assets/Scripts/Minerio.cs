using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerio : MonoBehaviour
{
    int vida = 5;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(player.inventario == "picareta")
        {
            if(gameObject.name.Contains("Diamante"))
            {
                if(player.nivelPicareta >= 3)
                {
                    vida -= player.nivelPicareta;
                }
            }else
            {
                vida -= player.nivelPicareta;
            }
            if(vida <= 0)
            {
                vida = 5;
                gameObject.SetActive(false);
                transform.parent.GetComponent<Minerios>().mineriosDesativados.Add(gameObject);

                if(gameObject.name.Contains("Carvao"))
                {
                    player.carvao += 3;
                }
                if(gameObject.name.Contains("Ferro"))
                {
                    player.ferro += 3;
                }
                if(gameObject.name.Contains("Ouro"))
                {
                    player.ouro += 3;
                }
                if(gameObject.name.Contains("LapisLazuli"))
                {
                    player.lapisLazuli += 3;
                }
                if(gameObject.name.Contains("Redstone"))
                {
                    player.redstone += 3;
                }
                if(gameObject.name.Contains("Diamante"))
                {
                    player.diamante += 3;
                }
            }
        }
    }
}
