using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float slideSpeed;
    [SerializeField] private bool jumpAtk;

    [SerializeField] private GameObject player;

    //private Vector2 startTouchPos;
    //private Vector2 endTouchPos;
    private Vector2 movement;

    private Rigidbody rb;

    private void Start()
    {
        player = this.gameObject;
        rb = GetComponent<Rigidbody>();
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        //Swipe();
    }

   //private void Swipe()
   // {
   //     if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
   //     {
   //         startTouchPos = Input.GetTouch(0).position;
   //         Debug.Log("Start");
   //     }

   //     if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
   //     {
   //         endTouchPos = Input.GetTouch(0).position;
   //         Debug.Log("End");

   //         if (endTouchPos.x < startTouchPos.x)
   //         {
   //             Debug.Log("MoveR");
   //             MoveRight();
   //         }

   //         if (endTouchPos.x > startTouchPos.x)
   //         {
   //             Debug.Log("MoveL");
   //             MoveLeft();
   //         }
   //     }
    //}

    private void MoveLeft()
    {
        player.transform.Translate(player.transform.position.x + 2 * Time.deltaTime * slideSpeed, 0, 0);
    }

    private void MoveRight()
    {
        player.transform.Translate(player.transform.position.x - 2 * Time.deltaTime * slideSpeed, 0, 0);
    }
}
