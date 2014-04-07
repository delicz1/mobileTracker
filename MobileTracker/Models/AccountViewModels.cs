using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace MobileTracker.Models
{
    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Původní heslo")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Heslo musí být {2} znaků dlouhé.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Nové heslo")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nové heslo znovu")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "Nově zadaná hesla nejsou stejná.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Uživatelské jméno")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [Display(Name = "Zapamatovat mě?")]
        public bool RememberMe { get; set; }
    }



    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Uživatelské jméno")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Heslo musí být {2} znaků dlouhé.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Heslo znovu")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Nově zadaná hesla nejsou stejná.")]
        public string ConfirmPassword { get; set; }

        [Display(Name= "Jméno")]
        public string FirstName { get; set; }

        [Display(Name = "Příjmení")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public IEnumerable<SelectListItem> Groups { get; set; }
        public string GroupName { get; set; }
        public int GroupId { get; set; }

        // Return a pre-poulated instance of AppliationUser:
        public ApplicationUser GetUser()
        {
            var user = new ApplicationUser()
            {
                UserName = this.UserName,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                GroupId = this.GroupId
            };
            return user;
        }
    }

    public class EditUserViewModel
    {
        public EditUserViewModel() { }

        // Allow Initialization with an instance of ApplicationUser:
        public EditUserViewModel(ApplicationUser user)
        {
            this.UserName = user.UserName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
        }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
    }

    public class SelectUserRolesViewModel
    {
        public SelectUserRolesViewModel()
        {
            this.Roles = new List<SelectRoleEditorViewModel>();
        }


        // Enable initialization with an instance of ApplicationUser:
        public SelectUserRolesViewModel(ApplicationUser user)
            : this()
        {
            this.UserName = user.UserName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;

            var Db = new ApplicationDbContext();

            // Add all available roles to the list of EditorViewModels:
            var allRoles = Db.Roles;
            foreach (var role in allRoles)
            {
                // An EditorViewModel will be used by Editor Template:
                var rvm = new SelectRoleEditorViewModel(role);
                this.Roles.Add(rvm);
            }

            // Set the Selected property to true for those roles for 
            // which the current user is a member:
            foreach (var userRole in user.Roles)
            {
                var checkUserRole =
                    this.Roles.Find(r => r.RoleName == userRole.Role.Name);
                checkUserRole.Selected = true;
            }
        }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SelectRoleEditorViewModel> Roles { get; set; }
    }

    // Used to display a single role with a checkbox, within a list structure:
    public class SelectRoleEditorViewModel
    {
        public SelectRoleEditorViewModel() { }
        public SelectRoleEditorViewModel(IdentityRole role)
        {
            this.RoleName = role.Name;
        }

        public bool Selected { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
