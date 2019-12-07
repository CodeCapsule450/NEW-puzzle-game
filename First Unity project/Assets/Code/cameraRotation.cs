using UnityEngine;

public class cameraRotation : MonoBehaviour {

    [SerializeField] private string axisV;

    public float rotationSpeed;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update () {

        float Axis = -Input.GetAxisRaw(axisV);
        float rotX = Axis* rotationSpeed * Time.deltaTime;

        bool clampDown = transform.eulerAngles.x < 75f ;
        bool clampUp = transform.eulerAngles.x > 290f;

        transform.Rotate
        (clampDown || clampUp ?
         rotX : transform.eulerAngles.x < 180f & !clampDown & Axis > 0 ? 0f : transform.eulerAngles.x > 180f & !clampUp & Axis < 0 ? 0f : rotX,
         0,
         0
        );

    }
}
