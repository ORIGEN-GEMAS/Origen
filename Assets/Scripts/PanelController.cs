using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject panelESC;
    [SerializeField] Animator fade;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PanelDuration(6f));
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
    

    public void FadeOut()
    {
        fade.Play("FadeOut");
    }


}