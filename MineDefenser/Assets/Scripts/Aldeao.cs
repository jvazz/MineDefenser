using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aldeao : MonoBehaviour
{
    Player player;
    public List<GameObject> placasPicaretas;
    public GameObject controladorAldeao;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name.Contains("Picareta"))
        {
            for (var i = 0; i < placasPicaretas.Count; i++)
            {
                placasPicaretas[i].SetActive(false);
            }
            placasPicaretas[player.nivelPicareta - 1].SetActive(true);
        }
    }

    void OnMouseDown()
    {
        if(gameObject.name.Contains("Vida"))
        {
            if(controladorAldeao.GetComponent<ControladorAldeao>().podeComprar)
            {
                if(player.diamante >= 1 && player.vida < 3)
                {
                    player.vida++;
                    player.diamante -= 1;
                }
            }
        }
        if(gameObject.name.Contains("Picareta"))
        {
            switch (player.nivelPicareta)
            {
                case 1 :
                    if(player.carvao >= 3)
                    {
                        player.nivelPicareta++;
                        player.carvao -= 3;
                    } 
                    break;

                case 2 : 
                    if(player.ferro >= 3)
                    {
                        player.nivelPicareta++;
                        player.ferro -= 3;
                    } 
                    break;

                case 3 : 
                    if(player.ouro >= 3)
                    {
                        player.nivelPicareta++;
                        player.ouro -= 3;
                    } 
                    break;

                case 4 : 
                    if(player.diamante >= 3)
                    {
                        player.nivelPicareta++;
                        player.diamante -= 3;
                    } 
                    break;

                default :
                    break;
            }
        }
    }
}
