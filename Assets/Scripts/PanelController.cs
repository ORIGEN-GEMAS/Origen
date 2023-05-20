using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject panelESC;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PanelDuration(4f));
        StartCoroutine(PanelDuration2(4f));
    }

    IEnumerator PanelDuration(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        panel.SetActive(false);
        
    }
    IEnumerator PanelDuration2(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        panelESC.SetActive(true);
        yield return new WaitForSeconds(tiempo);
        panelESC.SetActive(false);
    }


}