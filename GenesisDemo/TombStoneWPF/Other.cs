using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TombStoneWPF
{
    public class Other
    {
        // 开始 替换 Byte
        public static int Replace(ref Byte[] all, Byte[] s, Byte[] t)
        {
            if (s.Length > all.Length) return 0;
            int replace_count = 0;
            List<byte> temp = new List<byte>();
            for (int i = 0; i < all.Length - s.Length + 1; i++)
            {
                bool catch_s = true;
                for (int j = 0; j < s.Length; j++)
                {
                    if (all[i + j] != s[j])
                    {
                        catch_s = false;
                        break;
                    }
                }
                if (catch_s)
                {
                    replace_count++;
                    temp.AddRange(t);
                    i += s.Length - 1;
                }
                else
                {
                    temp.Add(all[i]);
                }
                if (i == all.Length - s.Length)
                {
                    if (!catch_s)
                    {
                        temp.Add(all[all.Length - 2]);
                        temp.Add(all[all.Length - 1]);
                    }
                }
            }

            all = temp.ToArray();
            return replace_count;
        }
        // 结束 替换 Byte
    }
}
