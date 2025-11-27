using System.Collections;
using UnityEngine;

public class TryingCoroutine : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(something());
    }
    IEnumerator something()
    {
        Debug.Log("Sssssss");
        yield return new WaitForSeconds(3f);
        Debug.Log("Ffffffff");
    }
}
