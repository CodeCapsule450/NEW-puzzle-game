using UnityEngine;

public class movement : MonoBehaviour {
    public Animator anim;
    public LayerMask ground;

    public float rotateSpeed;
    public float movementSpeed;
    public float jumpforce;
    float aY = -0.023f;
    float vY;
    float axisTD;
    float axisLR;

    Vector3 vertical;
    Vector3 horizontal;

    public CharacterController Char;
    [SerializeField] private string axisH;


    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        axisTD = Input.GetAxisRaw("Vertical");
        axisLR = Input.GetAxisRaw("Horizontal");
        float rotY = Input.GetAxisRaw(axisH) * rotateSpeed * Time.deltaTime;

        transform.Rotate(0f, rotY, 0f);
        anim.SetBool("move?", axisLR != 0f || axisTD != 0f);
    }

    private void FixedUpdate()
    {
        if (!Char.isGrounded)
        {
            vY = getrayHit() ? 0.016f : vY;
        }
        else
        {
            vY = Input.GetKey(KeyCode.Space) ? jumpforce : 0f;
        }

        vY += aY ;

        Char.Move( 
                 (transform.forward* axisTD + transform.right *axisLR ) * movementSpeed 
                 + 
                 new Vector3(0f, vY, 0f)
                 );
    }

    bool getrayHit()
    {
        return Physics.Raycast(transform.position, Vector3.up,0.50f,ground);
    }



}
