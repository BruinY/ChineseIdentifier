namespace ChineseIdentifier
{
    public class Indentifier
    {
        public ChineseType Identify(string input)
        {
            var foundType = ChineseType.Unidentified;

            for (int i = 0; i < input.Length; i++)
            {
                if (Characters.Traditional.Contains(input[i].ToString()))
                {
                    return ChineseType.Traditional;
                } 
                else if (Characters.Simplified.Contains(input[i].ToString()))
                {
                    return ChineseType.Simplified;
                }
            }

            return foundType;
        }
    }
}
