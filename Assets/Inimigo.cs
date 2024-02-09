using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    [SerializeField]
    Vector2 direcaoAtirar = Vector2.zero;

    [SerializeField]
    float delayAtirar = 3f;

    [SerializeField]
    Projetil projetil;

    [SerializeField]
    GameObject spawnProjetil;
    bool podeAtirar = true;

    Vida vida;

    void Start()
    {
        vida = GetComponent<Vida>();
    }

    // Update is called once per frame
    void Update()
    {
        if(podeAtirar)
        {
            StartCoroutine(Atirar());
        }
    }

    IEnumerator Atirar()
    {
        podeAtirar = false;
        yield return new WaitForSeconds(delayAtirar);

        projetil.direcao = direcaoAtirar;
        Instantiate(projetil, spawnProjetil.transform.position, Quaternion.identity);
        podeAtirar = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject alvo = collision.gameObject;

        if (alvo.GetComponent<Projetil>())
        {
            vida.AdicionarVida(-1);
            if (vida.VidaEstaZero())
            {
                Destroy(gameObject);
            }
        }
    }
}
