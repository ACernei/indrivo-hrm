using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InDrivoHRM.Models.Crm
{
  [Table("Contacts", Schema = "dbo")]
  public partial class Contact
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get;
      set;
    }

    public ICollection<Opportunity> Opportunities { get; set; }
    
    [Encrypted]
    public string Email
    {
      get;
      set;
    }
    
    [Encrypted]
    public string Company
    {
      get;
      set;
    }
    
    [Encrypted]
    public string LastName
    {
      get;
      set;
    }
    
    [Encrypted]
    public string FirstName
    {
      get;
      set;
    }
    
    [Encrypted]
    public string Phone
    {
      get;
      set;
    }
  }
}
