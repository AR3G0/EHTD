using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(DestroyVFX());
    }

    IEnumerator DestroyVFX()
    {
        yield return new WaitForSeconds(0.55f);
        Destroy(gameObject);
        gameObject.GetComponent<AudioSource>().Stop();
    }
}
