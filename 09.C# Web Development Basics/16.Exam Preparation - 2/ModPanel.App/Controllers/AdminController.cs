namespace ModPanel.App.Controllers
{
    using ModPanel.App.Data.Models;
    using ModPanel.App.Infrastructure;
    using ModPanel.App.Models.Posts;
    using ModPanel.App.Services;
    using ModPanel.App.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using System.Linq;

    public class AdminController : BaseController
    {
        private const string EditError = "<p>Check your form for errors.</p><p>Title must begin with uppercase letter and has length between 3 and 100 symbols (inclusive).</p><p>Content must be more than 10 symbols (inclusive).</p>";

        private IUserService user;
        private IPostsServices post;
        private ILogService log;

        public AdminController()
        {
            this.log = new LogService();
            this.post = new PostsServices();
            this.user = new UserService();
            this.ViewModel["users"] = "none";
            this.ViewModel["posts"] = "none";
            this.ViewModel["title"] = "none";
            this.ViewModel["content"] = "none";
            this.ViewModel["logs"] = "none";
        }

        public IActionResult Users()
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }

            var rows = user
               .All()
               .Select(u => $@"
                    <tr>
                        <td>{u.Id}</td>
                        <td>{u.Email}</td>
                        <td>{u.Position.ToFriendlyName()}</td>
                        <td>{u.Posts}</td>
                        <td>
                            {(u.IsApproved ? string.Empty : $@"<a class=""btn btn-primary btn-sm"" href=""/admin/approve?id={u.Id}"">Approve</a>")}
                        </td>
                    </tr>");

            this.ViewModel["users"] = string.Join(string.Empty, rows);

            this.Log(LogType.OpenMenu, nameof(Users));

            return this.View();
        }

        public IActionResult Approve(int id)
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }

            var userEmail=  user.Approve(id);

            if (userEmail != null)
            {
                this.Log(LogType.UserApproval, userEmail);
            }

            return this.Redirect("/admin/users"); ;
        }

        public IActionResult Posts()
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }

            var rows = this.post.All().Select(p => $@"
                    <tr>
                        <td class=""text - center"">{p.Id}</td>
                        <td class=""text-capitalize"" >{p.Title}</td>
                        <td>
                            <a href = ""edit?id={p.Id}"" class=""btn btn-sm btn-warning"" >Edit</a>
                            <a href = ""delete?id={p.Id}"" class=""btn btn-sm btn-danger"" >Delete</a>
                        </td>
                    </tr>");

            this.ViewModel["posts"] = string.Join(string.Empty, rows);

            this.Log(LogType.OpenMenu, nameof(Posts));

            return this.View();
        }

        public IActionResult Edit(int id)
        {
            if(!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }

            var post = this.post.GetById(id);

            if (post == null)
            {
                return this.NotFound();
            }

            this.ViewModel["title"] = post.Title;
            this.ViewModel["content"] = post.Content;

            return this.View();
        }

        [HttpPost]
        public IActionResult Edit(int id, PostsModel model)
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }

            if (!this.IsValidModel(model))
            {
                this.ShowError(EditError);
                return this.View();
            }

            this.post.Update(id, model.Title, model.Content);

            this.Log(LogType.EditPost, model.Title);

            return this.Redirect("posts");
        }

        public IActionResult Delete(int id)
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }

            var post = this.post.GetById(id);

            if (post == null)
            {
                return this.NotFound();
            }

            this.ViewModel["id"] = id.ToString();
            this.ViewModel["title"] = post.Title;
            this.ViewModel["content"] = post.Content;

            return this.View();
        }

        [HttpPost]
        public IActionResult Confirm(int id)
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }

            var postTitle= this.post.Delete(id);

            if (postTitle != null)
            {
                this.Log(LogType.DeletePost, postTitle);
            }

            return this.Redirect("posts");
        }

        public IActionResult Log()
        {
            if (!this.IsAdmin)
            {
                return this.RedirectToLogin();
            }

            this.Log(LogType.OpenMenu, nameof(Log));

            var rows = this.log
                .All()
                .Select(l => l.ToHtml());

            this.ViewModel["logs"] = string.Join(string.Empty, rows);

            return this.View();
        }
    }
}