using UnityEngine;

public class FirstStageController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundManager.Instance.f_StopAllBGM();   //재생중인 배경음악 재생 중지
        SoundManager.Instance.f_AutoPlayBGM();  //씬에 해당하는 배경음악 재생
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void f_ContinueButton()
    {
        GameManager.Instance.f_OpenScene(SceneName.GameScene); //스테이지2(GameScene)으로 이동
    }

}
