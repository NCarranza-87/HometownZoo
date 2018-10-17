using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeTownZoo.Core.Models
{
    /// <summary>
    /// Represent a basic customer
    /// </summary>
    public class Person
    {
        /// <summary>
        /// The PK field
        /// </summary>
        public int PersonID { get; set; }

        /// <summary>
        /// The persons first and last name
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }
    }
}
