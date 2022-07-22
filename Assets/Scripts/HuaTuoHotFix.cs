using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class HuaTuoHotFix : IHotFixManager
{
    public Assembly LoadAssembly(string address)
    {
        var dll = GetBytes(address);
        return Assembly.Load(dll);
    }

    public async Task<Assembly> LoadAssemblyAsync(string address)
    {
        var dll = await GetBytesAsync(address);
        return Assembly.Load(dll);
    }

    byte[] GetBytes(string path)
    {
        TextAsset asset = Addressables.LoadAssetAsync<TextAsset>(path).WaitForCompletion();
        return asset.bytes;
    }

    /// <summary>
    /// 读取字节文本文件
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    async Task<byte[]> GetBytesAsync(string path)
    {
        TextAsset asset = await Addressables.LoadAssetAsync<TextAsset>(path).Task;
        return asset.bytes;
    }
}