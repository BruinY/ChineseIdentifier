namespace ChineseIdentifier
{
    public class Indentifier
    {
        public ChineseType Identify(string input)
        {
            var traditionalCharacters = 0;
            var simplifiedCharacters = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (Characters.Traditional.Contains(input[i].ToString()))
                {
                    traditionalCharacters++;
                } 
                else if (Characters.Simplified.Contains(input[i].ToString()))
                {
                    simplifiedCharacters++;
                }
            }

            return GetResult(traditionalCharacters, simplifiedCharacters);
        }

        private ChineseType GetResult(int traditionalCharacters, int simplifiedCharacters)
        {
            if (traditionalCharacters == 0 && simplifiedCharacters == 0)
            {
                return ChineseType.Unidentified;
            }
            else
            {
                return traditionalCharacters > simplifiedCharacters
                ? ChineseType.Traditional
                : ChineseType.Simplified;
            }
        }
    }
}
