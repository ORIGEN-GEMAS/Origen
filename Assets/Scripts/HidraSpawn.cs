using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidraSpawn : MonoBehaviour
{
    [SerializeField] private GameObject hidra;
    [SerializeField] private GameObject player;
    private AudioManager audiop;
    // Start is called before the first frame update
    void Start()
    {
        audiop = FindAnyObjectByType<AudioManager>();
        StartCoroutine(Lore());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Lore()
    {
        audiop.PlaySFX(audiop.nar2);
        yield return new WaitForSeconds(33.7f);
        hidra.SetActive(true);
        player.SetActive(true);
    }
}
