using UnityEngine;

public class GameSceneController : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //GameManager.Instance.f_OpenScene("GameScene");
    }

    public void f_ContinueButton()
    {
        GameManager.Instance.f_OpenScene("ThirdStage");//3스테이지 이동
    }


}
