/*
 * 플레이어가 화면에 보이지 않는 더 위쪽까지 이동하면, 카메라가 따라 갈 수 없는 문제점 발생
 * 이 문제점을 해결하기 위해서는, 카메라가 플레이어를 따라다니며 움직일 수 있도록 스크립트 작성
 */
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject m_gPlayer = null; //플레이어 오브젝트 변수
    GameObject m_gCam = null;   //카메라 오브젝트 변수
    Vector3 vPlayerPos = Vector3.zero; //플레이어의 y좌표를 저장하기 위한 벡터 변수

    float fCamY = 0.0f; //카메라의 y좌표 변수
    bool isPlayerOnGround = false;  //플레이어가 지면에 닿았는지 여부 bool변수

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_gPlayer = GameObject.Find("player"); //Find 메소드를 사용ㅎ여 player 오브젝트를 찾아온다.
        m_gCam = GameObject.Find("Main Camera");//카메라 오브젝트 찾아온다
    }

    // Update is called once per frame
    void Update()
    {
        f_PlayerCamPosSync(); //플레이어의 위치와 메인 카메라의 위치를 동기화하는 메소드

        f_CamRangeLimit();  //카메라가 화면 아래를 보여주지 않도록 위치를 제한하는 메소드
    }

    void f_PlayerCamPosSync()
    {
        /*
         * 플레이어가 수직 이동할 때마다 카메라가 따라다니도록 프레임마다 플레이어 좌표를 구해서 저장
         * 플레이어 이동에 카메라가 따라가는 것은 Y축 방향(수직)의 변화이므로 위에서 구한 Y좌표값을 반영한다.
         * X, Z좌표는 변함이 없으므로 카메라의 원래 좌표를 그대로 사용
         */

        vPlayerPos = m_gPlayer.transform.position; //플레이어의 위치를 벡터 변수에 저장

        if (isPlayerOnGround == false)//플레이어가 바닥에 있는게 아니라면
        {
            transform.position = new Vector3(transform.position.x, vPlayerPos.y, transform.position.z); //메인 카메라의 y축 값을 플레이어 위치로 변경
        }
    }
    void f_CamRangeLimit()
    {
        if (vPlayerPos.y < 0.0f) //플레이어가 지면에 있을 경우 true로 변환
        {
            isPlayerOnGround = true;
        }
        else
        {
            isPlayerOnGround = false;
        }

        if (isPlayerOnGround == true)   //카메라의 y좌표를 0으로 고정하여 맵의 바깥을 보이지 않도록 고정
        {
            transform.position = new Vector3(transform.position.x, fCamY, transform.position.z);
        }
    }
}
