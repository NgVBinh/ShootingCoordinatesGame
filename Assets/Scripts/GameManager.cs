using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] mapPrefabs;
    [SerializeField] private GameObject[] characterPrefabs;
    [SerializeField] private Transform[] positionSpawner;
    //private List<GameObject> gameObjects;

    public GameObject player1,player2;

    private int currentTurnIndex = 0;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Instantiate(mapPrefabs[TogglePlayerManager.Instance.mapChoose]);

        int positionIndex1= Random.Range(0, positionSpawner.Length);
        int positionIndex2 = Random.Range(0, positionSpawner.Length);


         player1 = Instantiate(characterPrefabs[TogglePlayerManager.Instance.player1Choose], positionSpawner[positionIndex1]);
         player2 = Instantiate(characterPrefabs[TogglePlayerManager.Instance.player2Choose], positionSpawner[positionIndex2]);

         player1.name = "player1";
         player2.name = "player2";

        //// Đặt danh sách các GameObjects
        //gameObjects = new List<GameObject>();
        //gameObjects.Add(GameObject.Find("player1")); // Thêm GameObject 1
        //gameObjects.Add(GameObject.Find("player2")); // Thêm GameObject 2

        
    }

    private void Update()
    {
        IsCurrentTurn();
    }

    //public bool IsCurrentTurn(GameObject gameObject)
    //{
    //    // Kiểm tra xem GameObject được truyền vào có đang là lượt hiện tại không
    //    return gameObjects[currentTurnIndex] == gameObject;
    //}

    //public void EndTurn()
    //{
    //    // Kết thúc lượt hiện tại và chuyển sang lượt kế tiếp
    //    currentTurnIndex = (currentTurnIndex + 1) % gameObjects.Count;
    //}

    public void IsCurrentTurn()
    {
        if(currentTurnIndex %2 == 0)
        {
            player1.GetComponent<PlayerController>().canControll=true;
            player2.GetComponent<PlayerController>().canControll = false;
        }
        else
        {
            player1.GetComponent<PlayerController>().canControll = false;
            player2.GetComponent<PlayerController>().canControll = true;
        }
    }

    public void EndTurn()
    {
        currentTurnIndex++;
    }
}
