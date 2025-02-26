using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TI_1
{
    internal class ColumnarTransposition
    {
        private static string RussianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        public static string Encrypt(string arg, string key)
        {
            if (string.IsNullOrEmpty(arg) || string.IsNullOrEmpty(key))
                return arg;

            int rows = (int)Math.Ceiling((double)arg.Length / key.Length) + 1;
            char[,] arr = new char[rows, key.Length];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < key.Length; j++)
                    arr[i, j] = ' ';

            StringBuilder sb = new StringBuilder(key);
            for (int i = 0; i < key.Length; i++)
                arr[0, i] = sb[i];
            
            sb.Clear();
            sb.Append(arg);
            int k = 0;
            for (int i = 1; i < rows - 1; i++)
                for (int j = 0; j < key.Length; j++)
                    arr[i, j] = sb[k++];

            int z = 0;
            while (k < sb.Length) arr[rows - 1, z++] = sb[k++];
            
            #region сортировка
            for (int i = 0; i < key.Length - 1; i++)
            {
                for (int j = i; j < key.Length; j++)
                {
                    if (RussianAlphabet.IndexOf(arr[0, i]) > RussianAlphabet.IndexOf(arr[0, j]))
                    {
                        for (k = 0; k < rows; k++)
                        {
                            char temp = arr[k, i];
                            arr[k, i] = arr[k, j];
                            arr[k, j] = temp;
                        }
                    }
                }
            }
            #endregion
            
            sb.Clear();
            k = 0;
            for (int j = 0; j < key.Length; j++)
                for (int i = 1; i < rows; i++)
                    if (arr[i, j] != ' ')
                        sb.Append(arr[i, j]);
            
            return sb.ToString();
        }

        public static string Decrypt(string arg, string key)
        {
            if (string.IsNullOrEmpty(arg) || string.IsNullOrEmpty(key))
                return arg;

            StringBuilder sb = new StringBuilder(key);
            int[] order = new int[key.Length];
            int j = 0;
            int big_col = arg.Length % key.Length;
            List<int> big_ind = new List<int>();
            
            foreach (char ch in RussianAlphabet)
                for (int i = 0; i < key.Length; i++)
                    if (sb[i] == ch)
                    {
                        if (i < big_col) big_ind.Add(j);
                        order[i] = j++;
                    }
            
            sb.Clear();
            sb.Append(arg);
            int rows = (int)Math.Ceiling((double)arg.Length / key.Length);
            char[,] arr = new char[rows, key.Length];
            j = 0;
            for (int k = 0; k < key.Length; k++)
            {
                if (big_col == 0 || big_ind.Contains(k))
                {
                    for (int i = 0; i < rows; i++)
                        arr[i, k] = sb[j++];
                }
                else
                {
                    for (int i = 0; i < rows - 1; i++)
                        arr[i, k] = sb[j++];
                }
            }
            
            sb.Clear();
            for (int i = 0; i < rows; i++)
                for (j = 0; j < key.Length; j++)
                    if (char.IsLetter(arr[i, order[j]]))
                        sb.Append(arr[i, order[j]]);
            
            return sb.ToString();
        }

        public static string GetValidKey(string str)
        {
            return new string(str.ToUpper().Where(ch => RussianAlphabet.Contains(ch)).ToArray());
        }

        public static string GetValidPlainText(string str)
        {
            return new string(str.ToUpper().Where(ch => RussianAlphabet.Contains(ch)).ToArray());
        }
    }
}
