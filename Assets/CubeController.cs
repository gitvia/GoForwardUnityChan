using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    //キューブ接触時の音源
    private AudioSource audioSource;

    //キューブの移動速度
    private float speed = -0.2f;

    //消滅位置
    private float deadline = -10;

	// Use this for initialization
	void Start () {
        this.audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        //画面外に出たら破棄する
        if (transform.position.x < this.deadline)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //キューブもしくは地面と接触したとき音を鳴らす
        if (collision.gameObject.tag == "Cube" || collision.gameObject.tag=="Ground")
        {
            //オーディオを再生
            this.audioSource.Play();
        }
    }
}
