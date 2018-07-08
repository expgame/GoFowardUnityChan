using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	// キューブの移動速度
	private float speed = -0.2f;

	// 消滅位置
	private float deadLine = -10;

	// Use this for initialization
	void Start(){
		//AudioSource audio = GetComponent<AudioSource>();
		//audio.Play();
		//audio.Play(44100);
	}
		
	// Update is called once per frame
	void Update () {
		// キューブを移動させる
		transform.Translate (this.speed, 0, 0);

		// 画面外に出たら破棄する
		if (transform.position.x < this.deadLine) {
			Destroy (gameObject);
		}
	}

	 void OnCollisionEnter2D(Collision2D coll) {
		//地面に着いたら音を鳴らす
		if (coll.gameObject.tag == "Ground") {
			coll.gameObject.GetComponent<AudioSource>().Play();
		}

		//cube 同士が重なったら音を鳴らす
		else if (coll.gameObject.tag == "Cube") {
			coll.gameObject.GetComponent<AudioSource>().Play();
		}

		//Unityちゃんだった場合音を消す
		else   {
			coll.gameObject.GetComponent<AudioSource>().Stop();
		}
	}
}