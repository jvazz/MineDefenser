using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int numeroDaFase;
    public Text madeiraTxt;
    public Text carvaoTxt, ferroTxt, ouroTxt, lapisLazuliTxt, redstoneTxt, diamanteTxt;
    public int madeira;
    public int carvao, ferro, ouro, lapisLazuli, redstone, diamante;
    public int vida = 3;
    public GameObject coracao1, coracao2, coracao3;
    public string inventario = "padrao";
    public Texture2D cursorPadrao, cursorEspada;
    public bool modoContrucao = false;
    public string tipoConstrucao;
    public List<GameObject> listaCostrucoes;
    public List<GameObject> listaCostrucoesFantasmas;
    public int nivelPicareta;
    public GameObject painelVitoria, painelDerrota;
    public int inimigosVivos;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        coracao1.SetActive(true);
        coracao2.SetActive(true);
        coracao3.SetActive(true);
        painelVitoria.SetActive(false);
        painelDerrota.SetActive(false);
        inimigosVivos = 0;

        Cursor.SetCursor(cursorPadrao, Vector2.zero, CursorMode.ForceSoftware);
        ouro = 50;
    }

    // Update is called once per frame
    void Update()
    {
        ouroTxt.text = ouro.ToString();
        madeiraTxt.text = madeira.ToString();
        carvaoTxt.text = carvao.ToString();
        redstoneTxt.text = redstone.ToString();
        ferroTxt.text = ferro.ToString();
        lapisLazuliTxt.text = lapisLazuli.ToString();
        diamanteTxt.text = diamante.ToString();

        if(vida == 3)
        {
            coracao1.SetActive(true);
            coracao2.SetActive(true);
            coracao3.SetActive(true);
        }
        if(vida == 2)
        {
            coracao1.SetActive(true);
            coracao2.SetActive(true);
            coracao3.SetActive(false);
        }
        if(vida == 1)
        {
            coracao1.SetActive(true);
            coracao2.SetActive(false);
            coracao3.SetActive(false);
        }
        if(vida == 0)
        {
            coracao1.SetActive(false);
            coracao2.SetActive(false);
            coracao3.SetActive(false);
            painelDerrota.SetActive(true);
            Time.timeScale = 0f;
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            ouro += 500;
            madeira += 10;
            carvao += 10;
            redstone += 10;
            ferro += 10;
            lapisLazuli += 10;
            diamante += 10;
        }
    }
}
