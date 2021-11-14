using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour
{
    public float velocidad = 30.0f;
    AudioSource fuenteDeAudio;
    public AudioClip audioRaqueta, audioRebote, SonidoFinal, SonidoGanar, AudioChoque;
    public int perder = 0;
    public int punto = 0;
    public Text Puntos;
    public Text VidasPerdidas;
    public GameObject Reiniciarlo;
    public GameObject Ganaste;
    public GameObject block;
    public GameObject Facil;
    public GameObject Normal;
    public GameObject Dificil;
    public GameObject FacilAudio;
    public GameObject NormallAudio;
    public GameObject DificilAudio;
    public GameObject Perder1Audio;
    public Vector3 startPosition;
    
    void Awake(){
        startPosition=transform.position;
    }

    void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.down * velocidad;
        fuenteDeAudio = GetComponent<AudioSource>();
        VidasPerdidas.text = perder.ToString();
        GetComponent<Rigidbody2D>().velocity = Vector3.down *velocidad;
    }
    
    void OnCollisionEnter2D(Collision2D micolision){
        if (micolision.gameObject.name == "Raqueta"){
            int y = 1;
            int x = direccionx(transform.position, micolision.transform.position);
            Vector3 direccion = new Vector3(x, y);
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();
        }
        if (micolision.gameObject.name == "Abajo")
        {
            perder++;
            VidasPerdidas.text = perder.ToString();
            transform.position=startPosition;
            Perder1Audio.SetActive(false);
        }

        if (perder >= 3)
        {
            fuenteDeAudio.clip = SonidoFinal;
            fuenteDeAudio.Play();
            GetComponent<Rigidbody2D>().velocity = Vector2.right *0;
            Destroy(this.gameObject,2f);
            Reiniciarlo.SetActive(true);
        }
        if (micolision.gameObject.name == "Arriba")
        {
            fuenteDeAudio.clip = audioRebote;
            fuenteDeAudio.Play();
        }
        if (micolision.gameObject.tag == "destruirblock")
        {
            punto++;
            Puntos.text = punto.ToString();
            fuenteDeAudio.clip = AudioChoque;
            fuenteDeAudio.Play();
            Destroy(micolision.collider.gameObject);
        }
        
        if (punto<25)
        {
            FacilAudio.SetActive(true);
        }
        if (punto>=25)
        {
            velocidad = 36;
            Facil.SetActive(false);
            Normal.SetActive(true);
            FacilAudio.SetActive(false);
            NormallAudio.SetActive(true);
        }
        if (punto>=45)
        {
            velocidad = 50;
            Normal.SetActive(false);
            Dificil.SetActive(true);
            NormallAudio.SetActive(false);
            DificilAudio.SetActive(true);
        }
        if (punto>=96)
        {
            velocidad = 0;
            fuenteDeAudio.clip = SonidoGanar;
            fuenteDeAudio.Play();
            Ganaste.SetActive(true);
            Destroy(this.gameObject,2.65f);
            GetComponent<Rigidbody2D>().velocity = Vector3.zero *velocidad;
            DificilAudio.SetActive(false);
        }
        }

    int direccionx(Vector3 posicionBola, Vector3 posicionRaqueta)
    {
        if (posicionBola.x > posicionRaqueta.x)
        {
            return 1;
        }
        else if (posicionBola.x < posicionRaqueta.x)
        {
            return -1;
        }
        else
        {
            return 0;
        }
        
    }
    public void reiniciarBola(string direccion)
    {
        fuenteDeAudio.clip = audioRebote;
        fuenteDeAudio.Play();

    }
    void Update ()
    {

        if (perder !=0)
        {Perder1Audio.SetActive(true);}


    }
}