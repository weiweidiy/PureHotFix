using UnityEngine;

namespace Game
{
    public class GameUtils
    {
        /// <summary>
        /// 平滑的进度值
        /// </summary>
        /// <param name="startOffset"></param>
        /// <param name="duration"></param>
        /// <param name="time"></param>
        /// <returns></returns>
		public static float SmoothProgress(float startOffset, float duration, float time)
        {
            return Mathf.SmoothStep(0, 1, Progress(startOffset, duration, time));
        }

        /// <summary>
        /// 获取进度
        /// </summary>
        /// <param name="startOffset"></param>
        /// <param name="duration"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static float Progress(float startOffset, float duration, float time)
        {
            return Mathf.Clamp(time - startOffset, 0, duration) / duration;
        }

        /// <summary>
        /// 转换成像素值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxSize"></param>
        /// <returns></returns>
        public static int ToAbsoluteSize(float value, int maxSize)
        {
            if (value <= 1)
            {
                value = maxSize * value;
            }

            return (int)Mathf.Clamp(Mathf.Floor(value), 0, maxSize);
        }
    }
}
