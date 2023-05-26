using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    private SceneManage game;
    private AudioManager audiop;
    // Start is called before the first frame update
    void Start()
    {
        game = FindAnyObjectByType<SceneManage>();
        audiop = FindAnyObjectByType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && menu.activeInHierarchy == true)
        {
            audiop.PlaySFX(audiop.click);
            menu.SetActive(false);
            game.Continue();
        }
        else if  (Input.GetKeyDown(KeyCode.P) && menu.activeInHierarchy == false)
        {
            audiop.PlaySFX(audiop.click);
            menu.SetActive(true);
            game.Stop();
        }
    }

}

