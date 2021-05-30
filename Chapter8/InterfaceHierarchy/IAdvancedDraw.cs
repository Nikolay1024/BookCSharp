namespace InterfaceHierarchy
{
    interface IDrawable
    {
        void Draw();
    }

    interface IAdvancedDraw : IDrawable
    {
        void DrawInBoundingBox(int top, int left, int bottom, int right);
        void DrawUpsideDown();
    }
}
