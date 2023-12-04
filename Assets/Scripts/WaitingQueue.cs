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
            customer.PlayAnimation(customer.parent.anim[0]);
            customer.babyController.PlayAnimation("walking with baby");
            customer.MoveToTarget(queue[queueIndex], () =>
            {
                Debug.Log("move to available slot");
                customer.PlayAnimation(customer.parent.anim[1]); 
                customer.babyController.PlayAnimation("standing idle"); 
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
            customer.PlayAnimation(customer.parent.anim[0]);
            customer.babyController.PlayAnimation("walking with baby");
            customer.MoveToTarget(queue[i], () =>
            {
                customer.PlayAnimation(customer.parent.anim[1]);
                customer.babyController.PlayAnimation("standing idle");
                //CheckSlotForCustomer(customer); 
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
        customer.PlayAnimation(customer.parent.anim[0]);
        customer.babyController.PlayAnimation("walking with parent");
        customer.CheckForSlots();
    }

    public void CheckForFreeSlots()
    {
        for (int i = 0; i < customerInQueue.Count; i++)
        {
             CheckSlotForCustomer(customerInQueue[i]);
        }
    }
}