using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class BlockWithItem : MonoBehaviour
{
    private Renderer renderer;
    public float RandomRatio = 1;

    public GameObject Item;

    public GameObject[] RandomItem;

    public Vector3 ItemPos = Vector2.up;

    public GameObject instances = null;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            ItemPos.y += Mathf.Sign(ItemPos.y) * renderer.bounds.size.y / 2;
        }

        foreach (GameObject g in RandomItem)
        {
            g.SetActive(false);
        }
    }

    void OnEnable()
    {
        float r = Random.Range(0f, 1f);
        if (r < RandomRatio)
        {
            AddItem();
        }
    }

    void AddItem()
    {
        if (RandomItem != null && instances == null)
        {
            Item.SetActive(false);
            GameObject obj = (GameObject)GameObject.Instantiate(Item);
            obj.transform.SetParent(this.transform);
            obj.transform.position = gameObject.transform.position + ItemPos;
            obj.SetActive(true);
            instances = obj;
        }else if (instances == null)
        {
            if (RandomItem == null || RandomItem.Length == 0)
            {
                instances.transform.position = gameObject.transform.position + ItemPos;
                instances.SetActive(true);
            }
            else
            {
                GameObject.Destroy(instances);
                int index = Random.Range(0, RandomItem.Length);
                Item = RandomItem[index];
                GameObject obj = (GameObject)GameObject.Instantiate(Item);
                obj.transform.SetParent(this.transform);
                obj.transform.position = gameObject.transform.position + ItemPos;
                obj.SetActive(true);
                instances = obj;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
