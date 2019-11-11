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
            case "num":
                Debug.Log("0");
                break;
            case "none":
                Debug.Log("2");
                break;
        }
        Quaternion AddRot = Quaternion.identity;
        AddRot.eulerAngles = new Vector3(-rotation.x, 0, -rotation.y);

        transform.rotation = AddRot;
    }
}