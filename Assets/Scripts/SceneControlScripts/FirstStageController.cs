using UnityEngine;

public class FirstStageController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundManager.Instance.f_StopAllBGM();   //������� ������� ��� ����
        SoundManager.Instance.f_AutoPlayBGM();  //���� �ش��ϴ� ������� ���
    }

    // Update is called once per frame
    void Update()
    {
        //GameManager.Instance.f_OpenScene("GameScene");
    }

    public void f_ContinueButton()  //2�������� �̵�
    {
        GameManager.Instance.f_OpenScene("GameScene");
    }


}
