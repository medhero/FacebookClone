using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FacebookClone.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Column(TypeName = "datetime2")]
        
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedOn { get; set; }
        public Post ProfilePicture { get; set; }
        public Gender Gender { get; set; }
        public int GenderId { get; set; }
        public string FilePath { get; set; }

        public string Adresse { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Friend> Friends { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public User()
        {
            Posts = new HashSet<Post>();
            Comments = new HashSet<Comment>();
            Friends = new HashSet<Friend>();
        }
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                userIdentity.AddClaim(new Claim("FirstName", FirstName));

                return userIdentity;
            }
    }
}