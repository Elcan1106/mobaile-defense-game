using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public Bulletstat Bulletstat { get; set; }

    public BulletBehavior()
    {
        Bulletstat = new Bulletstat(0, 0);
    }

    public GameObject character;


	void Start () {
        Destroy(gameObject, 3.0f);
	}
	
	void Update () {
        transform.Translate(Vector2.right * Bulletstat.speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
            other.GetComponent<MonsterStat>().attacked(Bulletstat.damage);
        }   
    }
}
