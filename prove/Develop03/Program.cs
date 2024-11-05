﻿using System;
using System.Linq;
using System.Text.RegularExpressions;





class Program
{
    static void Main()
    {
    
        Reference reference = new Reference("2 Nephi", 2, 11, 15);

       
        string fullText = @"
            For it must needs be, that there is an opposition in all things.
            If not so, my firstborn in the wilderness, righteousness could not be brought to pass, neither wickedness,
            neither holiness nor misery, neither good nor bad. Wherefore, all things must needs be a compound in one; wherefore,
            if it should be one body it must needs remain as dead, having no life neither death, nor corruption nor incorruption,
            happiness nor misery, neither sense nor insensibility.

            Wherefore, it must needs have been created for a thing of naught;
            wherefore there would have been no purpose in the end of its creation.
            Wherefore, this thing must needs destroy the wisdom of God and his eternal purposes,
            and also the power, and the mercy, and the justice of God.

            And if ye shall say there is no law, ye shall also say there is no sin. If ye shall say there is no sin,
            ye shall also say there is no righteousness. And if there be no righteousness there be no happiness.
            And if there be no righteousness nor happiness there be no punishment nor misery.
            And if these things are not there is no God. And if there is no God we are not, neither the earth;
            for there could have been no creation of things, neither to act nor to be acted upon; wherefore,
            all things must have vanished away.

            And now, my sons, I speak unto you these things for your profit and learning;
            for there is a God, and he hath created all things, both the heavens and the earth,
            and all things that in them are, both things to act and things to be acted upon.

            And to bring about his eternal purposes in the end of man, after he had created our first parents,
            and the beasts of the field and the fowls of the air, and in fine, all things which are created,
            it must needs be that there was an opposition; even the forbidden fruit in opposition to the tree of life;
            the one being sweet and the other bitter.
        ";

        Scripture scripture = new Scripture(reference, fullText);

        Console.WriteLine(scripture.GetDisplayText());

        Console.WriteLine("Press enter to continue or type anything and press enter to finish: ");
        ConsoleKeyInfo keyInfo = Console.ReadKey();

        if (keyInfo.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            string[] words = Regex.Split(fullText, @"\s+");
            Random random = new Random();

            while (!scripture.IsCompletelyHidden(words))
            {
                
                int[] indicesToErase = Enumerable.Range(0, words.Length)
                        .Where(i => !words[i].Contains("_"))
                        .OrderBy(x => random.Next())
                        .Take(5)
                        .ToArray();

                string modifiedText = scripture.ReplaceWordsWithUnderscores(words, indicesToErase);
                Console.Clear();
                Console.WriteLine(modifiedText);
                keyInfo = Console.ReadKey(); 

           
            }

            
        }else if (Console.ReadLine() == " ")
        {
            Environment.Exit(0);
        }
    }
}