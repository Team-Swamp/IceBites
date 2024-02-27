namespace FrameWork.Structs
{
    public struct TimerData
    {
        public float mainTimerLenght;
        public float smallTimerLenght;

        public TimerData(float bigTimer = 180, float smallTimer = 15)
        {
            mainTimerLenght = bigTimer;
            smallTimerLenght = smallTimer;
        }
    }
}