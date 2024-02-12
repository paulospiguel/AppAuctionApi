using System.ComponentModel.DataAnnotations.Schema;
using AppAuction.API.Enums;

namespace AppAuction.API.Entities;

public class User
{
    public int Id { get; set; }
    public string Name {get; set;} = string.Empty;
    public string Email  { get; set; } = string.Empty;
}