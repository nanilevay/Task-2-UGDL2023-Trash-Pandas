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
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    private void Update()
    {
        //Player continuos movement
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        Swipe();
    }

    private void Swipe()
    {
        //Takes care of all touch mechanics

        //Detects start of touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Gets start Pos of finger
            startTouchPos = Input.GetTouch(0).position;
            Debug.Log("Start");
        }

        //Detects End of touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            //Gets the last Pos of the finger
            endTouchPos = Input.GetTouch(0).position;
            Debug.Log("End");

            //Sees what side the player was sent
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


            if (multipleTap)
            {
                //Sees if it was tapped 2 times
                if (Input.GetTouch(0).tapCount == 2)
                {
                    TapAtk();
                }
            }

            else
            {
                //Sees if it was a tap (stationary = is the tap thingy)
                if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Stationary)
                {
                    TapAtk();
                }
            }
        }
    }

    //Takes care of movement

    private void MoveLeft()
    {

        if (this.transform.position.x > limitLeft)
        {
            transform.Translate(Vector3.left * Time.deltaTime * slideSpeed, Space.World);
        }

        if (enemyDetect == true)
        {
            playerAtk = true;
        }


    }

    private void MoveRight()
    {
        if (this.transform.position.x > limitRight)
        {
            transform.Translate(Vector3.left * Time.deltaTime * slideSpeed, Space.World - 1);
        }

        if (enemyDetect == true)
        {
            playerAtk = true;
        }
    }

    //Takes care of the ATK
    private void TapAtk()
    {
        Debug.Log("Tap&Hold");

        //"Jump animation"
        transform.Translate(Vector3.up * Time.deltaTime * slideSpeed, Space.World);

        //If the tap was made in the Left side of screen
        if (Input.touches[0].position.x < Screen.width / 3)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("MoveL");
                MoveLeft();
            }
        }


        //If the tap was made in the Right side of screen
        if (Input.touches[0].position.x > Screen.width / 3)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("MoveR");
                MoveRight();
            }
        }

        ////If the tap was made in the middle (ifk if it'll be used)
        //else
        //{
        //    //JumpAnim
        //}
    }

    //Checks Enemy collisions using "Enemy" tag
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyDetect = true;

            if (playerAtk)
            {
                Destroy(other.gameObject);
                Debug.Log("Destroy");
            }

            else
            {
                //incert what we do with palyer if they fail to ATK i guess?
            }
        }
    }
}
