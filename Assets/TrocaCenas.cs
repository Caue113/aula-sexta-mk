using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCenas : MonoBehaviour
{
    public string nomeProximaCena;
    public void MudarCena(string nomeCena) 
    {
        SceneManager.LoadScene(nomeCena);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.name == "Player")
        {
            MudarCena(nomeProximaCena);
        }
        
    }

}
