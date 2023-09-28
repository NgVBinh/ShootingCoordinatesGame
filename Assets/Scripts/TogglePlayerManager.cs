using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePlayerManager : MonoBehaviour
{
    // 4 toggle cho lựa chọn Player 1
    [SerializeField] private Toggle choosePlayer1_1;
    [SerializeField] private Toggle choosePlayer1_2;
    [SerializeField] private Toggle choosePlayer1_3;
    [SerializeField] private Toggle choosePlayer1_4;

    // 4 toggle cho lựa chọn Player 2
    [SerializeField] private Toggle choosePlayer2_1;
    [SerializeField] private Toggle choosePlayer2_2;
    [SerializeField] private Toggle choosePlayer2_3;
    [SerializeField] private Toggle choosePlayer2_4;

    // 4 toggle cho lựa chọn Map
    [SerializeField] private Toggle chooseMap_1;
    [SerializeField] private Toggle chooseMap_2;
    [SerializeField] private Toggle chooseMap_3;
    [SerializeField] private Toggle chooseMap_4;



    public int player1Choose;
    public int player2Choose;
    public int mapChoose;

    public static TogglePlayerManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //kiểm tra lựa chọn player 1
        choosePlayer1_1.onValueChanged.AddListener(OnValuePlayer1_1);
        choosePlayer1_2.onValueChanged.AddListener(OnValuePlayer1_2);
        choosePlayer1_3.onValueChanged.AddListener(OnValuePlayer1_3);
        choosePlayer1_4.onValueChanged.AddListener(OnValuePlayer1_4);
        // kiểm tra lựa chọn player 2
        choosePlayer2_1.onValueChanged.AddListener(OnValuePlayer2_1);
        choosePlayer2_2.onValueChanged.AddListener(OnValuePlayer2_2);
        choosePlayer2_3.onValueChanged.AddListener(OnValuePlayer2_3);
        choosePlayer2_4.onValueChanged.AddListener(OnValuePlayer2_4);
        //kiểm tra lựa chọn map
        chooseMap_1.onValueChanged.AddListener(OnValueMap1);
        chooseMap_2.onValueChanged.AddListener(OnValueMap2);
        chooseMap_3.onValueChanged.AddListener(OnValueMap3);
        chooseMap_4.onValueChanged.AddListener(OnValueMap4);


    }

    // kiểm tra lựa chọn và set giá trị cho Player 1
    private void OnValuePlayer1_1(bool isOn)
    {
        if (isOn)
        {
            player1Choose = 0;
        }
    }

    private void OnValuePlayer1_2(bool isOn)
    {
        if (isOn)
        {
            player1Choose = 1;
        }
    }
    private void OnValuePlayer1_3(bool isOn)
    {
        if (isOn)
        {
            player1Choose = 2;
        }
    }
    private void OnValuePlayer1_4(bool isOn)
    {
        if (isOn)
        {
            player1Choose = 3;
        }
    }

    // kiểm tra lựa chọn và set giá trị cho Player 2
    private void OnValuePlayer2_1(bool isOn)
    {
        if (isOn)
        {
            player2Choose = 0;
        }
    }
    private void OnValuePlayer2_2(bool isOn)
    {
        if (isOn)
        {
            player2Choose = 1;
        }
    }
    private void OnValuePlayer2_3(bool isOn)
    {
        if (isOn)
        {
            player2Choose = 2;
        }
    }
    private void OnValuePlayer2_4(bool isOn)
    {
        if (isOn)
        {
            player2Choose = 3;
        }
    }

    //kiểm tra và set giá trị map được chọn
    private void OnValueMap1(bool isOn)
    {
        if (isOn)
        {
            mapChoose = 0;
        }
    }
    private void OnValueMap2(bool isOn)
    {
        if (isOn)
        {
            mapChoose = 1;
        }
    }
    private void OnValueMap3(bool isOn)
    {
        if (isOn)
        {
            mapChoose = 2;
        }
    }
    private void OnValueMap4(bool isOn)
    {
        if (isOn)
        {
            mapChoose = 3;
        }
    }
}
