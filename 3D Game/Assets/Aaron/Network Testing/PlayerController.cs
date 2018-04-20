using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float rotationSpeed = 10f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //Calculate movement velocity as a 3D vector
        float xmove = Input.GetAxis("Horizontal");
        float zmove = Input.GetAxis("Vertical");

        Vector3 moveHorizontal = transform.right * xmove;
        Vector3 moveVertical = transform.forward * zmove;

        //Final movement vector
        Vector3 velocity = (moveHorizontal + moveVertical) * speed;

        //Apply movement
        motor.Move(velocity);

        //Calculate rotation as a 3D vector for turning
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * rotationSpeed;

        //Apply rotation
        motor.Rotate(rotation);

        //Calculate camera rotation as a 3D vector for turning
        float xRot = Input.GetAxisRaw("Mouse Y");

        float cameraRotationX = xRot * rotationSpeed;

        //Apply camera rotation
        motor.RotateCamera(cameraRotationX);
    }
    
}
