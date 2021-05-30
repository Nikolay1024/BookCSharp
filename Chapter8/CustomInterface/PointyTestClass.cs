namespace CustomInterface
{
    class PointyTestClass : IPointy
    {
        public byte Points
            => throw new System.NotImplementedException();
    }
}
