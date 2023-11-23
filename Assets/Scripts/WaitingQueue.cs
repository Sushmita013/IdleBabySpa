using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WaitingQueue : MonoBehaviour
{
    public List<Transform> queue=new List<Transform>();
    public List<ParentController> customerInQueue=new List<ParentController>();
    public int queueIndex; 

    public void AddInQueue(ParentController customer)
    {
        if(queueIndex<queue.Count)
        { 
            if(!customerInQueue.Contains(customer))
                customerInQueue.Add(customer);

            customer.MoveToReception(customer.parent);
            customer.MoveToTarget(queue[queueIndex], () =>
            {
                CheckSlotForCustomer(customer);
            });

            queueIndex++;
        }
    }

    public bool isFull()
    {
        return queueIndex >= queue.Count;
    }

    public void ReOrderQueue()
    {
        for(int i = 0; i < customerInQueue.Count; i++)
        {
            var customer= customerInQueue[i];
            customer.animator.Play("Walking");
            customer.MoveToTarget(queue[i], () =>
            {
                customer.animator.Play("Idle");
            });
        }
    }

    public void RemoveFromQueue(ParentController customer)
    {
        customerInQueue.Remove(customer);
        queueIndex--;
        ReOrderQueue();
    }

    public void CheckSlotForCustomer(ParentController customer)
    {
        StartCoroutine(customer.ReceptionEntry(customer.parent)); 
    }

    public void CheckForFreeSlots()
    {
        for (int i = 0; i < customerInQueue.Count; i++)
        {
            customerInQueue[i].MoveToNextDestination(customerInQueue[i].parent);
        }
    }
}