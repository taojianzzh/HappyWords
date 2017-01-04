using HappyWords.Data.Interfaces;
using HappyWords.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyWords.Web.Controllers
{
    public class ControllerBase : Controller
    {
        private UserContext _userContext;
        protected IUserRepository _userRepository;

        protected UserContext UserContext
        {
            get
            {
                if (_userContext == null)
                {
                    var getUserTask = _userRepository.GetUserAsync(User.Identity.Name);
                    getUserTask.Wait();
                    var user = getUserTask.Result;
                    if (user == null)
                    {
                        throw new UnauthorizedAccessException();
                    }
                    _userContext = new UserContext()
                    {
                        Id = user.Id,
                        Name = user.UserName
                    };
                }
                return _userContext;
            }
        }

        public ControllerBase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
