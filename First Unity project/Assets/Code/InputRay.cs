using UnityEngine;

public class InputRay : MonoBehaviour {
    public Transform player;
    public LayerMask ground;
    public Camera cam;
    public RectTransform rect;
    Ray Interact;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Interact = cam.ScreenPointToRay(gameObject.transform.position);
        RaycastHit hitpoint;
        Physics.Raycast(Interact, out hitpoint, 5f);

        if (hitpoint.collider != null)
        {
            rect.localScale = hitpoint.collider.tag == "interactable"? new Vector3(0.15f, 0.15f, 0.08814f): new Vector3(0.08814f, 0.08814f, 0.08814f);     
            if(hitpoint.collider.tag == "interactable" && Input.GetMouseButtonDown(0))
            {
                bool click = hitpoint.collider.GetComponent<SwitchInput>().clicked;
                hitpoint.collider.GetComponent<SwitchInput>().clicked = !click;
            }
        } else
        {
            rect.localScale = new Vector3(0.08814f, 0.08814f, 0.08814f);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(Interact);
    }

}
