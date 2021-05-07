using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{ 
    private static bool exists;//Pour pas qu'il y ai 2 audios

    //Liste des musiques
    public GameObject title_theme;
    public GameObject inGameTheme;

    void Start()
    {
        if (!exists)
        {
            exists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Title_screen")
        {
            if (!title_theme.GetComponent<AudioSource>().isPlaying)
            {
                inGameTheme.GetComponent<AudioSource>().Stop();
                title_theme.GetComponent<AudioSource>().Play(0);
            }
        }
        if(scene.name == "1v1_game")
        {
            if (!inGameTheme.GetComponent<AudioSource>().isPlaying)
            {
                title_theme.GetComponent<AudioSource>().Stop();
                inGameTheme.GetComponent<AudioSource>().Play(0);
            }
               
        }
        
    }

}
