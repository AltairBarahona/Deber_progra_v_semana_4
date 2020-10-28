using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarCamaras : MonoBehaviour
{
    public Camera primeraPersonaCam;
    public Camera terceraPersonaCam;
    public Camera estrategiaCam;

    
    private Camera camaraActual;
    int i;
    
    // Start is called before the first frame update
    void Start()
    {
        i=0;
        terceraPersonaCam.enabled=true;
        primeraPersonaCam.enabled=false;
        estrategiaCam.enabled=false;
                
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            Debug.Log("presionada p");
                if(i==0){
                    terceraPersonaCam.enabled=false;
                    primeraPersonaCam.enabled=true;
                    estrategiaCam.enabled=false;
                    i++;
                }else if(i==1){
                    terceraPersonaCam.enabled=false;
                    primeraPersonaCam.enabled=false;
                    estrategiaCam.enabled=true;
                    i++;
                }else if(i==2){
                    
                    terceraPersonaCam.enabled=true;
                    primeraPersonaCam.enabled=false;
                    estrategiaCam.enabled=false;
                    i=0;
                }
        }

    }

    
}
