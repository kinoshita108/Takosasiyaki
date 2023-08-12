using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManAnimation : MonoBehaviour
{
    // �ǂ̃A�j���[�V�������g����������
    public string upAnime = "";
    public string downAnime = "";
    public string leftAnime = "";
    public string rightAnime = "";
    public string standAnime_l = "";
    public string standAnime_r = "";

    // �����X�s�[�h
    public float speed = 2.0f;

    // ���̃A�j���[�V����
    string modeNow = "";

    // ���������ƈʒu
    float vx = 0;
    float vy = 0;

    // Start is called before the first frame update
    void Start()
    {
        // ���߂͑O�𔍂�����Ԃ���X�^�[�g
        modeNow = standAnime_r;
    }

    // Update is called once per frame
    void Update()
    {
        // ��������ɂO�ɖ߂��i�߂��Ȃ��ƁA�����Ƃ��̕����ɐi��ł��܂��j
        vx = 0;
        vy = 0;

        // ���������p�Ɉړ����A�A�j���[�V�������w�肷��
        if (Input.GetKey("up"))
        {
            modeNow = upAnime;
            vy = speed * 2;
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
        else if (Input.GetKeyUp("right"))
        {
            modeNow = standAnime_r;
        }
        else if (Input.GetKeyUp("left"))
        {
            modeNow = standAnime_l;
        }
    }
    void FixedUpdate()
    {
        // �ړ�
        this.transform.Translate(vx / 50, vy / 50, 0);
        // �A�j���[�V�����̐؂�ւ�
        this.GetComponent<Animator>().Play(modeNow);
    }
}
