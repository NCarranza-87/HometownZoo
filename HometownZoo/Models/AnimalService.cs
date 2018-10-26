using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HometownZoo.Models
{
    /// <summary>
    /// Returns ALL animals from the database
    /// sorted by name in ascending order
    /// </summary>
    public static class AnimalService
    {
        public static IEnumerable<Animal> 
            GetAnimals(ApplicationDbContext db)
        {
            //query syntax
            return (from a in db.Animals
                    orderby a.Name
                    select a).ToList();

            //method syntax
            //return db.Animals
            //        .OrderBy(a => a.Name)
            //        .ToList();
        }
    }
}