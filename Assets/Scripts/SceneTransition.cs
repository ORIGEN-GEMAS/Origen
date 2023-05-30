using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip animacionFinal;
    [SerializeField] private Button inicio;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (SceneManager.GetActiveScene().name == "Inicio")
        {
            inicio.onClick.AddListener(Startcorutina);
        }
    }

    private void Startcorutina()
    {
        StartCoroutine(ChangeScene("born"));
    }

    IEnumerator ChangeScene(string scena)
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);
        SceneManager.LoadScene(scena);
    }
}
