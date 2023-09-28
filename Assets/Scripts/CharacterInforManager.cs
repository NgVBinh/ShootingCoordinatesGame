using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInforManager : MonoBehaviour
{
    private Slider hpBar1;
    private Slider hpBar2;

    private Slider force;


    private Text textHP1;
    private Text textHP2;

    private Text textAngle1;
    private Text textAngle2;
    [SerializeField] private Text winnerName;

    private int maxHP = 100;

    GameObject player1;
    GameObject player2;

    void Start()
    {
        textAngle1 = GameObject.Find("Angle_text1").GetComponent<Text>();
        textAngle2 = GameObject.Find("Angle_text2").GetComponent<Text>();

        hpBar1 = GameObject.Find("hp_player1").GetComponentInChildren<Slider>();
        hpBar2 = GameObject.Find("hp_player2").GetComponentInChildren<Slider>();

        force = GameObject.Find("Force").GetComponentInChildren<Slider>();

        textHP1 = GameObject.Find("hpPlayer1").GetComponent<Text>();
        textHP2 = GameObject.Find("hpPlayer2").GetComponent<Text>();

        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");

       // winnerName = GameObject.Find("Winner").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        setHpBar();
        setAngle();
        setForce();
    }

    public void setHpBar()
    {
        int currentHP1 = player1.GetComponent<PlayerController>().getHP();
        hpBar1.value = currentHP1;
        textHP1.text = currentHP1.ToString() + "/" + maxHP.ToString();

        if(currentHP1 == 0) {
            winnerName.text = player2.name.ToString();
        }

        int currentHP2 = player2.GetComponent<PlayerController>().getHP();
        hpBar2.value = currentHP2;
        textHP2.text = currentHP2.ToString() + "/" + maxHP.ToString();

        if (currentHP2 == 0)
        {
            winnerName.text = player1.name.ToString();
        }
    }
    public void setAngle()
    {
        int angleShoot1 = player1.GetComponent<PlayerController>().getAngleShoot();
        textAngle1.text = angleShoot1.ToString();

        int angleShoot2 = player2.GetComponent<PlayerController>().getAngleShoot();
        textAngle2.text = angleShoot2.ToString();
    }
    public void setForce()
    {
        if (player1.GetComponent<PlayerController>().canControll)
        {
            float forcePlayer1 = player1.GetComponent<PlayerController>().getForce();
            force.value = forcePlayer1;
        }
        else
        {
            float forcePlayer2 = player2.GetComponent<PlayerController>().getForce();
            force.value = forcePlayer2;
        }
    }
}
