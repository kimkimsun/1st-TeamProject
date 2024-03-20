# 첫 팀프로젝트
> ### **개발 환경**

![Windows](https://img.shields.io/badge/Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white)
![Unity](https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)
![Discord](https://img.shields.io/badge/Discord-%235865F2.svg?style=for-the-badge&logo=discord&logoColor=white)
# **핵심 기능**
### 프로젝트 특징
1주간에 유니티 공부를 한 뒤, 시작한 첫 게임 프로젝트라 기술적으로 많이 미흡한 경향이 있습니다.
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
##### 이 처럼 총 5개가 구현되어 있으며, 코드가 난잡해보이긴 하지만 기능적으로는 문제가 없음을 확인했습니다.

### 코드를 작성하면서 느낀 점
당시에는 실력이 미흡했기 때문에 기간내에 기능을 완성한다는 목표만을 가지고 있었습니다.
다음 프로젝트에서 인벤토리 및 퀵슬롯을 구현할 때에는 좀 더 체계적으로 구현해야겠다는 목표성을 가지게 되었습니다. 
