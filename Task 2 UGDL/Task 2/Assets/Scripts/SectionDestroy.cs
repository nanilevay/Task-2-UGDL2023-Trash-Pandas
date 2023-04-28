using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionDestroy : MonoBehaviour
{
    public string parentName;

    void Start()
    {
        parentName = transform.name;
        StartCoroutine(DestroyClone());
    }

    private IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(10);
        if(parentName == "Section(Clone)" || parentName == "Section_1(Clone)" || parentName == "Section_2(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
