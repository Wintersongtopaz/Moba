using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The ITask interface implements a single method:public bool Evaluate()
public interface ITask
{
     bool Evaluate();
}
//AI Controller: Evaluates a list of tasks sequentially arranged based on priority
//Higher priority tasks higher up the list
public class AIController : MonoBehaviour
{
    public float updateFrequency = 0.2f;
    public List<MonoBehaviour> tasks = new List<MonoBehaviour>();

    public MonoBehaviour activeTask;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < tasks.Count; i++) if (!(tasks[i] is ITask)) tasks.RemoveAt(i--);
        StartCoroutine(EvaluateTasks());
    }

    IEnumerator EvaluateTasks()
    {
        while (true)
        {
            for(int i =0; i < tasks.Count; i++)
            {
                if ((tasks[i] as ITask).Evaluate())
                {
                    //stores a reference to the currently active task script
                    activeTask = tasks[i];
                    break;
                }
            }
            yield return new WaitForSeconds(updateFrequency);
        }
    }
}
