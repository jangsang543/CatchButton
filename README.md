# 📘 2주차 과제: 버튼 잡기 게임

- 이름: 장상 (23017078)
- 학과: 지능형SW융합대학 - 컴퓨터학부 - 컴퓨터SW

## 📌 핵심 기능
- 버튼 영역안으로 마우스가 들어가면 버튼을 랜덤위치로 이동.
- 버튼을 잡았을 때 버튼을 클릭하면 “축하합니다~!” 라고 메시지박스를 띄움.
- 버튼을 클릭하면 100점추가, 도망가면 10점 감점하여 점수를 계산하고, 점수는 폼 제목에 표시.
- 클릭에 성공할 때마다 버튼의 크기를 10%씩 작게 크기를 축소.
- 20번놓치면 "Game Over" 메시지를 출력하고, 모든 버튼을 비활성화 처리.
- 게임 관련된 모든 정보를 초기화하고, 처음 하는 것처럼 게임을 다시 시작하는 '다시 시작' 버튼 구현.
---

## 📷 실행 화면
- (게임 실행 후 화면)
<p>
<img width="1247" height="833" alt="스크린샷 2026-03-12 163155" src="https://github.com/user-attachments/assets/2493d437-19e4-4e1c-86c1-26c4d7ad0a84" />
</p>

- (버튼 영역안으로 마우스가 들어가면 버튼을 랜덤위치로 이동)
 <p>
<img width="623" height="414" alt="화면 캡처 2026-03-12 163227" src="https://github.com/user-attachments/assets/998cf9ed-a409-4abd-87db-2356c3439d38" />
<img width="1237" height="834" alt="스크린샷 2026-03-12 163253" src="https://github.com/user-attachments/assets/685aeb14-3bb0-417f-a575-5e5e165fbe95" />
 </p>

- (버튼을 잡았을 때 버튼을 클릭하면 “축하합니다~!” 라고 메시지박스를 띄움.)
<p>
<img width="433" height="426" alt="스크린샷 2026-03-12 165250" src="https://github.com/user-attachments/assets/48651246-ed82-4ac7-873c-54792810ddeb" />
</p>

- (버튼을 클릭하면 100점추가, 도망가면 10점 감점하여 점수를 계산하고, 점수는 폼 제목에 표시.)
<p>
<img width="285" height="121" alt="스크린샷 2026-03-12 170452" src="https://github.com/user-attachments/assets/40d1677d-dcfe-4e48-b14f-7ea79aed275f" />
<img width="193" height="221" alt="스크린샷 2026-03-12 170858" src="https://github.com/user-attachments/assets/eca0058e-6a8f-42da-b7a7-4b4288c97059" />
</p>

- (클릭에 성공할 때마다 버튼의 크기를 10%씩 작게 크기를 축소.)
<p>
<img width="1244" height="824" alt="스크린샷 2026-03-12 171259" src="https://github.com/user-attachments/assets/8faef98f-3974-41f8-9ccb-9da16dc70a3d" />
</p>

- (20번놓치면 "Game Over" 메시지를 출력하고, 모든 버튼을 비활성화 처리.)
<p>
<img width="1246" height="831" alt="스크린샷 2026-03-12 172750" src="https://github.com/user-attachments/assets/ac2f5a95-8852-4bc8-99f7-05c89880771e" />
</p>

- (게임 관련된 모든 정보를 초기화하고, 처음 하는 것처럼 게임을 다시 시작하는 '다시 시작' 버튼 구현.)
<p>
<img width="294" height="136" alt="스크린샷 2026-03-12 173154" src="https://github.com/user-attachments/assets/3f36baca-2028-48a8-93e4-a162be514b15" />
<img width="155" height="125" alt="스크린샷 2026-03-12 173214" src="https://github.com/user-attachments/assets/dec8dd1c-195e-4a74-ba87-c874ca9debe7" />
</p>

## 🛠 구현 시 어려웠던 점
1️⃣ 버튼이 랜덤으로 피할 때 자꾸 창 밖으로 나가는 현상이 있어서 이것을 고치는 것이 어려웠었다.<br>
원래 코드는 버튼의 새 좌표를 0 ~ ClientSize.Width/Height 범위에서 뽑아서 버튼의 왼쪽 위 모서리가 폼의 우하단에 가면 버튼이 창 밖으로 나간다.

<p>
<img width="1127" height="506" alt="스크린샷 2026-03-12 163336" src="https://github.com/user-attachments/assets/69c527c9-93a1-4e71-b174-59a4f06e7b1b" />
</p>

위 코드는 알맞게 수정된 코드이다.<br>
버튼이 완전히 보이려면 왼쪽 위 x가 가질 수 있는 최대값은 버튼의 오른쪽 끝이 클라이언트 우측을 넘지 않게 해야 하므로<br>
maxX = ClientSize.Width - myButton.Width, maxY = ClientSize.Height - myButton.Height로 최대 좌표를 제한해주면 해결된다.

2️⃣ 클릭에 성공할 때마다 버튼의 크기를 10%씩 작게 크기를 축소하는 코드는 검색해서 찾았는데, 코드를 해석하고 이해하는 과정이 힘들었다.

<p>
<img width="812" height="499" alt="Image" src="https://github.com/user-attachments/assets/30f693fb-4f0b-4e00-94ac-0f59d4a67639" />
</p>

버튼을 클릭할 때마다 너비/높이는 10%씩 줄어들지만 너무 작아지지 않도록 최소 크기 20x20 픽셀로 제한한다.<br>
그리고 크기 변경 후 버튼이 폼 밖으로 나가지 않도록 또 다시 현재 크기에 맞게 위치를 보정한다. 점수는 기존처럼 업데이트 되어 메시지박스 제목과 폼 제목에 반영된다.

3️⃣ '다시 시작' 버튼 코드를 넣었을 때, 초기 버튼 크기/위치 저장(initialButtonSize, initialButtonLocation)을 왜 하는지 잘 이해가 안갔다.

<p>
<img width="583" height="427" alt="Image" src="https://github.com/user-attachments/assets/302a5ad7-ab22-41f8-a620-65cae402a6bc" />
</p>

간단히 말하자면 "다시시작"했을 때 버튼을 원래대로 돌려놓으려고 저장하는 것이다.<br>
플레이 중에 버튼은 클릭으로 작아지고(또는 도망가며) 위치가 바뀐다. 그렇기 때문에 초기 상태로 복원하려면 최초의 크기·위치를 알고 있어야 한다.
