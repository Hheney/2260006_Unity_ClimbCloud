using UnityEngine;

public class TitleUIController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void f_GameStart()
    {
        SoundManager.Instance.f_StopBGM(SoundName.BGM_Title);
        SoundManager.Instance.f_PlayBGM(SoundName.BGM_StageBGM1, 0.1f);
        GameManager.Instance.f_GameStart();
    }
}
