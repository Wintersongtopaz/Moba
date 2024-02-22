using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//IIntListener: An interface which receives updates from an Int Wrapper
public interface IIntListener
{
    public void IntUpdate(IntWrapper intWrapper);
}
//Int Wrapper: A class wrapped around an encapsulated integer value
[System.Serializable]
public class IntWrapper
{
    [SerializeField] int value;
    [SerializeField] int max;
    [SerializeField] public List<GameObject> listeners;

    public int Value
    {
        get => value;
        set
        {
            this.value = value;
            foreach(GameObject gameObject in listeners)
            {
                gameObject.GetComponent<IIntListener>().IntUpdate(this);
            }
        }
    }

    public float Ratio => (float)value / max;
}
