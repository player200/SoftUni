namespace SimpleMvc.Framework.Contracts.Generic
{
    public interface IRenderable<T> : IRenderable
    {
        T Model { get; set; }
    }
}