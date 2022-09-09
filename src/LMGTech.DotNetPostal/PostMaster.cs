using System.Collections.Generic;
using System.IO;
using System.Reflection;
using LMGTech.DotNetPostal.Models;

namespace LMGTech.DotNetPostal
{
    public static class PostMaster
    {
        private static bool _isInitialised;
        private static readonly object Padlock = new object();

        public static bool IsInitialised => _isInitialised;

        public static bool Setup()
        {
            if (!_isInitialised)
            {
                lock (Padlock)
                {
                    if (!_isInitialised)
                    {
                        var assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                        if (assemblyLocation != null)
                        {
                            var dataPath = Path.Combine(assemblyLocation, "libpostaldata");
                            _isInitialised = LibPostal.libpostal_setup_datadir(dataPath)
                                             && LibPostal.libpostal_setup_parser_datadir(dataPath)
                                             && LibPostal.libpostal_setup_language_classifier_datadir(dataPath);
                        }
                    }
                }
            }

            return _isInitialised;
        }

        public static void TearDown()
        {
            if (_isInitialised)
            {
                LibPostal.libpostal_teardown();
                LibPostal.libpostal_teardown_parser();
                LibPostal.libpostal_teardown_language_classifier();
            }
        }

        public static Address ParseAddress(string address)
        {
            if (_isInitialised)
            {
                var parserOptions = LibPostal.libpostal_get_address_parser_default_options();
                var parsedAddress = LibPostal.libpostal_parse_address(address, parserOptions);

                if (parsedAddress != null)
                {
                    var addressParts = new List<AddressPart>();
                    for (var i = 0u; i < parsedAddress.num_components; ++i)
                    {
                        var addressLabel = GetAddressLabel(parsedAddress.label_get(i));
                        if (addressLabel != null)
                        {
                            addressParts.Add(new AddressPart(addressLabel.Value, parsedAddress.component_get(i)));
                        }
                    }

                    return new Address(addressParts);
                }
            }

            return null;
        }

        private static AddressLabel? GetAddressLabel(string label)
        {
            switch (label)
            {
                case Constants.AddressLabels.House:
                    return AddressLabel.House;
                case Constants.AddressLabels.Category:
                    return AddressLabel.Category;
                case Constants.AddressLabels.Near:
                    return AddressLabel.Near;
                case Constants.AddressLabels.HouseNumber:
                    return AddressLabel.HouseNumber;
                case Constants.AddressLabels.Road:
                    return AddressLabel.Road;
                case Constants.AddressLabels.Unit:
                    return AddressLabel.Unit;
                case Constants.AddressLabels.Level:
                    return AddressLabel.Level;
                case Constants.AddressLabels.Staircase:
                    return AddressLabel.Staircase;
                case Constants.AddressLabels.Entrance:
                    return AddressLabel.Entrance;
                case Constants.AddressLabels.PoBox:
                    return AddressLabel.PoBox;
                case Constants.AddressLabels.Postcode:
                    return AddressLabel.Postcode;
                case Constants.AddressLabels.Suburb:
                    return AddressLabel.Suburb;
                case Constants.AddressLabels.CityDistrict:
                    return AddressLabel.CityDistrict;
                case Constants.AddressLabels.City:
                    return AddressLabel.City;
                case Constants.AddressLabels.Island:
                    return AddressLabel.Island;
                case Constants.AddressLabels.StateDistrict:
                    return AddressLabel.StateDistrict;
                case Constants.AddressLabels.State:
                    return AddressLabel.State;
                case Constants.AddressLabels.CountryRegion:
                    return AddressLabel.CountryRegion;
                case Constants.AddressLabels.Country:
                    return AddressLabel.Country;
                case Constants.AddressLabels.WorldRegion:
                    return AddressLabel.WorldRegion;
            }

            return null;
        }
    }
}