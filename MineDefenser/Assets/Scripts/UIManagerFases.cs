using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerFases : MonoBehaviour
{
    public string nomeDaCena;
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

    public void Menu()
    {
        SceneManager.LoadScene("TelaInicial");
    }

    public void JogarNovamente()
    {
        /*if(player.numeroDaFase == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }else
        {
            SceneManager.LoadScene("Fase" + player.numeroDaFase.ToString(""));
        }*/

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
