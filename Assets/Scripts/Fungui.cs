using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fungui : MonoBehaviour
{
    [SerializeField] private float distortion = 0.08f; 
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private GameObject funguiParticle;

    private Vector3 originalScale;

    private bool isPlayerOnTop = false;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isPlayerOnTop)
        {
            isPlayerOnTop = true;
            StopAllCoroutines();
            StartCoroutine(ScaleChange(originalScale, new Vector3(originalScale.x, originalScale.y - distortion, originalScale.z), duration));
            if(funguiParticle != null) 
            {
                GameObject particleInstance = Instantiate(funguiParticle, transform.position, Quaternion.identity);
                ParticleSystem ps = particleInstance.GetComponent<ParticleSystem>();
                if(ps != null) 
                {
                    ps.Play();
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isPlayerOnTop)
        {
            // Do nothing if the player stays on top of the funghi
            return;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isPlayerOnTop)
        {
            StopAllCoroutines();
            StartCoroutine(ScaleChange(transform.localScale, originalScale, duration));
        }
    }

    IEnumerator ScaleChange(Vector3 fromScale, Vector3 toScale, float duration)
    {
        float timer = 0;
        while (timer <= duration)
        {
            transform.localScale = Vector3.Lerp(fromScale, toScale, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }
        // Assign the target scale directly after the loop
        transform.localScale = toScale;
        // Set isPlayerOnTop to false after the scaling operation is complete
        isPlayerOnTop = false;
    }
}
