using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance;
    public Dictionary<string, Item> itemsData; //name, item object
    public Dictionary<string, int> collectedItems; //name, quantity

    public GameObject[] itemPrefabs;

    public GameObject efx_feather;

    public static ItemManager FindInstance()
    {
        return instance; //that's just a singletone as the region says
    }

    private void Awake() //this happens before the game even starts and it's a part of the singletone
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
    }

    private void Start()
    {
        collectedItems = new Dictionary<string, int>();
        itemsData = new Dictionary<string, Item>();
        itemsData.Add("feather", new Feather());
        itemsData.Add("lens", new Lens());
        itemsData.Add("syringe", new Syringe());

        //TODO: add all created items to itemsData
    }

    public void AddItem(string item)
    {
        if (collectedItems.ContainsKey(item))
        {
            collectedItems[item]++;
        }
        else
        {
            collectedItems.Add(item, 1);
        }
    }

    //for chests
    public GameObject RandomItem()
    {
        int i = Random.Range(0, itemPrefabs.Length);
        return itemPrefabs[i];
    }

    public Item GetItem(string item)
    {
        return itemsData[item];
    }

    //returns the number of items, 0 if none
    public int ItemCount(string item)
    {
        if (collectedItems.ContainsKey(item))
        {
            return collectedItems[item];
        }
        else
        {
            return 0;
        }
    }

    public Feather GetFeather()
    {
        return (Feather)itemsData["feather"];
    }


    public bool HasItem(string item)
    {
        if (collectedItems.ContainsKey(item))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
