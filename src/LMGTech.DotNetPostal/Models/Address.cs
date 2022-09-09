using System.Collections.Generic;

namespace LMGTech.DotNetPostal.Models
{
    public class Address
    {
        public IReadOnlyList<AddressPart> AddressParts { get; }

        public Address(List<AddressPart> addressParts)
        {
            AddressParts = addressParts;
        }
    }
}