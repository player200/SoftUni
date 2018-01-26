namespace SimpleMvc.App.Views.Home
{
    using SimpleMvc.Framework.Contracts;
    using System.Text;

    public class Index : IRenderable
    {
        public string Render()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<h3>NotesApp</h3>");
            sb.AppendLine("<a href=\"/users/all\">All Users</a>");
            sb.AppendLine("<a href=\"/users/register\">Register User</a>");

            return sb.ToString();
        }
    }
}