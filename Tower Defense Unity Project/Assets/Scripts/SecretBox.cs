using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretBox : MonoBehaviour {
    public static bool isShowNotiMenu = false;
    public static GameObject currentBox;
    void OnMouseDown()
    {
        isShowNotiMenu = true;
        currentBox = this.gameObject;
    }
}
