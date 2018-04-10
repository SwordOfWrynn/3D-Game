using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //Calculate movement velocity as a 3D vector
        float xmove = Input.GetAxisRaw("Horizontal");
        float zmove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xmove;
        Vector3 moveVertical = transform.forward * zmove;

        //Final movement vector
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        //Apply movement
        motor.Move(velocity);
    }
}
