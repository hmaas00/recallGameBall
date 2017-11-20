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
            //Debug.Log("var " + t.GetType().GetField("fora"));
            if (targets[i].GetComponent<ScriptFora>().getFora() == true && !eliminados.Contains(i))
            {
                eliminados.Add(i);
                /*pontos += 100;
                Texto_Points.text = ("Points: " + pontos);
                StartCoroutine(blink());*/
                AddPoints();
            }
            //printEliminados();
            if ( (eliminados.Count >= targets.Length && !gameOver) || player.GetComponent<ScriptFora>().getFora() )
            {
                //PrintEliminados();
                gameOver = true;
                Texto_Game_Over.text = "Game Over";
                StartCoroutine(Example());
                //Application.Quit();
            }
        }

    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(3);
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
