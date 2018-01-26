namespace ByTheCake.Application.Controllers
{
    using ByTheCake.Infrastructures;

    public abstract class BaseController : Controller
    {
        protected override string ApplicationDirectory => "ByTheCakeApplication";
    }
}