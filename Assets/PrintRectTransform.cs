using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrintRectTransform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Max: " + GetComponent<RectTransform>().offsetMax);
        Debug.Log("Min: " + GetComponent<RectTransform>().offsetMin);
    }
}
