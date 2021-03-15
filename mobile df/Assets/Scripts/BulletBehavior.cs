using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public Bulletstat Bulletstat { get; set; }

    public float activeTime = 3.0f;
    public float spawnTime;

    public BulletBehavior()
    {
        Bulletstat = new Bulletstat(0, 0);
    }

    public GameObject character;

    public void Spawn()
    {
        gameObject.SetActive(true);
        spawnTime = Time.time;
    }

	void Start () {
        Spawn();
	}
	
	void Update () {
        if(Time.time - spawnTime >= activeTime)
        {
            gameObject.SetActive(false);
        }
        else
        {
            transform.Translate(Vector2.right * Bulletstat.speed * Time.deltaTime);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            gameObject.SetActive(false);
            other.GetComponent<MonsterStat>().attacked(Bulletstat.damage);
        }   
    }
}
