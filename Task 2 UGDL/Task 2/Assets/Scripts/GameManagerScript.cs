using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject[] section;
    public GameObject parent;

    [SerializeField] private int genSpeed;
    [SerializeField] private int zPos;
    [SerializeField] private int secNum;
    [SerializeField] private bool creatingSection;

    void Update()
    {
        if(creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    private IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 3);
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity, parent.transform);
        zPos += 20;
        yield return new WaitForSeconds(genSpeed);
        creatingSection = false;
    }
}
