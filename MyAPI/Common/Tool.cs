using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAPI.Common
{
    public static class Tool
    {
        public static String CfsEnCode(String CodeStr)
        {

            String CfsEnCodes = "";
            int CodeLen = 30;
            int CodeSpace;
            double NewCode;
            int cecr;
            int ccc = 0;
            CodeSpace = CodeLen - CodeStr.ToString().Length;
            if (CodeSpace > 1)
            {
                for (cecr = 1; cecr <= CodeSpace; cecr++)
                {
                    CodeStr = CodeStr + Convert.ToChar(21);
                    ccc += 1;
                }
            }
            NewCode = 1;
            int Been;
            int cecb;
            for (cecb = 1; cecb <= CodeLen; cecb++)
            {
                Been = CodeLen + Convert.ToChar(Mid(CodeStr, cecb, 1)) * cecb;

                NewCode = NewCode * Been;
            }
            CodeStr = Convert.ToString(NewCode);
            String NewCodes = null;
            int cec;
            for (cec = 1; cec <= CodeStr.Length; cec++)
            {
                NewCodes += CfsCode(Mid(CodeStr, cec, 3));
            }
            string NewCodes01 = Convert.ToString(NewCodes);
            for (cec = 20; cec <= NewCodes01.Length - 18; cec += 2)
            {
                CfsEnCodes = CfsEnCodes + Mid(NewCodes01, cec, 1);
            }
            return CfsEnCodes;
        }

        private static String Mid(string word, int cc, int p)
        {
            int strlen = word.Length;
            cc = cc - 1;
            int thislen = cc + p;
            if (strlen < thislen) { p = strlen - cc; }
            string s = word.Substring(cc, p);
            return Convert.ToString(s);
        }

        private static String CfsCode(String word)
        {
            int cc;
            char str;
            String CfsCodes = null;
            for (cc = 1; cc <= word.Length; cc++)
            {
                str = Convert.ToChar(Mid(word, cc, 1));
                CfsCodes += Convert.ToInt32(str);
            }
            return Hex(CfsCodes);

        }

        private static String Hex(String x)
        {
            String result = null;
            int n;

            string[] s1 = x.Split(' ');


            foreach (String cint in s1)
            {
                if (cint == "")
                {
                    continue;
                }
                n = Convert.ToInt32(cint);
                result += Convert.ToString(n.ToString("X"));
            }

            return result;
        }
    }
}