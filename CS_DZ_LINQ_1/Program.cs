using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DZ_LINQ_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Criminal> criminals = new List<Criminal> { new Criminal("Валера Местный", true, 170, 90, "Русский"), new Criminal("John Mitchel", false, 200, 80, "Американец"),
            new Criminal("Хафпек Игнатьевич", false, 180, 75, "Ингуш"),  new Criminal("Кукан Маленький", false, 210, 120, "Русский")};

            var filteredCriminals = criminals.Where(criminal => criminal.IsPrison == false);

            Console.WriteLine("Введите рост, вес и национальность: ");
            int height = Convert.ToInt32(Console.ReadLine());
            int weight = Convert.ToInt32(Console.ReadLine());
            string nationality = Console.ReadLine();

            filteredCriminals = from Criminal criminal in criminals
                                    where criminal.Height == height && criminal.Weight == weight && criminal.Nationality == nationality && criminal.IsPrison == false
                                    select criminal;

            if (filteredCriminals.Any())
            {
                foreach (var criminal in filteredCriminals)
                {
                    Console.WriteLine(criminal.Name);
                }
            }
            else
            {
                Console.WriteLine("Таких нет в базе! ");
            }
        }
    }

    class Criminal
    {
        public string Name { get; private set; }

        public bool IsPrison { get; private set; }

        public int Height { get; private set; }

        public int Weight { get; private set; }

        public string Nationality { get; private set; }

        public Criminal(string name, bool isPrison, int height, int weight, string nationality)
        {
            Name = name;
            IsPrison = isPrison;
            Height = height;
            Weight = weight;
            Nationality = nationality;
        }
    }
}
