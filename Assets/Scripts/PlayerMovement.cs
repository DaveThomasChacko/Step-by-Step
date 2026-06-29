using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Player;
    public GameObject RespawnPoint;
    public GameObject UpDirection;
    public GameObject DownDirection;
    public GameObject LeftDirection;
    public GameObject RightDirection;
    public int no_of_turns = 0;
    private int speed = 100000;
    public int TotalTurn;
    public Sprite playerSprite;
    public Sprite deadplayersprite;
    private bool notdead = true;
    public Text turncounter;
    public Text totalturncounter;
    public Text death_text;
    private Rigidbody2D rb;

    public LayerMask wallLayer;
    public LayerMask FinishLayer;
    [SerializeField] private AudioClip MoveAudioClip;
    [SerializeField] private AudioClip DeathAudioClip;
    [SerializeField] private AudioClip VictoryAudioClip;
    
    private AudioSource Asource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Asource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (notdead)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (!Physics2D.OverlapCircle(UpDirection.transform.position, 0.4f, wallLayer))
                {
                    rb.MovePosition(Vector2.MoveTowards(rb.position, UpDirection.transform.position, speed * Time.deltaTime));
                    no_of_turns += 1;
                    Asource.clip = MoveAudioClip;
                    Asource.Play();
                }
                if (Physics2D.OverlapCircle(UpDirection.transform.position, 0.4f, FinishLayer))
                {
                    rb.MovePosition(Vector2.MoveTowards(rb.position, UpDirection.transform.position, speed * Time.deltaTime));
                    Asource.clip = VictoryAudioClip;
                    Asource.Play();
                    SceneManager.LoadScene(2);
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (!Physics2D.OverlapCircle(DownDirection.transform.position, 0.4f, wallLayer))
                {
                    rb.MovePosition(Vector2.MoveTowards(rb.position, DownDirection.transform.position, speed * Time.deltaTime));
                    no_of_turns += 1;
                    Asource.clip = MoveAudioClip;
                    Asource.Play();
                }
                if (Physics2D.OverlapCircle(DownDirection.transform.position, 0.4f, FinishLayer))
                {
                    rb.MovePosition(Vector2.MoveTowards(rb.position, UpDirection.transform.position, speed * Time.deltaTime));
                    Asource.clip = VictoryAudioClip;
                    Asource.Play();
                    SceneManager.LoadScene(2);
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (!Physics2D.OverlapCircle(LeftDirection.transform.position, 0.4f, wallLayer))
                {
                    rb.MovePosition(Vector2.MoveTowards(rb.position, LeftDirection.transform.position, speed * Time.deltaTime));
                    no_of_turns += 1;
                    Asource.clip = MoveAudioClip;
                    Asource.Play();
                }
                if (Physics2D.OverlapCircle(LeftDirection.transform.position, 0.4f, FinishLayer))
                {
                    rb.MovePosition(Vector2.MoveTowards(rb.position, UpDirection.transform.position, speed * Time.deltaTime));
                    Asource.clip = VictoryAudioClip;
                    Asource.Play();
                    SceneManager.LoadScene(2);
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (!Physics2D.OverlapCircle(RightDirection.transform.position, 0.4f, wallLayer))
                {
                    rb.MovePosition(Vector2.MoveTowards(rb.position, RightDirection.transform.position, speed * Time.deltaTime));
                    no_of_turns += 1;
                    Asource.clip = MoveAudioClip;
                    Asource.Play();
                }
                if (Physics2D.OverlapCircle(RightDirection.transform.position, 0.4f, FinishLayer))
                {
                    rb.MovePosition(Vector2.MoveTowards(rb.position, UpDirection.transform.position, speed * Time.deltaTime));
                    Asource.clip = VictoryAudioClip;
                    Asource.Play();
                    SceneManager.LoadScene(2);
                }
            }
        }

        if (TotalTurn+1 <= no_of_turns)
        {
            GetComponent<SpriteRenderer>().sprite = deadplayersprite;
            notdead = false;
            Asource.clip = DeathAudioClip;
            Asource.Play();
            StartCoroutine(PlayerRespawn());
        }

        turncounter.text = "Steps : " + no_of_turns;
        totalturncounter.text = "Max Steps : " + TotalTurn;
    }

    private IEnumerator PlayerRespawn()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SampleScene");
        notdead = true;
        no_of_turns = 0;
        death_text.enabled = true;
        yield return new WaitForSeconds(1);
        death_text.enabled = false;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Replenish")
        {
            no_of_turns = Mathf.Max(0, no_of_turns - 11);
            Destroy(other.gameObject);
            
        }
    }
}