using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool jumpAtk;

    [SerializeField] private GameObject player;

    private Vector3 startTouchPos;
    private Vector3 endTouchPos;
    private float dragDIstance; // minimu distance for swipe

    private void Start()
    {
        //player = this.gameObject;
        dragDIstance = Screen.height * 15 / 100;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        Swipe();
    }

    private void Swipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPos = touch.position;
                endTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                endTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {

                endTouchPos = touch.position;
                if (Mathf.Abs(endTouchPos.x - startTouchPos.x) > dragDIstance)
                {
                    if (Mathf.Abs(endTouchPos.x - startTouchPos.x) > Mathf.Abs(endTouchPos.y - startTouchPos.y))
                    {
                        if (endTouchPos.x > startTouchPos.x)
                        {
                            Debug.Log("Swipe Right");
                            MoveRight();
                        }

                        else
                        {
                            MoveLeft();
                            Debug.Log("Swipe Left");
                        }
                    }
                }
                else // i'ts a tap
                {
                    Debug.Log("Tap");
                }
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
