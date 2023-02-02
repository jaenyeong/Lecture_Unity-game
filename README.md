# Lecture_Unity-game

### [왕초보] 유니티로 만드는 게임개발 종합반 23회차
https://spartacodingclub.kr/online/game

---

## [Settings]
#### Github
* 파일이 50MB가 넘어 lfs 설정
  ```console
  # 설치
  brew install git-lfs

  # 설치 확인
  git lfs install
  
  # psd 파일 트래킹 설정
  git lfs track "*.psd"

  # 모든 히스토리를 lfs에 마이그레이션
  git lfs migrate import --everything

  # 오래된(닿지 못하는) reflog 파일 삭제
  ## 추가적으로 파일을 삭제를 통한 용량 확보 효과가 있음
  git reflog expire --expire=now --all

  # 안전하게 깃 GC 작업 수행
  git gc --prune=now --aggressive

  # 
  git push --mirror --force
  ```
#### Unity Hub
* 3.4.1 버전 (2023.01.24 기준)
  * https://public-cdn.cloud.unity3d.com/hub/prod/UnityHubSetup.dmg
#### Unity
* `2021.3.16f1` > `2021.3.17f1`

## [환경설정]
### 유니티 허브 설정
* 한국어
* 라이센스 (Personal)
* 저장 위치 (`/Users/jaenyeong/Projects/Unity`)

## 강의 자료
* https://teamsparta.notion.site/1-379d458162404f82b08d7e3e6c55d5d2
* https://teamsparta.notion.site/2-2114ade979894aa3b560bed6419d1d0d
* https://teamsparta.notion.site/3-1074ebc561e34cf4b10370c5b43e9c6c
* https://teamsparta.notion.site/4-c940c767ff12473aabf38c3370e0fd92
* https://teamsparta.notion.site/5-ed804e30554b49cb834ccae4d37f1375

## 유니티 설명
### 개발 영역 설명
* Scene
  * 실제 게임 구성요소를 보는 곳 (실질적 게임 개발 씬)
* Game
  * 게임이 실제로 노출되는 곳
* Hierarchy
  * 게임 요소 (점수판, 빗물 요소 등)
* Project
  * 게임 실행한 필요한 파일 (음악, 폰트, 이미지 등)
  * Assets, Packages 디렉터리 존재
* Inspector
  * 게임 요소(버튼, 캐릭터 등)에 대한 내부 확인(값, 함수, 상태 등)

