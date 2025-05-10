using UnityEngine;

/*
 * 추상 클래스(abstract class) 사용
 * 기본 기능을 정의하고, 자식 클래스에서 상속받아 구체적인 기능을 구현할 수 있도록 함
 * 상속 전용의 뼈대 클래스이다.
 * 3개의 스테이지가 같은 형태로 중복되므로, BaseStageController를 생성하여 상속받아 중복을 제거함
 * 새로운 스테이지가 발생하여도 확장에 용이하도록 수정됨
 * 
 * BaseStageController
 *  - FirstStageController
 *  - GameSceneController
 *  - ThirdStageController
 */
public abstract class BaseStageController : MonoBehaviour
{
    [SerializeField] protected SceneName nextScene; //Inspector에서 다음 씬을 지정할 수 있도록 함

    //virtual 키워드 : 자식 클래스에서 선택적으로 재정의(override) 가능한 메소드
    //자식클래스에서 오버라이드하지 않을 경우 기본형태인 아래와 같은 형태가 그대로 구현됨
    public virtual void f_ContinueButton()
    {
        GameManager.Instance.f_OpenScene(nextScene); //SceneName은 enum으로 지정되어 있으므로, Inspector에서 접근 가능
    }
}
