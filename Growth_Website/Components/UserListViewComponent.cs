using testing2.Models;
using Microsoft.AspNetCore.Mvc;
namespace Growth_Website.Components
{
    [ViewComponent(Name ="UserList")]
    public class UserListViewComponent:ViewComponent
    {

        public async Task <IViewComponentResult> InvokeAsync(List<Signup> users)
        {
            return View("Default", users);
        }
    }
}
