using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnUpgraderScript : MonoBehaviour
{
    [SerializeField] private GameObject upgrader;
    [SerializeField] private AudioClip UpgradeAudioClip;
    private AudioSource ASource;
    // Start is called before the first frame update
    void Start()
    {
        ASource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "TurnUpgrade")
        {
            GetComponent<PlayerMovement>().TotalTurn += 5;
            GetComponent<PlayerMovement>().no_of_turns = 0;
            Destroy(other.gameObject);
            ASource.clip = UpgradeAudioClip;
            ASource.Play();
        }
    }
}
