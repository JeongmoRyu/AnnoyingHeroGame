# AnnoyingHeroGame([불편 용사 ;; 세상 사람들이 불편(不便)해하는 행동은 다 해서 주변의 빈축(嚬蹙)만 샀던 내가 이세계(異世界)에서는 프로 불편 용사(勇者)라고?])
make 2D game with unity



![게이모고.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/a440f2ed-0715-43e5-875e-c38d5d30a4b0/%EA%B2%8C%EC%9D%B4%EB%AA%A8%EA%B3%A0.png)

## UCC, PPT, 기획

[UCC PPT[불편 용사 ;; **세상 사람들이 불편(不便)해하는 행동은 다 해서 주변의 빈축(嚬蹙)만 샀던 내가 이세계(異世界)에서는 프로 불편 용사(勇者)라고?**]](https://www.notion.so/UCC-PPT-7ba524f8a1424cc693102a2883c23197?pvs=21)

[시나리오 스크립트](https://www.notion.so/6c2daa407e6c4e8aa726f6dd892fbec1?pvs=21)

[보스 공격 패턴 기획하기](https://www.notion.so/f3267279480c499d90f567279964e670?pvs=21)

# 🦸🏻🦹🏻‍♀️ 프로젝트 컨셉

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/9afcbadc-32e7-4e63-92cd-43f5a95b6cc7/Untitled.png)

> “**세상 사람들이 불편해 하는 행동은 다 해서 주변의 빈축(**嚬蹙)**만 샀던 내가 
이 세계에서는 프로 불편 용사라고?”**
> 
> 
> 완벽 마왕들이 완벽하지 않은 사람들을 모두 잡아내고 쓰러뜨려 세상을 지배했다.
> 
> 잡혀가지 않고 남은 사람들은 행동 하나하나를 조심해야 살아남을 수 있게 됐다.
> 
> 그런 세상에 떨어진 `**다리 떨고 쩝쩝 대고 맞춤법 틀리고 면 치기 하는 주인공**`.
> 

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/57b5729c-b9e0-41d0-8693-6da7042d5bf7/Untitled.png)

> 마왕과 그의 부하들을 쓰러뜨려 세상을 자유롭게 만들어야 하는 운명의 소용돌이 속으로..!!
> 

# 시나리오

## 🔌 닉네임 입력으로 게임 접속

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/2e82b5a6-22c7-46bd-ad20-c8d5026d7d30/Untitled.png)

> 개성 있는 닉네임으로 게임을 시작해요
> 

---

## 🏹 첫 번째 게임 `이브르다다라`

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/447ff4c6-cc03-4b6b-98a1-857a250d74af/Untitled.png)

> 조용히 음식을 먹어야 하는 `랭KING` 이 점령한 이브다다라 성!
> 

```
# 설명서
뛰어난 미식가 겸 요리사인 랭KING의 공격을 피하며 보스를 처치해야하는 보스전 게임입니다.
아이템 상자에서 나오는 아이템(스피커, 음식, 총알, 하트 등)을 이용하여 용사의 공격력을 올리고 아이템을 장착하여 보다 쉽게 랭KING을 처치할 수 있을거에요

점프(SPACE)와 방향키(위 방향키, 오른쪽 방향키)을 통해 보스의 공격을 피해보세요
쩝쩝 공격(LeftCtrl)을 통해 쩝쩝 소리를 내며 공격을 해보세요
	공격은 보스와 아이템 상자 중 가까운 곳으로 발사가 되니 랭KING과의 거리를 잘 생각하시면서 게임을 플레이하셔야합니다.
방어(아래쪽 방향키)를 통해 무자비하게 공격해오는 보스의 공격을 막아보세요
```

### 지도 & Entry Map

![fix_village.webp](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/912cb70f-93dd-439b-a316-89b1d4ca1901/fix_village.webp)

![fix_bossentry.webp](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/b7a2c251-d340-4e28-ad1b-7fcb7c5fb717/fix_bossentry.webp)

```python
- 카메라 애니메이션을 이용하여 script를 읽으면서 몰입감을 증진시켰습니다.
- map에서도 캐릭터들의 애니메이션으로 생동감을 구현하였습니다.
```

### 시작 & esc

![fix_start.webp](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/88e7c5e0-900c-44d3-baba-6f56dfc4e87e/fix_start.webp)

![fix_esc.webp](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/755a126a-5065-4683-bdca-68e2e1658309/fix_esc.webp)

```python
- 보스맵은 무한 맵을 구현하여 승리 혹은 패배까지 꾸준히 달릴 수 있게 만들었습니다.
- ESC를 클릭하시면 게임에서 나갈 수도 있고 게임 선택창으로도 나갈 수 있습니다.
- ESC를 클릭하시면 게임에 필요한 설명서가 왼쪽에 보입니다.
```

### Item

![fix_item1.webp](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/a9bfe527-9ebc-456e-8902-198fda652d58/fix_item1.webp)

