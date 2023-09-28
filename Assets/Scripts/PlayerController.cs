using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject weaponPref;
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private float speed, titlSmooth;

    private Animator animator;

    private int hpPlayer = 100;
    private int angleShoot = 45;

    private float forceAttack = 0;
    public float maxForce = 20f;

    public bool canControll;

    // Start is called before the first frame update

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {
        if (canControll)
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        if (canControll)
        {
            PlayerMove();
            RotateAngleWeapon();
            changeDirection();
        }
    }

    private void LateUpdate()
    {
        if (canControll)
        {
            CameraManager.Instance.TargetObj(gameObject);
        }
    }
    public void PlayerMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 temp = transform.position;
        if (horizontal < 0)
        {
            temp.x -= speed * Time.deltaTime;
        }
        else if (horizontal > 0)
        {
            temp.x += speed * Time.deltaTime;
        }
        transform.position = temp;

        if (horizontal != 0)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    public void Attack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (forceAttack < maxForce)
            {
                forceAttack += Time.deltaTime * 10f;
                setForce(forceAttack);
            }
        }

        if (forceAttack != 0 && Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
            StartCoroutine(waitAttack());
            canControll = false;

            CameraManager.Instance.CancelTargetObj(gameObject);
        }
    }

    public void RotateAngleWeapon()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float temp = attackPoint.transform.localRotation.eulerAngles.z;
        if (vertical != 0)
        {
            temp -= vertical * titlSmooth;
            angleShoot = Convert.ToInt32(90f - temp);
            //Debug.Log(angleShoot);
        }
        Quaternion newRotation = Quaternion.Euler(0f, 0f, temp);
        attackPoint.transform.localRotation = newRotation;
    }

    public void changeDirection()
    {
        if ((transform.localScale.x < 0f && Input.GetAxis("Horizontal") < 0) || (transform.localScale.x > 0f && Input.GetAxis("Horizontal") > 0))
        {
            Vector3 temp = transform.localScale;
            temp.x *= -1f;
            transform.localScale = temp;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            hpPlayer -= 20;
            if (hpPlayer > 0)
            {
                animator.SetTrigger("Hurt");
                SoundsManager.Instance.PlaySound("Hurt");
            }
            if (hpPlayer == 0)
            {
                animator.SetTrigger("Die");
                //end game
                StartCoroutine(waitEndgame());
            }
            Destroy(collision.gameObject);
        }
    }

    public int getHP()
    {
        return this.hpPlayer;

    }

    public int getAngleShoot()
    {
        return this.angleShoot;
    }

    public float setForce(float force){
        return this.forceAttack=force;
    }
    public float getForce()
    {
        return this.forceAttack;
    }
    IEnumerator waitAttack()
    {
        yield return new WaitForSeconds(0.8f);
        Instantiate(weaponPref, attackPoint.transform.position, attackPoint.transform.rotation);
        SoundsManager.Instance.PlaySound("Shoot");
    }

    IEnumerator waitEndgame()
    {
        yield return new WaitForSeconds(0.8f);
        ScreenMenuManager.Instance.changScreen();
    }
}
