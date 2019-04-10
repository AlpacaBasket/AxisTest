using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScriptyBoi : MonoBehaviour
{

    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;

    // Start is called before the first frame update
    void Start()
    {

        List<GameObject> cubes = new List<GameObject>();
        List<GameObject> sortedCubes = new List<GameObject>();

        cubes = GetCubes();
        sortedCubes = sortListByBiggestAxis(cubes);
        //rotateObjectsInList(sortedCubes);

    }

    private List<GameObject> sortListByBiggestAxis(List<GameObject> l)
    {

        List<GameObject> newList = new List<GameObject>();
        List<float> floatList = new List<float>();
        Dictionary<GameObject, float> dic = new Dictionary<GameObject, float>();

        foreach (var item in l)
        {
            dic.Add(item, GetBiggestAxis(item));
        }

        floatList = dic.Values.OrderBy(x => x).ToList();

        foreach (var item in floatList)
        {
            newList.Add(dic.FirstOrDefault(x => x.Value == item).Key);
        }

        printdebug1(newList);
        return newList;

    }

    private void printDictionary(Dictionary<GameObject, float> dic)
    {
        foreach (var item in dic)
        {
            Debug.Log(item.ToString());
        }
    }

    private float GetBiggestAxis(GameObject item)
    {

        List<float> newList = new List<float>();
        float a1 = item.GetComponent<Collider>().bounds.size.x;
        float a2 = item.GetComponent<Collider>().bounds.size.y;
        float a3 = item.GetComponent<Collider>().bounds.size.z;

        newList.Add(a1);
        newList.Add(a2);
        newList.Add(a3);

        float biggestNumber = newList.Max();

        return biggestNumber;

    }

    private void printdebug1(List<GameObject> a)
    {

        foreach (var item in a)
        {
            Debug.Log(item.ToString());
        }

    }

    private void printdebug2(List<float> a)
    {

        foreach (var item in a)
        {
            Debug.Log(item.ToString());
        }

    }

    private List<GameObject> GetCubes()
    {

        List<GameObject> bigList = new List<GameObject>();

        if (cube1 != null)
        {
            bigList.Add(cube1);
        }
        if (cube2 != null)
        {
            bigList.Add(cube2);
        }
        if (cube3 != null)
        {
            bigList.Add(cube3);
        }
        if (cube4 != null)
        {
            bigList.Add(cube4);
        }

        return bigList;

    }
}
