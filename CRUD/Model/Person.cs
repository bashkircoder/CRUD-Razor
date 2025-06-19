using System.Text.Json.Serialization;

namespace CRUD.Model;

public class Person
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }
    
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }
    
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }
    
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    
}