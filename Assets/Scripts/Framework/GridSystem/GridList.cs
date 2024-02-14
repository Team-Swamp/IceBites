using FrameWork.Attributes;
using FrameWork.Extensions;

namespace FrameWork.GridSystem
{
    public enum PlayerGridPoints
    {
        [Vector3Value(0,1,0)] POINT_A,
        [Vector3Value(5,1,5)] POINT_B,
    }

    public enum NpcGridpoints
    {
        [Vector3Value(0,1,-15)] STARTING_POINT,
        [Vector3Value(0,1,-3)] COUNTER_POINT,
    }
}
