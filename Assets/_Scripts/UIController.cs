using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
   private GameObject Dialogo;
    public Text titulo;
    public Text descripcion;
    public MouseControl rotarcamara;
    
	void Start () {
        Dialogo = GameObject.FindWithTag("Dialogo");
        Dialogo.SetActive(false);
        Dialogo.transform.Find("BotonAceptar").gameObject.SetActive(false);
        Dialogo.transform.Find("BotonCancelar").gameObject.SetActive(false);
        rotarcamara.enabled = !rotarcamara.enabled;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //cerrar dialogos
        if (Input.GetKey(KeyCode.Escape))
        {
        
            Dialogo.SetActive(false);
        }

        }
    private void Update()
    {
        if (Input.GetKey(KeyCode.AltGr))
        {
            rotarcamara.enabled = !rotarcamara.enabled;
        }
    }
    public void Dialogo1()
    {  //hay que hacerlo con un if
        Dialogo.transform.Find("BotonAceptar").gameObject.SetActive(true);
        Dialogo.transform.Find("BotonCancelar").gameObject.SetActive(true);

        titulo.text = "Bandido Negociador";
        descripcion.text="Dialogo entre los personajes. Pulsar tecla 'Esc' para salir ";
        Dialogo.SetActive(true);
    }

    public void Pista()
    {   //hay que usar otro if 
        Dialogo.transform.Find("BotonAceptar").gameObject.SetActive(false);
        Dialogo.transform.Find("BotonCancelar").gameObject.SetActive(false);

        titulo.text = "Nombre de la pista";
        descripcion.text = "Descripcion de la pista. Pulsar la tecla 'Esc' para salir.";
        Dialogo.SetActive(true);
    }

 
}
