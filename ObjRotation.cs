using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotation : MonoBehaviour
{

    public SerialHandler _SerialHandler;　//SerialHandler.csの参照
    Vector3 rotation;

    // Update is called once per frame
    void Update()
    {
        objRotation(_SerialHandler.message_);
    }

    void objRotation(string message)
    {
        string[] a;

        a = message.Split("="[0]);
        if (a.Length != 2) return;
        int v = int.Parse(a[1]);
        switch (a[0])
        {
            case "zero":
                Debug.Log("0");
                Debug.Log(a[0]);
                Debug.Log(a[1]);
                break;
            case "one":
                Debug.Log("1");
                break;
            case "two":
                Debug.Log("2");
                break;
            case "three":
                Debug.Log("3");
                break;
            case "none":
                Debug.Log("9");
                break;
        }
        Quaternion AddRot = Quaternion.identity;
        AddRot.eulerAngles = new Vector3(-rotation.x, 0, -rotation.y);

        transform.rotation = AddRot;
    }
}