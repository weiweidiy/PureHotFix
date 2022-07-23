using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class HuaTuoFacade : IHotFixFacade
{
    Assembly DLL;
    public HuaTuoFacade(Assembly DLL)
    {
        this.DLL = DLL;
    }
    public void StartUp()
    {
        if (DLL == null)
        {
            UnityEngine.Debug.LogError("dll未加载");
            return;
        }
        //初始化应用
        var appType = DLL.GetType("Game.Launcher");
        var game = Activator.CreateInstance(appType, true);
        var mainMethod = appType.GetMethod("Launch");
        var assembly = mainMethod.Invoke(game, null) as Assembly;

        //启动游戏
        //var gameDll = AppDomain.CurrentDomain.GetAssemblies().First(assembly => assembly.GetName().Name == "Game");
        //启动游戏
        //var type = assembly.GetType("Game.Main");
        //var game = Activator.CreateInstance(type, true);
        //var method = type.GetMethod("Startup");
        //method.Invoke(game, null);

        //var appType = assembly.GetType("HotFixModule.Module");
        //object obj = Activator.CreateInstance(appType, true);
        //object[] paras = new string[] { "test3" };
        //Type[] paraTypes = new Type[1];
        //paraTypes[0] = typeof(string);
        //var mainMethod = appType.GetMethod("Show", paraTypes);
        //mainMethod.Invoke(obj, paras);
    }
}
