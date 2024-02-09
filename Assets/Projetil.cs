using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{

    [SerializeField]
    public Vector2 direcao = Vector2.zero;

    [SerializeField]
    float tempoDeVida = 5f;

    public GameObject quemInvocou;

    Rigidbody2D rb;
    Mover mover;

    void Start()
    {
        mover = GetComponent<Mover>();
        StartCoroutine(DeletarDepoisDeUmTempo());
    }

    // Update is called once per frame
    void Update()
    {
        mover.Move(direcao);
    }

    IEnumerator DeletarDepoisDeUmTempo()
    {
        yield return new WaitForSeconds(tempoDeVida);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
