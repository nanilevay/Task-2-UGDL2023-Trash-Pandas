using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionDestroy : MonoBehaviour
{
    [SerializeField] private string parentName;

    //Time that the platforms are alive
    [SerializeField] private float spawnDeleteTime = 10;

    void Start()
    {
        parentName = transform.name;
        StartCoroutine(DestroyClone());
    }

    //Deletes a platform that goes "_NameOfObj_(Clone)"
    private IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(spawnDeleteTime);

        //Deletes the (Clone)s
        if(parentName == "Section(Clone)" || parentName == "Section_1(Clone)" || parentName == "Section_2(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
