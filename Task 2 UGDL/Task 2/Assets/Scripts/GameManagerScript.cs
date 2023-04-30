using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    //Instantiates CLones for the Level Generations

    //List of GameObjs to Clone
    public GameObject[] section;
    //Obj where these Objs are going to be cloned to as a child
    public GameObject parent;

    //Generation speed
    [SerializeField] private int genSpeed;
    //relative position of the next one (usually is the length of the demons)
    [SerializeField] private int zPos;
    //Randomizer
    [SerializeField] private int secNum;

    //To check is segment is being created
    [SerializeField] private bool creatingSection;

    void Update()
    {
        //Loop of Segment creation
        if(creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    //Coroutine to Spawn Lvl segments
    private IEnumerator GenerateSection()
    {
        //Randomizes witch sections is gonna be selected from the "section[]"
        secNum = Random.Range(0, 3);
        //Instanciates the sections with an updated Pos and Obj on Hierarchy
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity, parent.transform);
        //Upadates next Spawn Pos
        zPos += 20;
        //Generation Cooldown
        yield return new WaitForSeconds(genSpeed);
        //Loop restart
        creatingSection = false;
    }
}
