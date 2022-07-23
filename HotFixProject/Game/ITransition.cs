using Cysharp.Threading.Tasks;

namespace Game
{
    public interface ITransition
    {
        /// <summary>
        /// 开始转出：比如逐步黑屏等
        /// </summary>
        UniTask BeginOut();

        /// <summary>
        /// 开始转入
        /// </summary>
        UniTask BeginIn();
    }
}
