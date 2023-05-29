using DataCape.Models;

namespace BusinessCape.DTOs.TypeDocument
{
    public class TypeDocumentUpdateDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;
        public bool? StatedAt { get; set; }
    }
}
