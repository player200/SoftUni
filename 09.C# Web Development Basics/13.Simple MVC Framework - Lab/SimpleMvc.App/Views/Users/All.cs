namespace SimpleMvc.App.Views.Users
{
    using SimpleMvc.App.BindingModels;
    using SimpleMvc.Framework.Contracts.Generic;
    using System.Text;

    public class All : IRenderable<AllUsernamesViewModel>
    {
        public AllUsernamesViewModel Model { get; set; }

        public string Render()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<a href=\"/home/index\">< Home</a>");
            sb.AppendLine("<h3>All users</h3>");
            sb.AppendLine("<ul>");

            foreach (var kvp in this.Model.UsersWithIds)
            {
                sb.AppendLine($"<li><a href=\"/users/profile?id={kvp.Key}\">{kvp.Value}</a></li>");
            }
            sb.AppendLine("</ul>");


            sb.AppendLine("</ul>");

            return sb.ToString();
        }
    }
}