using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ahorcado : MonoBehaviour
{
    public string palabra = "palabra";
    TMP_Text[] letras;
    public GameObject letra;
    public Transform acomodoar;
    public TMP_InputField input;
    public TMP_Text puntuacion;
    int errores;

    // Start is called before the first frame update
    void Start()
    {
        letras = new TMP_Text[palabra.Length];

        for (int i = 0; i < palabra.Length; i++)
            letras[i] = Instantiate(letra, acomodoar).GetComponent<TMP_Text>();
    }


    public void RevisarLetra()
    {
        bool correcto = false;
        for(int i = 0; i < palabra.Length; i++)
        {
            if(palabra[i].ToString().ToLower() == input.text.ToLower())
            {
                letras[i].text = input.text; 
                correcto = true;
            }
        }

        if (!correcto)
        {
            errores++;
            puntuacion.text += "I"; 

            if(errores > 3)
            {
                puntuacion.text = "Perdiste";
            }
        }

        int buenas = 0;
        for(int i = 0; i < letras.Length; i++)
        {
            if (!string.IsNullOrEmpty(letras[i].text))
            {
                buenas++;
            }
        }
        
        if(buenas >= palabra.Length)
        {
            puntuacion.text = "Ganaste";
            puntuacion.color = Color.green;
        }
    }
}
