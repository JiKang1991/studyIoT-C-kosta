namespace MyLibrary
{
    class MyLib
    {
        public static int countToken(char delimiter, string str)
        {
            string[] tokens = str.Split(delimiter);
            int count = tokens.Length;
            return count;
        }

        // 문자열과 구분자를 받아 문자열을 분할한 후 인덱스 번째의 토큰을 리턴하는 함수입니다.
        public static string getToken(int index, char delimiter, string str)
        {
            string[] tokens = str.Split(delimiter);
            string token = tokens[index];
            return token;
        }
    }
}
