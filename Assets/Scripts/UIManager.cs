using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    private SceneManage game;
    // Start is called before the first frame update
    void Start()
    {
        game = FindAnyObjectByType<SceneManage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menu.activeInHierarchy == true)
        {
            menu.SetActive(false);
            game.Continue();
        }
        else if  (Input.GetKeyDown(KeyCode.Escape) && menu.activeInHierarchy == false)
        { 
            menu.SetActive(true);
            game.Stop();
        }
    }


}

