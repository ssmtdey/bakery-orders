namespace Bakery.Api.Models;

public class MenuItem
{
    public int Id { get; set; }                               
    public string Name { get; set; } = "";                    
    public List<SizeOption> SizeOptions { get; set; } = [];   
}