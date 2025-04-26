### 🔧 기능 추가 내역

#### 1. 🪂 강화 점프 기능 (Reinforced Jump)
- 스페이스바를 누르고 있는 시간에 비례하여 점프 높이가 강화되는 시스템 구현
- 최소/최대 점프력을 `Mathf.Lerp()`를 통해 선형 보간
- `Input.GetKeyDown`, `GetKey`, `GetKeyUp`을 조합하여 점프 충전과 발사를 분리
- 충전 중 시각 피드백으로 스프라이트 컬러가 점차 노란색으로 깜빡이는 효과 추가
- 바닥 착지를 `Collision Detection = Continuous` + `OnCollisionEnter2D`로 정확하게 감지

#### 2. ☁️ 낙하 구름 기믹 (Falling Cloud Mechanic)
- 플레이어가 특정 구름에 착지하면 일정 시간 후 낙하
- 낙하 후 일정 시간 동안 비활성화 → 이후 원래 위치로 복귀
- `Rigidbody2D`의 `bodyType`을 `Kinematic ↔ Dynamic`으로 전환하여 자연스러운 낙하 구현
- `SpriteRenderer.enabled`, `Collider2D.enabled` 조절로 시각/물리적 비활성화
- `Coroutine`을 사용해 낙하 → 사라짐 → 재등장 순서를 타이밍 제어
- 모든 구름은 `Cloud` 태그로 통일하고, 낙하 구름은 `FallingCloud.cs` 컴포넌트로 구분

#### 🔧 추가 예정 기능 리스트
- 🪄 **Jump Booster Cloud**: 자동 점프 구름
- 🔁 **Moving Platform Cloud**: 위아래로 반복 이동하는 플랫폼 구름
- 🍀 Random System :  랜덤으로 구름이 낙하구름 또는 일반구름으로 정해진다.
- 🌱 스테이지 변경 : 지면에서 시작하는 스테이지가 기본 제공되고, 플레이어의 진행도에 따라서 점차 하늘로 올라가는 연출이 되는 스테이지가 다중 제공된다.
- 🪄 다음 스테이지 화면 및 스테이지 전환방법 : 화살표 ↑키를 누르면 스테이지 선택화면 출력 및 스테이지 선택 가능
- ⭐️ 메뉴 시스템 : 다중 기능을 수행하는 시스템으로, 다음 스테이지, 메인 메뉴, 게임 종료등을 구현하는 시스템
- 💖 게임 타이틀, 메인 화면, 게임 화면, 종료 화면 구현
