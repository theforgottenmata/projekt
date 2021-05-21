using System;
using System.IO;

namespace ProjectNew
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vítejte v programu Rozklad čísla na prvočinitele "); // výpis do konzole
            Console.WriteLine("\n-------------------------------------------------\n"); // výpis do konzole
            Console.WriteLine("Veškeré příklady, který tento program provede/vypočítá budou zaznamenány do souboru, který je umístěn"); // výpis do konzole
            Console.WriteLine(".../ProjectOriginal - master / ProjectNew / bin / Debug / netcoreapp3.1 / prime-nubmers.txt\n"); // výpis do konzole


            bool choiceValidation = false, inputNumberValidation = false, end = false, endValidation = false; //deklarace proměnných bool
            int number, divider, count = 0, randomNumber; //deklarace celočíselných proměnných
            var rand = new Random();
            Console.WriteLine("Zvolte si variantu"); // výpis do konzole
            File.Delete("prime-numbers.txt");



            while (choiceValidation == false) // bude se opakovat dokud vstup uživatele nebudu 1,2 potom se proměnná choiceValidation změní na true a program bude pokračovat
            {

                Console.WriteLine("1) Vygenerování čísla 1-1000"); // výpis do konzole 
                Console.WriteLine("2) Zadání svého čísla"); // výpis do konzole
                Console.WriteLine("c) Konec programu"); // výpis do konzole

                using (StreamWriter writetext = new StreamWriter("prime-numbers.txt", true)) // používání uložení do souboru
                {
                    string choice = Console.ReadLine(); // Čeká se na vstup uživatele

                    if (choice == "1" || choice == "2" || choice == "c") // ošetření aby uživatel zadal 1,2; 
                    {
                        choiceValidation = true; // změna proměnné choiceValidation na true

                        switch (choice) // switch - využití na dva vstupy, pokud uživatel zada 1, zapne se část case "1" |  pokud uživatel zadá 2, zapne se část case "2"
                        {
                            case "1": // po stisknutí 1 se spustí část programu case "1"
                                Console.WriteLine("\n-------------------------------------------------\n"); // výpis do konzole
                                randomNumber = rand.Next(2, 1000001); // generování náhodného čísla
                                Console.WriteLine($"Bylo vygenerováno číslo {randomNumber}"); // výpis do konzole
                                writetext.WriteLine($"Bylo vygenerováno číslo {randomNumber}");
                                count = 0;
                                for (divider = 2; randomNumber > 1; divider++)  // for cyklus, který se opakuje dokud je číslo od uživatele vyšší jak 1, pokud ho vydělím tolikrát, že je 0, for cycle se ukončí

                                    if (randomNumber % divider == 0) // jestliže zadané číslo dělené dělitelem nemá zbytek po dělení tak se podmínka provede
                                    {
                                        while (randomNumber % divider == 0) // dokud je zbytek po dělení 0
                                        {
                                            Console.WriteLine($"{count + 1}. {randomNumber} / {divider} = {randomNumber / divider}"); // výpis do konzole
                                            writetext.WriteLine($"{count + 1}. {randomNumber} / {divider} = {randomNumber / divider}"); //zápis do souboru
                                            randomNumber /= divider;  // randomNumber = randomNumber / devider
                                            count++; // k proměnné se přičte +1
                                        }
                                    }
                                writetext.WriteLine(""); //zápis do souboru
                                Console.WriteLine("");
                                choiceValidation = false;
                                break; // ukončení case "1"

                            case "2":// po stisknutí 2 se spustí část programu case "2"
                                Console.WriteLine("Zadejte číslo vyšší jak 1, jelikož 1 není prvočíslo"); // výpis do konzole
                                while (inputNumberValidation == false) // bude se opakovat dokud vstup uživatele > 1 potom se proměnná inputNumberValidation změní na true a program bude pokračovat
                                {
                                    string userInput = Console.ReadLine(); // Čeká se na vstup uživatele
                                    bool succes = Int32.TryParse(userInput, out number); // pokus o převedení vstupu na číslo, tato proměnná je deklarována jako bool (true/false)

                                    if (succes)
                                    {
                                        if (succes && number >= 2 && number <= 1000000) // oštření vstupu (jestli succes == true, number je větší jak 1
                                        {
                                            Console.WriteLine("\n-------------------------------------------------\n"); // výpis do konzole
                                            inputNumberValidation = true; // změna proměnné inputNumberValidation na true
                                            int inputNumber = Int32.Parse(userInput); // Input (string) od uživatele převeden na číslo (number)
                                            Console.WriteLine($"\nZadali jste číslo {userInput}"); // výpis do konzole

                                            writetext.WriteLine($"Zadali jste číslo {userInput}\n"); // zápis do souboru
                                            Console.WriteLine("Číslo: " + userInput + " rozdělíme na prvočísla následovně: "); // výpis do konzole
                                            count = 0;

                                            for (divider = 2; inputNumber > 1; divider++)  // for cyklus, který se opakuje dokud je číslo od uživatele vyšší jak 1, pokud ho vydělím tolikrát, že je 0, for cycle se ukončí
                                                if (inputNumber % divider == 0) // jestliže zadané číslo dělené dělitelem nemá zbytek po dělení tak se podmínka provede
                                                {
                                                    while (inputNumber % divider == 0) // dokud je zbytek po dělení 0
                                                    {

                                                        Console.WriteLine($"{count + 1}. {inputNumber} / {divider} = {inputNumber / divider}"); // výpis do konzole
                                                        writetext.WriteLine($"{count + 1}. {inputNumber} / {divider} = {inputNumber / divider}"); // zápis do souboru
                                                        inputNumber /= divider; // inputNumber = inputNumber / devider
                                                        count++; // k proměnné se přičte +1
                                                        choiceValidation = false;

                                                    }
                                                }
                                            writetext.WriteLine(""); //zápis do souboru
                                            Console.WriteLine("");
                                            Console.Write("\b");  // Odstranění posledního znaku výsledku
                                            
                                        }
                                        else // Pokud uživatel nezadá žádaný input, program vypíše zprávu, aby uživatel zadal číslo vyšší jak 1
                                        {
                                            Console.WriteLine("Zadejte číslo výšší než 1 a zároveň nižší než 1000000"); // výpis do konzole
                                        }

                                    }
                                    else {
                                        Console.WriteLine("Zadejte číslo"); // výpis do konzole
                                    }
                                }
                                inputNumberValidation = false;

                                break;

                            case "c":


                                while (endValidation == false) // bude se opakovat dokud vstup uživatele nebudu 1,2 potom se proměnná choiceValidation změní na true a program bude pokračovat
                                {
                                    Console.WriteLine("Opravdu chcete ukončit program? (y/n)");

                                    string yesNo = Console.ReadLine();

                                    if (yesNo == "y" || yesNo == "n")
                                    {
                                        endValidation = true;

                                        if (yesNo == "n")
                                        {
                                            end = false;


                                        }
                                        else if (yesNo == "y")
                                        {
                                            Environment.Exit(0);
                                        }



                                    }
                                    else
                                    {
                                        Console.WriteLine("Špatně zadaná hodnota");

                                    }
                                }
                                endValidation = false;
                                choiceValidation = false;
                                break;
                        }
                    }
                }
            }
        }
    }
}

