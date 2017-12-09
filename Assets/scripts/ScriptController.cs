using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptController : MonoBehaviour {
    private GameObject [] targets;
    private GameObject player;
    //public GameObject goal_post;
    private Text Texto_Game_Over;
    private Text Texto_Points;

    private ArrayList eliminados;
    //private int pontos;

    public GameObject PointKeeper;

    private int countFora;
    private bool isGameOver = false; // bad ending
    private bool isPassed = false; // good ending


    /*
      void Start()
 {
     SceneManager.sceneLoaded += OnSceneLoaded;
 }
 private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
 {
     // do whatever you like
 }
         */

    // Use this for initialization
    void Awake () {
        //DontDestroyOnLoad(gameObject);
        
        //DontDestroyOnLoad( GameObject.FindGameObjectWithTag("Player") );
        //DontDestroyOnLoad(GameObject.FindGameObjectWithTag("camera2"));
        //SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        //SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        eliminados = new ArrayList();
        // vincular gui
        Texto_Game_Over = GameObject.Find("Text_Game_Over").GetComponent<Text>();
        Texto_Points = GameObject.Find("Text_Points").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
        Texto_Game_Over.text = "";
        PointKeeper = GameObject.Find("ScoreKeeper");
        DontDestroyOnLoad(PointKeeper);
        Texto_Points.text = ("Points: " + PointKeeper.GetComponent<ScriptScoreKeeper>().getPoints());
        //pontos = 0;
        targets = GameObject.FindGameObjectsWithTag("shootable");
        //GameObject.FindGameObjectWithTag("camera2").GetComponent<ScriptCamera2>().Target = GameObject.FindGameObjectWithTag("Player");
        //Rigidbody rb = targets.GetComponent<Rigidbody>();
        //Debug.Log("start : " + targets[0].transform.position.x + " " + targets[0].transform.position.y + " " + targets[0].transform.position.z);
    }

   /* private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        //Debug.Log("esta cena foi carregada: " + SceneManager.GetActiveScene().name);
        //Texto_Game_Over = (Text)GameObject.Find("Text_Game_Over");
        //Texto_Points = (Text)GameObject.Find("Text_Points");

    }*/
    /*
    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        targets = GameObject.FindGameObjectsWithTag("shootable");
        GameObject.FindGameObjectWithTag("camera2").GetComponent<ScriptCamera2>().Target = GameObject.FindGameObjectWithTag("Player");
    }*/

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("começou a cena!!!");
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
                    cam2.GetComponent<ScriptCamera2>().SetTarget(targets[i]);
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
                
                Texto_Game_Over.text = "Game Over";
                StartCoroutine(BadEnding());
                isGameOver = true;
                //Application.Quit();
            }
            //se todos os objetos foram eliminados da area
            if (eliminados.Count >= targets.Length)
            {
                //PrintEliminados();

                //Texto_Game_Over.text = "Parabéns, você fez " + pontos + " pontos";
                Texto_Game_Over.text = "Parabéns, você fez " + PointKeeper.GetComponent<ScriptScoreKeeper>().getPoints() + " pontos";
                

                StartCoroutine(GoodEnding());
                isPassed = true;
                //Application.Quit();
            }
        }

    }
    IEnumerator BadEnding()
    {
        //so toca se jogo nao tiver terminado e nao tiver sido passado
        if (!isGameOver && !isPassed) // bad ending
        {
            isGameOver = true;
            GetComponent<AudioSource>().Play(); // sound end game
        }
        yield return new WaitForSeconds(5);
    }
    IEnumerator GoodEnding()
    {
        Debug.Log("active scene: " + SceneManager.GetActiveScene().name);
        //name of the scene
        //Scene_xx
        //01234567

        string s = SceneManager.GetActiveScene().name;
        // change s to represent next scene
        string s_num = s.Substring(6); // get num part
        s = s.Substring(0, 6); // change s to Scene_ form
        int x = int.Parse(s_num) + 1; // add 1
        s_num = x.ToString();// change back to string
        s = (s + s_num); // concat new scene's name
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(s, LoadSceneMode.Single); // load next scene!
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

        //pontos += 100;
        PointKeeper.GetComponent<ScriptScoreKeeper>().AddPoints(100);
        //Texto_Points.text = ("Points: " + pontos);
        Texto_Points.text = ("Points: " + PointKeeper.GetComponent<ScriptScoreKeeper>().getPoints());
        StartCoroutine(blink());
    }
    public void AddPointsGoal()
    {
        //pontos += 1000;
        PointKeeper.GetComponent<ScriptScoreKeeper>().AddPoints(1000);
        Texto_Points.text = ("Points: " + PointKeeper.GetComponent<ScriptScoreKeeper>().getPoints());
        StartCoroutine(blink());
    }

    void PrintEliminados()
    {
        foreach ( int e in eliminados)
        {
            Debug.Log("eliminado: " + e);
            Debug.Log("Game Over");
        }
    }
}
