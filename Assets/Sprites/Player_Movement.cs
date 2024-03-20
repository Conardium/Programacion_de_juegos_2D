using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float Speed = 1.0f;
    
    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator playerAnimator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized; //normalizamos para evitar que al movernos diagonalmente vayamos más rapido

        //Establecemos los parametros de la animacion del personaje
        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        //Movemos el personaje desde su posicion actual + movimiento del teclado * velocidad
        //Time.fixedDeltaTime permite que la velocidad sea constante sin importar cuantas veces por segundo se llame FixedUpdate
        playerRb.MovePosition(playerRb.position + moveInput * Speed * Time.fixedDeltaTime);
    }
}
