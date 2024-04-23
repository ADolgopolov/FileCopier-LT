using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileCopier
{
    public static class PhotoNumberByString
    {
        public static decimal ParseString(string fullpath)
        {
            decimal photoNumber = 0;
            decimal parseResult;
            if (fullpath.Contains(".jpg"))
            {
                if (decimal.TryParse(Path.GetFileNameWithoutExtension(fullpath), out parseResult))
                {
                    photoNumber = parseResult;
                }
            }
            else
            {
                // "SmithsFalls|SmithsFalls-4|Run 25|28";
                string[] parts = fullpath.Split('|'); // Розділити рядок по символу "|"
                string lastPart = parts[parts.Length - 1]; // Взяти останній елемент масиву (останнє число)
                lastPart = Regex.Match(lastPart, @"\d+").Value; // Витягти всі цифри з останнього елементу
                
                if (decimal.TryParse(lastPart, out parseResult))
                {
                    // Вдалося перетворити
                    photoNumber = parseResult;
                }
            }
            return photoNumber;
        }
    }
}
