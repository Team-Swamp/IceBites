using FrameWork.Attributes;

namespace FrameWork.GridSystem
{
    public struct GridPoints
    {
        public enum NpcPoints
        {
            [Vector3Value(0,1,-15)] NPC_STARTING_POINT,
            [Vector3Value(0,1,-3)] NPC_COUNTER_POINT,
        }

        public enum PlayerPoints
        {
            [Vector3Value(0,1,0)] POINT_A,
            [Vector3Value(5,1,5)] POINT_B,
        }
    }

}
