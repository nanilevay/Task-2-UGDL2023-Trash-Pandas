using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float slideSpeed;

    [SerializeField] private float limitRight;
    [SerializeField] private float limitLeft;

    [SerializeField] private bool playerAtk;
    [SerializeField] private bool enemyDetect;

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
            {
                Debug.Log("Tap");

                if (enemyDetect == true)
                {
                    //animator to do "slide atk"
                }

                playerAtk = true;

            }

            
        }
    }

    private void MoveLeft()
    {
        if(this.transform.position.x > limitLeft)
            transform.Translate(Vector3.left * Time.deltaTime * slideSpeed, Space.World);

        if (enemyDetect == true)
        {
            //animator to do "jump animation"
        }

        playerAtk = true;
    }

    private void MoveRight()
    {
        if (this.transform.position.x > limitRight)
            transform.Translate(Vector3.left * Time.deltaTime * slideSpeed, Space.World -1);

        if (enemyDetect == true)
        {
            //animator to do "jump animation"
        }

        playerAtk = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            enemyDetect = true;

            if(playerAtk)
            {
                Destroy(other.gameObject);
                Debug.Log("Destroy");
            }
        }
    }
}
