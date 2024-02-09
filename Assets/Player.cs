using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Mover mover;
    Vector2 direcaoOlhar = Vector2.right;
    Vector2 direcaoMover = Vector2.zero;

    bool estaChao = true;

    public Projetil projetil;
    [SerializeField]
    GameObject spawnProjetil;

    Vida vida;
    void Start()
    {
        direcaoMover = Vector2.zero;
        mover = GetComponent<Mover>();
        vida = GetComponent<Vida>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            direcaoOlhar = Vector2.right;
            direcaoMover = Vector2.right;   
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            direcaoOlhar = Vector2.left;
            direcaoMover = Vector2.left;
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            direcaoMover = Vector2.zero;
        }

        //Trocar lado
        transform.localScale = new Vector3(direcaoOlhar.x, 1);

        if (Input.GetAxisRaw("Jump") == 1 && estaChao)
        {
            estaChao = false;
            mover.Pula();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Atirar();
        }

        mover.Move(direcaoMover);
    }


    public void Atirar()
    {
        projetil.direcao = direcaoOlhar;
        projetil.quemInvocou = gameObject;
        Instantiate(projetil, spawnProjetil.transform.position, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject alvo = collision.gameObject;

        if (alvo.layer == 6)
        {
            estaChao = true;
        }

        
        if (alvo.GetComponent<Projetil>() && alvo.GetComponent<Projetil>().quemInvocou != gameObject)
        {
            vida.AdicionarVida(-1);
            if (vida.VidaEstaZero()) 
            {
                Debug.Log("Você morreu");
            }
            
        }
    }
}
