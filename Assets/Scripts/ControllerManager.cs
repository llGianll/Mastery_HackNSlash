using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    List<Controller> _controllers = new List<Controller>();

    private void Awake()
    {
        _controllers = FindObjectsOfType<Controller>().ToList();

        //assign index to controllers
        int index = 1;

        foreach (var controller in _controllers)
        {
            controller.SetIndex(index);
            index++;
        }
    }

    private void Update()
    {
        foreach (var controller in _controllers)
        {
            if(controller.IsAssigned == false && controller.AnyButtonDown())
            {
                AssignController(controller);
            }
        }
    }

    private void AssignController(Controller controller)
    {
        controller.IsAssigned = true;
        Debug.Log("Assigned Controller " + controller.gameObject.name);
    }
}
