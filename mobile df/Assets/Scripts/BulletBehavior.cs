using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public Bulletstat Bulletstat { get; set; }

    public float activeTime = 3.0f;
    

    public BulletBehavior()
    {
        Bulletstat = new Bulletstat(0, 0);
    }

    public GameObject character;

    public void Spawn()
    {
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        StartCoroutine(BulletInactive(activeTime));
    }

    IEnumerator BulletInactive(float activeTime)
    {
        yield return new WaitForSeconds(activeTime);
        gameObject.SetActive(false);
    }

    void Start () {
	}
	
	void Update () {
            transform.Translate(Vector2.right * Bulletstat.speed * Time.deltaTime);
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
