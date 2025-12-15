namespace GameEngine.ItemFeature
{
    internal readonly struct OccupiedPositionRange
    {
        internal float MinX { get; }
        internal float MaxX { get; }
        internal float MinY { get; }
        internal float MaxY { get; }
        
        public OccupiedPositionRange(float minX, float maxX, float minY, float maxY)
        {
            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;
        }
    }
}