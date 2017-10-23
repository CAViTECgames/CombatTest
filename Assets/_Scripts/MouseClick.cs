using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour {
    public UIController dialogos;

    void OnMouseDown()
    {
        dialogos.Dialogo1();
    }
}
