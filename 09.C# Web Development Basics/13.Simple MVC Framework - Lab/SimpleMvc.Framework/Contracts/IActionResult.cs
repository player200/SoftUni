namespace SimpleMvc.Framework.Contracts
{
    public interface IActionResult : IInvocable
    {
        IRenderable Action { get; set; }
    }
}