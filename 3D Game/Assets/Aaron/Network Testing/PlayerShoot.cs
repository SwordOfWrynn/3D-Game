using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {

    public PlayerWeapon weapon;

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask mask;

    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("PlayerShoot script needs a camera reference!");
            this.enabled = false;
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward,out hit, weapon.range, mask))
        {
            Debug.Log("We hit " + hit.collider.name);
        }
    }

}
