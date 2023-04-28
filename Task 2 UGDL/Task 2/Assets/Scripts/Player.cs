using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool jumpAtk;

    private GameObject player;

    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    private void Start()
    {
        player = this.gameObject;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        Swipe();
    }

   private void Swipe()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
            Debug.Log("Start");
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;
            Debug.Log("End");

            if (endTouchPos.x < startTouchPos.x)
            {
                Debug.Log("MoveR");
                MoveRight();
            }

            if(endTouchPos.x > startTouchPos.x)
            {
                Debug.Log("MoveL");
                MoveLeft();
            }
        }
    }

    private void MoveLeft()
    {
        player.transform.position = new Vector3(player.transform.position.x + 2, player.transform.position.y, player.transform.position.z);
    }

    private void MoveRight()
    {

        player.transform.position = new Vector3(player.transform.position.x - 2, player.transform.position.y, player.transform.position.z);
    }
}
