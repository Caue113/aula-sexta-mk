using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float velocidade = 5f;
    [SerializeField]
    float forcaPulo = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direcao)
    {
        rb.velocity = new Vector2(direcao.x * velocidade, rb.velocity.y);
    }

    public void Pula()
    {
        rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
    }
}
