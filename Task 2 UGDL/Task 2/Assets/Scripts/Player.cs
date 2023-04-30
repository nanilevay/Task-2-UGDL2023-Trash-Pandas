using UnityEngine;

public class Player : MonoBehaviour
{
    //Speed for Movement and Slide
    [SerializeField] private float moveSpeed;
    [SerializeField] private float slideSpeed;

    //Limit Player movement for left side & right side
    [SerializeField] private float limitRight;
    [SerializeField] private float limitLeft;

    //Enemy detection
    [SerializeField] private bool playerAtk;
    [SerializeField] private bool enemyDetect;

    //Toggle on Unity Insp to try the diff ones without going through the code
    [SerializeField] private bool multipleTap;

    //Touch controlls
    [SerializeField] private bool isTouching;
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    private void Update()
    {
        //Player continuos movement
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        Swipe();

        ////FOR TESTING
        //if (Input.GetKeyUp("f"))
        //{

        //}
    }

    private void Swipe()
    {
        //Takes care of all touch mechanics

        Touch touch = Input.GetTouch(0);
        //Detects start of touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Gets start Pos of finger
            startTouchPos = Input.GetTouch(0).position;
            Debug.Log("Start");
            isTouching = true;
        }

        //Detects End of touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            //Gets the last Pos of the finger
            endTouchPos = Input.GetTouch(0).position;
            Debug.Log("End");

            if (isTouching)
            {
                //Sees what side the player was sent
                if (endTouchPos.x > startTouchPos.x)
                {
                    Debug.Log("MoveR");
                    MoveRight();
                }

                if (endTouchPos.x < startTouchPos.x)
                {
                    Debug.Log("MoveL");
                    MoveLeft();
                }


                if (multipleTap)
                {
                    //Sees if it was tapped 2 times
                    if (Input.GetTouch(0).tapCount == 2)
                    {
                        TapAtk();
                    }
                }

                //Hold ATK  (NOT WORKING (for some reason =_=))
                //else
                //{
                //    //Sees if it was a tap (stationary = is the tap thingy)
                //    if (touch.phase == TouchPhase.Stationary)
                //    {
                //        TapAtk();
                //    }
                //}
            }

            isTouching = false;
        }
    }

    //Takes care of movement

    private void MoveLeft()
    {
        if (this.transform.position.x > limitLeft)
        {
            transform.Translate(-2, 0, 0 * Time.deltaTime * slideSpeed, Space.World);
        }

        if (enemyDetect == true)
        {
            playerAtk = true;
        }
    }

    private void MoveRight()
    {
        if (this.transform.position.x < limitRight)
        {
            transform.Translate(2, 0, 0 * Time.deltaTime * slideSpeed, Space.World - 1);
        }

        if (enemyDetect == true)
        {
            playerAtk = true;
        }
    }

    //Takes care of the ATK
    private void TapAtk()
    {
        //"Jump animation"


        //If the tap was made in the Left side of screen
        if (Input.touches[0].position.x < Screen.width / 2)
        {
            transform.Translate(0, 2, 0 * Time.deltaTime * slideSpeed, Space.World);
            MoveLeft();

            Debug.Log("MoveL");
        }


        //If the tap was made in the Right side of screen
        if (Input.touches[0].position.x > Screen.width / 2)
        {

            transform.Translate(0, 2, 0 * Time.deltaTime * slideSpeed, Space.World);
            MoveRight();

            Debug.Log("MoveR");
        }
    }

    //Checks Enemy collisions using "Enemy" tag
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (isTouching)
            {
                enemyDetect = true;

                if (playerAtk)
                {
                    Destroy(other.gameObject);
                    Debug.Log("Destroy");
                }
            }

            else
            {
                //incert what we do with palyer if they fail to ATK i guess?
            }
        }
    }

}
