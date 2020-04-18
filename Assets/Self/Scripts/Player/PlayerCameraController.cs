using UnityEngine;
using Photon.Pun;

public class PlayerCameraController : MonoBehaviourPun
{
    [SerializeField] private Transform characterBase;

    public Transform CharacterBase
    {
        get
        {
            return characterBase;
        }
        set
        {
            characterBase = value;
        }
    }

    [SerializeField] private float lookSpeed = 10f;

    [SerializeField] private float xRotationLimit = 60f;

    private float _camRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (characterBase.GetComponent<PhotonView>().IsMine)
        {
            LookAround();
        }
    }

    private void LookAround()
    {
        float y = Input.GetAxis("Mouse Y");
        float x = Input.GetAxis("Mouse X");

        _camRotation -= y * lookSpeed * Time.deltaTime * 10f;
        _camRotation = Mathf.Clamp(_camRotation, -xRotationLimit, xRotationLimit);

        transform.localRotation = Quaternion.Euler(_camRotation, 0f, 0f);

        characterBase.Rotate(x * lookSpeed * Time.deltaTime * 10f * Vector3.up);

        if (Input.GetMouseButton(0))
            Cursor.lockState = CursorLockMode.Locked;

        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.Confined;
    }
}
