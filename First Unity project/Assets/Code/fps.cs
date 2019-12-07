using UnityEngine;
using TMPro;

public class fps : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnGUI()
    {
        float fps = Mathf.Round(1f / Time.deltaTime);
        Debug.Log(fps); 
    }
}
