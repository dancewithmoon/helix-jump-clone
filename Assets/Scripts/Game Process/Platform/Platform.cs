using System;
using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public event Action Passed;

    public void Pass()
    {
        Passed?.Invoke();
        StartCoroutine(DestroyPlatform());
    }

    private IEnumerator DestroyPlatform()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
