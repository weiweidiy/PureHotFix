
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

public interface IHotFixManager
{
    Task<Assembly> LoadAssemblyAsync(string address);

    Assembly LoadAssembly(string address);



}
