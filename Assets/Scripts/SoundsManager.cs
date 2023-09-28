using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip[] listSound;

    // Start is called before the first frame update
    public static SoundsManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }


    public void PlaySound(string nameSound)
    {
        switch (nameSound)
        {
            case "Shoot":
                m_AudioSource.clip = listSound[0];
                m_AudioSource.Play();
                break;
            case "Hurt":
                m_AudioSource.clip = listSound[1];
                m_AudioSource.Play();
                break;
            case "Ground":
                m_AudioSource.clip = listSound[2];
                m_AudioSource.Play();
                break;

        }
    }
}
