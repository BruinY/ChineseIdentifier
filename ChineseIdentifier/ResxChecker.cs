using System;
using System.Linq;
using System.Xml.Linq;

namespace ChineseIdentifier
{
    public class ResxChecker
    {
        private Indentifier identifier;

        public ResxChecker()
        {
            identifier = new Indentifier();
        }

        public IdentificationResults IsOfType(ChineseType expectedType, string filename)
        {
            var resxItems = XDocument
                .Load(filename)
                .Descendants()
                .Where(x => x.Name == "data")
                .Select(x => $"{ x.Attributes().First(a => a.Name == "name").Value} - {x.Value}")
                .ToList();

            foreach (var item in resxItems)
            {
                var itemKvp = item.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                var itemValue = itemKvp[1].Replace("\n", string.Empty).Trim();

                var chineseType = identifier.Identify(itemValue);

                if (chineseType != expectedType)
                {
                    return new IdentificationResults
                    {
                        WasMatch = false,
                        Message = $"Mismatch found in file: {filename}.\nExpected {expectedType.ToString("G")}, but found issue in resource {itemKvp[0]}."
                    };
                }
            }

            return new IdentificationResults
            {
                WasMatch = true
            };
        }
    }
}
