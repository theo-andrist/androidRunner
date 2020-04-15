﻿using UnityEngine;

public class CharacterCameraController : MonoBehaviour
{
    public Transform characterBase;
    public float lookSpeed = 10f;

    public Transform head;
    public float xRotationLimit = 75f;

    private float _camRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float y = Input.GetAxis("Mouse Y");
        float x = Input.GetAxis("Mouse X");

        _camRotation -= y * lookSpeed * Time.deltaTime * 10f;
        _camRotation = Mathf.Clamp(_camRotation, -xRotationLimit, xRotationLimit);

        transform.localRotation = Quaternion.Euler(_camRotation, 0f, 0f);
        head.transform.localRotation = Quaternion.Euler(0f, 0f, _camRotation);

        characterBase.Rotate(x * lookSpeed * Time.deltaTime * 10f * Vector3.up);
        
        if (Input.GetMouseButton(0))
            Cursor.lockState = CursorLockMode.Locked;

        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.Confined;
    }
}
