using UnityEngine;
using System.Collections;

public class end : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnClick()
    { // MUST public
    Application.Quit();
    }

}
