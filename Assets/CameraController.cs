using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject gPlayer = null; //플레이어 오브젝트 변수
    Vector3 vPlayerPos = Vector3.zero; //플레이어의 위치를 저장하기 위한 벡터 변수

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gPlayer = GameObject.Find("player"); //Find 메소드를 사용ㅎ여 player 오브젝트를 찾아온다.
    }

    // Update is called once per frame
    void Update()
    {
        f_PlayerCamPosSync(); //플레이어의 위치와 메인 카메라의 위치를 동기화하는 메소드
    }

    void f_PlayerCamPosSync()
    {
        vPlayerPos = gPlayer.transform.position; //플레이어의 위치를 벡터 변수에 저장

        transform.position = new Vector3(transform.position.x, vPlayerPos.y, transform.position.z); //메인 카메라의 y축 값을 플레이어 위치로 변경
    }
}
