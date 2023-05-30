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
    private SceneTransition sceneTransition;


    // Start is called before the first frame update
    void Start()
    {
        sceneTransition = FindAnyObjectByType<SceneTransition>();
        if (SceneManager.GetActiveScene().name=="Red World")
        {
            StartCoroutine(PanelDuration(6f));
        }
        else if (SceneManager.GetActiveScene().name == "born")
        {
            StartCoroutine(Credits(7f));
        }
        else if (SceneManager.GetActiveScene().name == "Forest")
        {
            StartCoroutine(PanelDurationF(6f));
        }
        else if (SceneManager.GetActiveScene().name == "moiras")
        {
            StartCoroutine(PanelDuration(17f));
        }
        else if (SceneManager.GetActiveScene().name == "HidraCombat")
        {
            StartCoroutine(PanelDuration(6f));
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
        credits[4].SetActive(true);
        yield return new WaitForSeconds(tiempo);
        Invoke("FadeOutText", tiempo);
        credits[4].SetActive(false);
        credits[5].SetActive(true);
        yield return new WaitForSeconds(tiempo);
        Invoke("FadeOutText", tiempo);
        credits[5].SetActive(false);
        sceneTransition.Startcorutina("Red World");
        //SceneManager.LoadScene("Red World");
    }
    IEnumerator PanelDurationF(float tiempo)
    {
        Invoke("FadeOut", tiempo - 2);
        yield return new WaitForSeconds(tiempo);
        panelESC.SetActive(true);
        yield return new WaitForSeconds(tiempo);
        panelESC.SetActive(false);
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