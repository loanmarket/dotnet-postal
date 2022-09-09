namespace LMGTech.DotNetPostal.Models
{
    public class AddressPart
    {
        public AddressLabel Label { get; }
        public string Value { get; }

        public AddressPart(AddressLabel label, string value)
        {
            Label = label;
            Value = value;
        }
    }
}