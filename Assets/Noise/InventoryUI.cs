using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public List<Transform> slotList = new();         // 슬롯 Transform들
    public GameObject slotItemPrefab;                // 슬롯 안에 들어가는 아이템 프리팹

    private List<GameObject> currentItems = new();   // 슬롯에 생성된 오브젝트들

    public Sprite dirtSprite;
    public Sprite grassSprite;
    public Sprite waterSprite;

    public void UpdateInventory(Inventory inv)
    {
        //  기존 슬롯 내 아이템 삭제
        foreach (var item in currentItems)
            Destroy(item);
        currentItems.Clear();

        int idx = 0;

        //  Inventory(Dictionary) 순회
        foreach (var pair in inv.items)
        {
            var go = Instantiate(slotItemPrefab, slotList[idx]);
            go.transform.localPosition = Vector3.zero;

            var slot = go.GetComponent<SlotItemPrefab>();

            switch (pair.Key)
            {
                case BlockType.Dirt:
                    slot.ItemSetting(dirtSprite, pair.Value.ToString());
                    break;

                case BlockType.Grass:
                    slot.ItemSetting(grassSprite, pair.Value.ToString());
                    break;

                case BlockType.Water:
                    slot.ItemSetting(waterSprite, pair.Value.ToString());
                    break;
            }

            currentItems.Add(go);
            idx++;
        }
    }
}
