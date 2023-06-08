using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public Texture2D cursorPadrao, cursorEspada, cursorMachado, cursorDestruir, cursorMelhorar, cursorPicareta, cursorCarvao, cursorRedstone;
    public List<Texture2D> cursoresPicaretas;
    public List<GameObject> imagensPicaretas;
    Player player;
    int item = 1;
    public List<GameObject> paineisIndicadores;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Cursor.SetCursor(cursorPadrao, Vector2.zero, CursorMode.ForceSoftware);
        for (var i = 0; i < paineisIndicadores.Count; i++)
        {
            paineisIndicadores[i].SetActive(false);
        }
        paineisIndicadores[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            BotoesInventario(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            BotoesInventario(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            BotoesInventario(3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            BotoesInventario(4);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            BotoesInventario(5);
        }
        if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            BotoesInventario(6);
        }
        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            BotoesInventario(7);
        }
        if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            BotoesInventario(8);
        }

        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            if(item == 8)
            {
                item = 1;
            }
            else if(item < 8)
            {
                item++;
            }
            BotoesInventario(item);
        }
        else if(Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            if(item == 1)
            {
                item = 8;
            }
            else if(item > 1)
            {
                item--;
            }
            BotoesInventario(item);
        }

        cursorPicareta = cursoresPicaretas[player.nivelPicareta - 1];
        for (var i = 0; i < imagensPicaretas.Count; i++)
        {
            imagensPicaretas[i].SetActive(false);
        }
        imagensPicaretas[player.nivelPicareta - 1].SetActive(true);
    }

    public void BotoesInventario(int funcao)
    {
        for (var i = 0; i < paineisIndicadores.Count; i++)
        {
            paineisIndicadores[i].SetActive(false);
        }
        paineisIndicadores[funcao - 1].SetActive(true);
        item = funcao;

        switch (funcao)
        {
            case 1 : 
                Cursor.SetCursor(cursorPadrao, Vector2.zero, CursorMode.ForceSoftware);
                player.inventario = "padrao";
                break;

            case 2 : 
                Cursor.SetCursor(cursorEspada, Vector2.zero, CursorMode.ForceSoftware);
                player.inventario = "espada";
                break;

            case 3 : 
                Cursor.SetCursor(cursorMachado, Vector2.zero, CursorMode.ForceSoftware);
                player.inventario = "machado";
                break;
            
            case 4 : 
                Cursor.SetCursor(cursorDestruir, Vector2.zero, CursorMode.ForceSoftware);
                player.inventario = "destruir";
                break;
            
            case 5 : 
                Cursor.SetCursor(cursorMelhorar, Vector2.zero, CursorMode.ForceSoftware);
                player.inventario = "melhorar";
                break;

            case 6 : 
                Cursor.SetCursor(cursorPicareta, Vector2.zero, CursorMode.ForceSoftware);
                player.inventario = "picareta";
                break;

            case 7 : 
                Cursor.SetCursor(cursorCarvao, Vector2.zero, CursorMode.ForceSoftware);
                player.inventario = "carvao";
                break;

            case 8 : 
                Cursor.SetCursor(cursorRedstone, Vector2.zero, CursorMode.ForceSoftware);
                player.inventario = "redstone";
                break;

            default :
                break;
        } 
    }
}
