using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QualiAPI.Models
{
  public static class listUser
  {
   public static List<UserProfile> users = new List<UserProfile>() { new UserProfile() {firstName="chaya",lastName="dgdf",phone="1212121212" } };
   public static List<Group> groups = new List<Group>() { new Group() { name = "חיה", password = "1212",users=users } };
  }
}
