namespace SimpleMvc.Framework.Contracts.Generic
{
    public interface IActionResult<T> : IInvocable
    {
        IRenderable<T> Action { get; set; }
    }
}