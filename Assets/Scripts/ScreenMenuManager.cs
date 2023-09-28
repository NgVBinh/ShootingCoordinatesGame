using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMenuManager : MonoBehaviour
{
    public static ScreenMenuManager Instance;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject modePanel;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(true);
        modePanel.SetActive(false);
    }

    public void changScreen()
    {
        menuPanel.SetActive(false );
        modePanel.SetActive(true );
    }
}
