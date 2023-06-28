using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SeaFoodStore.Areas.Identity.Data;

// Add profile data for application users by adding properties to the SeaFoodStoreUser class
public class SeaFoodStoreUser : IdentityUser
{
    public string FirstName { get; set; }   
    public string LastName { get; set; }    
}

