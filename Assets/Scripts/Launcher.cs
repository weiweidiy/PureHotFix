using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var hotFix = new HuaTuoHotFix();
        Assembly dll = null;
        try
        {
            dll = hotFix.LoadAssembly("Launcher_dll");
            //var dll = AppDomain.CurrentDomain.GetAssemblies().First(assembly => assembly.GetName().Name == "HotFixMain");
            Debug.Assert(dll != null, "dll is null");

        }
        catch (Exception e)
        {
            Debug.LogError("º”‘ÿ≥Ã–ÚºØ¥ÌŒÛ " + e);
        }

        var facade = new HuaTuoFacade(dll);
        facade.StartUp();


    }

    // Update is called once per frame
    void Update()
    {

    }
}
