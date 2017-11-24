using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptController : MonoBehaviour {
    public GameObject [] targets;
    public GameObject player;
    //public GameObject goal_post;
    public Text Texto_Game_Over;
    public Text Texto_Points;

    private ArrayList eliminados;
    private int pontos;

    private int countFora;
    private bool gameOver = false;
    // Use this for initialization
    void Start () {
        eliminados = new ArrayList();
        Texto_Game_Over.text = "";
        pontos = 0;
        //Rigidbody rb = targets.GetComponent<Rigidbody>();
        //Debug.Log("start : " + targets[0].transform.position.x + " " + targets[0].transform.position.y + " " + targets[0].transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        for ( int i = 0; i < targets.Length; i++)
        {
            //se esta fora e nao esta na lista de eliminados
            if (targets[i].GetComponent<ScriptFora>().getFora() == true && !eliminados.Contains(i))
            {
                eliminados.Add(i);

                //controle de camera
                if (targets[i].GetComponent<Transform>().position.y > 3 && targets[i].GetComponent<Transform>().position.z > 0)
                {

                    GameObject cam2 = GameObject.FindWithTag("camera2");
                    GameObject cam_main = GameObject.FindWithTag("MainCamera");
                    cam2.GetComponent<ScriptCamera2>().Target = targets[i];
                    cam_main.GetComponent<Camera>().enabled = false;
                    cam2.GetComponent<Camera>().enabled = true;
                    StartCoroutine(mudaCam(cam_main,cam2));

                }
                

                //eliminados.removeat()
                /*pontos += 100;
                Texto_Points.text = ("Points: " + pontos);
                StartCoroutine(blink());*/
                AddPoints();
            }
            // esta dentro de volta depois de eliminado!
            if ( !targets[i].GetComponent<ScriptFora>().getFora() && eliminados.Contains(i))
            {
                eliminados.Remove(i);
            }
            //printEliminados();
            //if ( (eliminados.Count >= targets.Length && !gameOver) || player.GetComponent<ScriptFora>().getFora() )
            /*if ((eliminados.Count >= targets.Length) || player.GetComponent<ScriptFora>().getFora())
            {
                //PrintEliminados();
                gameOver = true;
                Texto_Game_Over.text = "Game Over";
                StartCoroutine(Example());
                //Application.Quit();
            }*/
            if (player.GetComponent<ScriptFora>().getFora())
            {
                //PrintEliminados();
                gameOver = true;
                Texto_Game_Over.text = "Game Over";
                StartCoroutine(EndGame());
                //Application.Quit();
            }
            //se todos os objetos foram eliminados da area
            if (eliminados.Count >= targets.Length)
            {
                //PrintEliminados();
                gameOver = true;
                Texto_Game_Over.text = "Parabéns, você fez " + pontos + " pontos";
                StartCoroutine(EndGame());
                //Application.Quit();
            }
        }

    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("first_scene", LoadSceneMode.Single);  
    }
    IEnumerator blink()
    {
        for(int i = 0; i < 3; i++)
        {
            Texto_Points.fontSize = 30;
            yield return new WaitForSeconds(0.5f);
            Texto_Points.fontSize = 20;
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    IEnumerator mudaCam(GameObject cam1, GameObject cam2)
    {
        yield return new WaitForSeconds(4f);
        cam2.GetComponent<Camera>().enabled = false;
        cam1.GetComponent<Camera>().enabled = true;
    }


    public void AddPoints()
    {
        pontos += 100;
        Texto_Points.text = ("Points: " + pontos);
        StartCoroutine(blink());
    }
    public void AddPointsGoal()
    {
        pontos += 1000;
        Texto_Points.text = ("Points: " + pontos);
        StartCoroutine(blink());
    }

    void PrintEliminados()
    {
        foreach ( int e in eliminados)
        {
            //Debug.Log("eliminado: " + e);
            Debug.Log("Game Over");
        }
    }
                            /*void Start()
                        {
                        StartCoroutine(Example());
                        }

                        */
}
