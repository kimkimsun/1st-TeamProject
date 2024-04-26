# 첫 팀프로젝트
> ### **개발 환경**

![Windows](https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white)
![Unity](https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)
![Discord](https://img.shields.io/badge/Discord-%235865F2.svg?style=for-the-badge&logo=discord&logoColor=white)
# 프로젝트 특징
#### 1주간에 유니티 공부를 한 뒤, 시작한 첫 게임 프로젝트라 기술적으로 많이 미흡한 경향이 있습니다.
# 게임 특징
#### 3D FPS 게임으로 몬스터를 잡아 무기를 획득한 뒤, 보스를 물리치는 게임입니다.
# 게임 영상 (이미지 클릭)
[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/DCpZCHbnalA/0.jpg)](https://youtu.be/DCpZCHbnalA)

# **핵심 기능**
### 기능제목
#### 플레이어 인벤토리 (퀵 슬롯)
### 기능설명
1. 플레이어는 인벤토리 (퀵 슬롯)을 5개 가질 수 있습니다.
2. 숫자키로 상호작용이 가능하고, 만약 슬롯에 아이템이 있다면 스위칭이 가능해집니다.
3. 새로운 아이템을 먹었을 경우엔 1~5번 슬롯을 오름차순으로 검사해서 빈 공간에 알아서 할당됩니다.

### 코드
```C#
if (Input.GetKeyDown(KeyCode.Alpha1))
{
    if (player.itemSlot[0] == null)
        return;

    else
    {
        temp = 0;
        isEquip = true;
    }

    if (gun == null)
    {
        gun = player.itemSlot[0];
        gun.SetActive(true);
        gun.GetComponent<Collider>().isTrigger = true;
        gun.GetComponent<Rigidbody>().isKinematic = true;
        gun.transform.SetParent(gunParent.transform);
        gun.transform.position = gunParent.transform.position;
        gun.transform.rotation = gunParent.transform.rotation;
    }
    else if (gun != null)
    {
        gun.gameObject.SetActive(false);
        gun = null;
        gun = player.itemSlot[0];
        gun.SetActive(true);
        gun.GetComponent<Collider>().isTrigger = true;
        gun.GetComponent<Rigidbody>().isKinematic = true;
        gun.transform.SetParent(gunParent.transform);
        gun.transform.position = gunParent.transform.position;
        gun.transform.rotation = gunParent.transform.rotation;
    }
}
```
##### 이 처럼 총 5개가 구현되어 있으며, 당시에 숙련도가 부족하여 코드가 깔끔하지 못합니다.

### 코드를 작성하면서 느낀 점
당시에는 실력이 미흡했기 때문에 기간내에 기능을 완성한다는 목표만을 가지고 있었습니다.


다음 프로젝트에서 인벤토리 및 퀵슬롯을 구현할 때에는 좀 더 체계적으로 구현해야겠다는 목표성을 가지게 되었습니다. 

# **다른 기능 및 코드 리뷰**

<details>
    <summary>플레이어 아이템 상호작용</summary>
    
### 기능제목
#### 플레이어 아이템 상호작용
### 기능설명
1. 플레이어의 현재 손에 무기를 들고 있다면 G키를 눌러 버릴 수 있습니다.
2. 플레이어 근처의 무기가 있다면 F키를 눌러 주울 수 있습니다.
3. 들고 있는 무기가 없거나, 근처의 무기가 없다면 두 단축키 모두 작동하지 않습니다.
### 코드
```C#
void Update()
{
        // 손에 든 무기를 버리는 단축키
        if (Input.GetKeyDown(KeyCode.G) && isEquip)
        {
            if (gun == null)
                return;

            player.itemSlot[temp] = null;

            //SoundManager.instance.PlaySE(dropGun);
            isEquip = false;
            gun.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gun.gameObject.GetComponent<Collider>().isTrigger = false;
            gun.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 4f, ForceMode.Impulse);
            gun.transform.SetParent(null);
            gun = null;
        }
        // 바닥에 무기가 있을 때 누르면 주어지는 단축키
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (gun == tempGun)
                return;

            if (isEquip == false)
            {
                if (tempGun == null)
                    return;
                int index = 0;
                GameObject current = player.itemSlot[index];
                while (current != null && index < 5)
                {
                    index++;
                    current = player.itemSlot[index];
                }
                player.itemSlot[index] = tempGun;

                isEquip = true;
                gun = tempGun;
                gun.GetComponent<Collider>().isTrigger = true;
                gun.GetComponent<Rigidbody>().isKinematic = true;
                gun.transform.SetParent(gunParent.transform);
                gun.transform.position = gunParent.transform.position;
                gun.transform.rotation = gunParent.transform.rotation;
            }
            else if (isEquip == true)
            {
                if (tempGun == null)
                    return;

                int index = 0;
                GameObject current = player.itemSlot[index];
                while (current != null && index < 5)
                {
                    index++;
                    current = player.itemSlot[index];
                }
                player.itemSlot[index] = tempGun;
                tempGun.SetActive(false);
                gun.GetComponent<Collider>().isTrigger = true;
                gun.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
}
```
</details>

<details>
    <summary>플레이어 1인칭 카메라</summary>
    
### 기능제목
#### 플레이어 1인칭 카메라 기능
### 기능설명
1. Quaternion.Euler를 이용하여 1인칭 카메라를 구현하였습니다.
2. 위 아래로는 180도를 넘기지 못하게 하였습니다.
### 코드
```C#
    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * rotCamYAxisSpeed;
        eulerAngleX -= mouseY * rotCamXAxisSpeed;

        eulerAngleX = ClampAngle(eulerAngleX, limixMinX, limixMaxX);

        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
        transform.root.rotation = Quaternion.Euler(0, eulerAngleY, 0);
    }
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
    void Update()
    {
        if (playerMove.isPlayerMove)
        {
             mouseX = Input.GetAxis("Mouse X");
             mouseY = Input.GetAxis("Mouse Y");
            
            UpdateRotate(mouseX, mouseY);
        }
    }
```
</details>

</details>

<details>
    <summary>랜덤드랍 상자 구현</summary>
    
### 기능제목
#### 랜덤드랍 상자 구현
### 기능설명
1. 당시 미흡했던 실력이었지만 웹 서핑을 통해 Animator를 이용하였습니다.
2. Random.range를 통해 확률적으로 아이템이 드랍하게 하였습니다.
### 코드
```C#
public void OpenBox()
{
    ani.SetTrigger("open");
    StartCoroutine(DropItem());
}
IEnumerator DropItem()
{
    yield return new WaitForSeconds(2f);
    int random;
    random = Random.Range(0, 12);
    if(random > 6)
        Destroy(gameObject);
    else
    { 
        copy = Instantiate(item.items[random]);
        copy.transform.position = this.transform.position;
        Destroy(gameObject);
    }
}
```
</details>

### 그 외의 포트폴리오에 명시된 기능들을 구현하였습니다.
