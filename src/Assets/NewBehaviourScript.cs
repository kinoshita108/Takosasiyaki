using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // どのアニメーションを使うかを入れる
    public string upAnime = "";
    public string downAnime = "";
    public string leftAnime = "";
    public string rightAnime = "";
    public string standAnime_l = "";
    public string standAnime_r = "";

    // 歩くスピード
    public float speed = 2.0f;

    // 今のアニメーション
    string modeNow = "";

    // 歩く方向と位置
    float vx = 0;
    float vy = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 初めは前を剥いた状態からスタート
        modeNow = downAnime;

        modeNow = standAnime_r;
    }

    // Update is called once per frame
    void Update()
    {
        // 方向を常に０に戻す（戻さないと、ずっとその方向に進んでしまう）
        vx = 0;
        vy = 0;

        // 押した方角に移動し、アニメーションを指定する
        if (Input.GetKey("up"))
        {
            modeNow = upAnime;
            vy = speed*2;
        }
        else if (Input.GetKey("down"))
        {
            modeNow = downAnime;
            vy = -speed;
        }
        else if (Input.GetKey("left"))
        {
            modeNow = leftAnime;
            vx = -speed;
        }
        else if (Input.GetKey("right"))
        {
            modeNow = rightAnime;
            vx = speed;
        }
        else if(Input.GetKeyUp("right"))
        {
            modeNow = standAnime_r;
        }
        else if (Input.GetKeyUp("left"))
        {
            modeNow = standAnime_l;
        }
        /*else
        {
                modeNow = standAnime_r;
        }*/
    }
    void FixedUpdate()
    {
        // 移動
        this.transform.Translate(vx / 50, vy / 50, 0);
        // アニメーションの切り替え
        this.GetComponent<Animator>().Play(modeNow);
    }
}
