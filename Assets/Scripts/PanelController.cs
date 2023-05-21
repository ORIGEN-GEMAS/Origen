using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject panelESC;
    [SerializeField] GameObject[] credits;
    [SerializeField] Animator fade;


    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name=="Red World")
        {
            StartCoroutine(PanelDuration(6f));
        }
        else if (SceneManager.GetActiveScene().name == "born")
        {
            StartCoroutine(Credits(8f));
        }
    }

    IEnumerator PanelDuration(float tiempo)
    {
        Invoke("FadeOut", tiempo-2);
        yield return new WaitForSeconds(tiempo);
        panelESC.SetActive(true);
        panel.SetActive(false);
        Invoke("FadeOut", tiempo - 2);
        yield return new WaitForSeconds(tiempo);
        panelESC.SetActive(false);
    }
    IEnumerator Credits(float tiempo)
    {
        Invoke("FadeOutText", tiempo - 2);
        yield return new WaitForSeconds(tiempo);
        Invoke("FadeOutText", tiempo - 2);
        credits[0].SetActive(false);
        credits[1].SetActive(true);
        yield return new WaitForSeconds(tiempo);
        Invoke("FadeOutText", tiempo - 2);
        credits[1].SetActive(false);
        credits[2].SetActive(true);
        yield return new WaitForSeconds(tiempo);
        Invoke("FadeOutText", tiempo - 2);
        credits[2].SetActive(false);
        credits[3].SetActive(true);
        yield return new WaitForSeconds(tiempo);
        Invoke("FadeOutText", tiempo - 2);
        credits[3].SetActive(false);
        SceneManager.LoadScene("Red World");
    }

    public void FadeOut()
    {
        fade.Play("FadeOut");
    }
    public void FadeOutText()
    {
        fade.Play("FadeOutText");
    }


}