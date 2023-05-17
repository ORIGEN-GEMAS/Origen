using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelsController : MonoBehaviour
{
    public GameObject panel;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PanelDuration(4f));
        

    }

    

    IEnumerator PanelDuration(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        panel.SetActive(false);
    }

    
}