![fix_item2.webp](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/a9e604ba-df23-44ad-98d7-14f2c824adc4/fix_item2.webp)

![fix_item3.webp](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/80666011-0032-4d0f-8d7e-b9c0ef49a20d/fix_item3.webp)

![fix_item4.webp](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/10019473-0e00-43b0-80e0-9a8cff4ccacf/fix_item4.webp)

```python
- Item은 5가지 종류를 가지고 있으며 확률에 따른 random 방식으로 구현됩니다.
```

### Play

![fix_play.webp](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/602ce426-744e-400c-9401-fc13384de2fc/fix_play.webp)

```python
- 즐겁게 게임을 즐길 수 있습니다.
```

### Win & Fail

![fix_win.webp](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/a17ab86d-3ef6-4371-a61f-d00fe73607b9/fix_win.webp)

![fix_fail.webp](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/3ba75b14-696e-40e9-9882-3274fce4ece9/fix_fail.webp)

```python
- 승리와 패배의 ui를 달리하여 게임을 새롭게 플레이하거나
- 다음 게임으로 넘어갈 수 있습니다.
```

---

## 🕊️ 두 번째 게임 `지거국`

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/33bfcd11-c90f-4040-943b-fae768cde670/Untitled.png)

> 탕수육은 무조건 부어 먹는 `부머기라스` 가 점령한 지거국!
> 

### 설명서

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/f91f310b-04f3-4fe2-a0f5-3a29fe57b644/Untitled.png)

---

## 👟 세 번째 게임 `후르프후릎`

![Scene3_Playing.gif](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/218f958b-3880-407d-b678-801072181bc8/Scene3_Playing.gif)

> **면치기**를 가장 더러워하는 `후르브킹` 이 점령한 후르프후릎 성!
> 
> 
> `후르브킹`을 이기기 위해서는 면치기를 하며 온 방안을 돌아다녀야 한다!
> 
> 그렇게 튄 라면 국물로 모든 방이 더러워지면 `후르브킹`과 대면할 수 있게 되는데…
> 

### 설명서

```
**# 설명서**

1. 라면을 먹으면서 면발을 끊지 않고 달려갑니다.
2. 길 중간에 등장하는 가위는 점프를 통해 피합니다.
3. 면을 달고, 온 방안을 휘저어 다니면 끝납니다!

- 점프키는 [SPACE] 입니다.
- 중간에 나오는 어묵은 생명이 됩니다.
  [끝까지 남은 어묵 X 10]가 점수가 됩니다.
- 보스전 후, 남아있는 어묵은 점수가 됩니다.
- 점프키를 길게 누르면 조금 더 높게 뜁니다.
```

---

## 🥁 네 번째 게임 `다리떨리아`

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/563c0e90-a7a1-449c-bd50-74259a2d53db/Untitled.png)

> 다리 떠는 것을 혐오하는 `고만터러킹` 이 점령한 다리떨리아 성!
> 

### 점수 로직

- Perfect : 10점
- Cool : 7점
- Good : 4점
- Bad : -3점
- Miss : -6점
- Bad/Miss 시 콤보 초기화
- 10콤보당 3점씩 추가로 획득
- 최종 획득 점수 = (미니게임 점수) / 3000

---

## 🍽️ 마지막 게임 `보스전`

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/ea34b978-fbc0-4d68-a916-20410eca2aa6/Untitled.png)

> 가장 강력하고 결벽적인 `파르펙토(perfect)` 대마왕!
그런 대마왕에게 단 한 가지 결점이 있었다?
비대칭 `괴식 콘텐츠`로 마왕의 홧병을 유도하여 이세계를 구해줘!
> 

```
# 설명서
마왕의 심기를 건드려서 파르펙토 마왕이 열받도록 도와주세요!

1. 마왕이 제시하는 사진의 빈칸에 들어갈 콘텐츠를 3 Match Puzzle에서 부숴주세요.
2. 단, 마왕을 불편하게 만들기 위해서는, 괴식 콘텐츠를 골라야 합니다.
3. 괴식이 아닌 콘텐츠는 점수 합산이 되지 않습니다.
4. 100점이 넘을 때마다 스페이스바를 연타하여 마왕에게 홧병 에네르기파를 쏘세요.
```

## 🥇 랭킹 확인

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/242ef757-f018-4d45-9015-205eadcfdd31/Untitled.png)

# 기술 스택

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/f826548c-dfb0-4cf8-95d5-a414595fcdae/ffb78534-f22f-4ecc-bf8e-4f3045f6f62c/Untitled.png)

# 팀원 소개

### 👤 Game

류정모 <이브르다다라>

엄한결 <지거국>

김유진 <후르프후릎>

조현기 <다리떨리아>

배희진 <보스전>

### ⚙️ Database

임혜지 : 닉네임 입력, 플레이 타임, 랭킹