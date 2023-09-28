using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private float force;

    private Rigidbody2D rb;
    private Animator animator;
    private BoxCollider2D col;

    private GameObject player1,player2;

    private bool isFly = true;
    private bool followTarget=true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");

        if (player1.GetComponent<PlayerController>().canControll)
        {
            force= player1.GetComponent<PlayerController>().getForce();
        }
        else
        {
            force = player2.GetComponent<PlayerController>().getForce();
        }


        WeaponMove();
    }
    private void FixedUpdate()
    {
        if (isFly)
        transform.up = rb.velocity;

    }
    // Update is called once per frame
    private void LateUpdate()
    {
        if (followTarget)
        {
            CameraManager.Instance.TargetObj(gameObject);
        }
    }
    public void WeaponMove()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(transform.up * force,ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("background"))
        {
            isFly = false;
            followTarget = false;

            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            rb.bodyType= RigidbodyType2D.Kinematic;
            col.enabled = false;

            CameraManager.Instance.CancelTargetObj(gameObject);
        }

        if (collision.gameObject.CompareTag("background") || collision.gameObject.CompareTag("player"))
        {

            if (player1.GetComponent<PlayerController>().canControll)
            {
                player1.GetComponent<PlayerController>().setForce(0f);
            }
            else
            {
                player2.GetComponent<PlayerController>().setForce(0f);
            }
            SoundsManager.Instance.PlaySound("Ground");
            GameManager.Instance.EndTurn();
        }
    }
}
