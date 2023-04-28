using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float slideSpeed;

    [SerializeField] private float limitRight;
    [SerializeField] private float limitLeft;

    [SerializeField] private bool jumpAtk;

    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        Swipe();
    }

    private void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
            Debug.Log("Start");
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;
            Debug.Log("End");

            if (endTouchPos.x < startTouchPos.x)
            {
                Debug.Log("MoveR");
                MoveRight();
            }

            else if (endTouchPos.x > startTouchPos.x)
            {
                Debug.Log("MoveL");
                MoveLeft();
            }

            else
                Debug.Log("Tap");
        }
    }

    private void MoveLeft()
    {
        if(this.transform.position.x > limitLeft)
            transform.Translate(Vector3.left * Time.deltaTime * slideSpeed, Space.World);
    }

    private void MoveRight()
    {
        if (this.transform.position.x > limitRight)
            transform.Translate(Vector3.left * Time.deltaTime * slideSpeed, Space.World -1);
    }
}
