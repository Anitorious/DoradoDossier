namespace DoradoDossier.Utilities
{
    internal interface IRenderer<T>
    {
        string Render(string name, string path, T model);
    }
}
