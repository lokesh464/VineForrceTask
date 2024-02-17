using System;

namespace VineForceAPI.DTOs
{
    public class CreateUpdateStateDto
    {
        public string Name { get; set; } = string.Empty;
        public Guid CountryId { get; set; }
    }
}
